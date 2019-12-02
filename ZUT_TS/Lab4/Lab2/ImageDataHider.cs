using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Lab2
{
    class ImageDataHider
    {
        static Int32 getSeedFromSteganographicKey(byte[] steganographicKey)
        {
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(steganographicKey, new byte[128], "SHA512", 1);
            Int32[] result = new Int32[1];
            byte[] bytes4 = passwordDeriveBytes.GetBytes(4);
            BitArray bits = new BitArray(bytes4);
            bits.CopyTo(result, 0);
            //bytes4.CopyTo(result, 0);
            return result[0];
        }

        static byte[] encrypt(byte[] passphrase, byte[] message)
        {
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passphrase, new byte[128], "SHA512", 1);

            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = passwordDeriveBytes.GetBytes(aes.KeySize / 8);
                aes.IV = passwordDeriveBytes.GetBytes(aes.BlockSize / 8);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(message, 0, message.Length);
                    cryptoStream.Close();
                    encrypted = memoryStream.ToArray();
                }
            }
            return encrypted;
        }

        static byte[] decrypt(byte[] passphrase, byte[] message)
        {
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passphrase, new byte[128], "SHA512", 1);

            byte[] decrypted;
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = passwordDeriveBytes.GetBytes(aes.KeySize / 8);
                aes.IV = passwordDeriveBytes.GetBytes(aes.BlockSize / 8);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(message, 0, message.Length);
                    cryptoStream.Close();
                    decrypted = memoryStream.ToArray();
                }
            }

            return decrypted;
        }

        public static Bitmap hideMessage(byte[] steganographicKey, byte[] passphrase, byte[] message, Bitmap sourceImage)
        {
            byte[] encryptedMessage = encrypt(passphrase, message);
            // * 8 (byte -> bit); * 5 (hamming)
            BitArray bitArrayLength = new BitArray(BitConverter.GetBytes((Int32)encryptedMessage.Length * 8 * 5));
            BitArray bitArray = bitArrayLength.concatenate(Hamming.encode(new BitArray(encryptedMessage)));

            Bitmap bitmap = new Bitmap(sourceImage);
            //int counter = 0;
            //for (int i = 0; i < bitmap.Width && counter < bitArray.Length; i++)
            //    for (int j = 0; j < bitmap.Height && counter < bitArray.Length; j++)
            //    {
            //        bitmap.SetPixel(i, j, set2Bits(bitmap.GetPixel(i, j), bitArray, counter));
            //        counter += 2;
            //    }

            Int32 seed = getSeedFromSteganographicKey(steganographicKey);
            HashSet<Point> points = new HashSet<Point>();
            Random random = new Random(seed);
            for (int counter = 0; counter < bitArray.Length;)
            {
                Point point = new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height));
                if (!points.Contains(point))
                {
                    points.Add(point);
                    if(counter < 32)
                    Console.Write(point + " ");
                    bitmap.SetPixel(point.X, point.Y, set2Bits(bitmap.GetPixel(point.X, point.Y), bitArray, counter));
                    counter += 2;
                }
                // else no luck, reroll
            }

            Console.WriteLine();

            return bitmap;
        }


        public static byte[] readMessage(byte[] steganographicKey, byte[] passphrase, Bitmap bitmap)
        {
            BitArray bitArrayMessageLength = new BitArray(32);
            BitArray bitArrayEncryptedMessage = null;
            Int32 messageLength = 0;

            int counter = 0;
            //for (int i = 0; i < bitmap.Width; i++)
            //{
            //    if (counter > 32 && counter - 32 >= messageLength)
            //        break;

            //    for (int j = 0; j < bitmap.Height; j++)
            //    {
            //        if (counter == 32)
            //        {
            //            foreach (bool b in bitArrayMessageLength)
            //                Console.Write(b ? '1' : '0');
            //            Console.WriteLine();

            //            var result = new int[1];
            //            bitArrayMessageLength.CopyTo(result, 0);
            //            messageLength = result[0];
            //            bitArrayEncryptedMessage = new BitArray(messageLength);

            //            Console.WriteLine("ml = " + messageLength);
            //        }

            //        if (counter < 32)
            //            get2Bits(bitArrayMessageLength, bitmap.GetPixel(i, j), counter);
            //        else if (counter - 32 < messageLength)
            //            get2Bits(bitArrayEncryptedMessage, bitmap.GetPixel(i, j), counter - 32);
            //        else
            //            break;

            //        counter += 2;
            //    }
            //}

            Int32 seed = getSeedFromSteganographicKey(steganographicKey);
            HashSet<Point> points = new HashSet<Point>();
            Random random = new Random(seed);
            while (counter <= 32 || counter - 32 < messageLength)
            {
                Point point = new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height));
                if (!points.Contains(point))
                {
                    points.Add(point);
                    if (counter == 32)
                    {
                        var result = new int[1];
                        bitArrayMessageLength.CopyTo(result, 0);
                        messageLength = result[0];
                        if (messageLength % 10 != 0 || messageLength >= bitmap.Width * bitmap.Height * 2 - 32)
                            throw new Exception("Invalid image");

                        bitArrayEncryptedMessage = new BitArray(messageLength);
                    }
                    if (counter < 32)
                    {
                        get2Bits(bitArrayMessageLength, bitmap.GetPixel(point.X, point.Y), counter);
                        Console.Write(point + " ");
                    }
                    else // if (counter -32 < messageLength)
                        get2Bits(bitArrayEncryptedMessage, bitmap.GetPixel(point.X, point.Y), counter - 32);

                    counter += 2;
                }
            }

            byte[] encryptedMessage = new byte[bitArrayEncryptedMessage.Length / 5 / 8];
            Hamming.decode(bitArrayEncryptedMessage).CopyTo(encryptedMessage, 0);
            return decrypt(passphrase, encryptedMessage);
        }

        static Color set2Bits(Color color, BitArray bitArray, int offset)
        {
            bool a1 = (color.R & 0x1) == 0x1,
                 a2 = (color.G & 0x1) == 0x1,
                 a3 = (color.B & 0x1) == 0x1;
            
            bool x1 = bitArray.Get(offset),
                 x2 = bitArray.Get(offset + 1);

            if ((x1 == (a1 ^ a3)) && (x2 == (a2 ^ a3)))
                return color; // change nothing

            byte R = color.R,
                 G = color.G,
                 B = color.B;

            /**/ if ((x1 != (a1 ^ a3)) && (x2 == (a2 ^ a3)))
                R ^= 0x1;     // change a1 (R LSB)
            else if ((x1 == (a1 ^ a3)) && (x2 != (a2 ^ a3)))
                G ^= 0x1;     // change a2 (G LSB)
            else if ((x1 != (a1 ^ a3)) && (x2 != (a2 ^ a3)))
                B ^= 0x1;     // change a3 (B LSB)

            return Color.FromArgb(color.A, R, G, B);
        }

        static void get2Bits(BitArray bitArray, Color color, int offset)
        {
            bool a1 = ((color.R & 0x1) == 0x1),
                 a2 = ((color.G & 0x1) == 0x1),
                 a3 = ((color.B & 0x1) == 0x1);
            
            bool x1, x2;
            x1 = a1 ^ a3;
            x2 = a2 ^ a3;

            bitArray.Set(offset, x1);
            bitArray.Set(offset + 1, x2);
        }
    }
}

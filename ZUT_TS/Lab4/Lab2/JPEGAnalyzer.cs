using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class JPEGAnalyzer
    {
        public static Bitmap convertToJPEG(Bitmap input)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                input.Save(memoryStream, ImageFormat.Jpeg);
                return new Bitmap(memoryStream);
            }
        }

        static Color auxXor(Color color1, Color color2)
        {
            return Color.FromArgb(color1.A, color1.R ^ color2.R, color1.G ^ color2.G, color1.B ^ color2.B);
        }

        // xor, diff
        public static (Bitmap, Bitmap) xor(Bitmap image1, Bitmap image2, Func<int, bool> progressCallback)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
                throw new Exception("Invalid image");

            Bitmap xor = new Bitmap(image1.Width, image1.Height);
            Bitmap difference = new Bitmap(image1.Width, image1.Height);

            double max = image1.Width * image1.Height;
            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    int pixelNo = i * image1.Height + j;
                    if (pixelNo % 10000 == 0)
                        progressCallback((int)(pixelNo / max * 100));

                    if (image1.GetPixel(i, j) != image2.GetPixel(i, j))
                    {
                        xor.SetPixel(i, j, auxXor(image1.GetPixel(i, j), image2.GetPixel(i, j)));
                        difference.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        difference.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                    }
                }

            progressCallback(100);
            return (xor, difference);
        }
    }
}

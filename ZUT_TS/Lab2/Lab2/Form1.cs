using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string filenameLeft = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                        openFileDialog.InitialDirectory = @"C:\users\user\Desktop";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filenameLeft = openFileDialog.FileName;
                            Image image = Bitmap.FromFile(filenameLeft);
                            pictureBoxLeft.Image = image;
                        }
                        break;

                    case Keys.S:
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "BMP Files (*.bmp) | *.bmp";
                        saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filenameLeft) + ".bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            pictureBoxRight.Image.Save(saveFileDialog.FileName);
                            MessageBox.Show("Successfully saved");
                        }
                        break;
                }
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = pictureBoxLeft.Image as Bitmap;
            byte[] steganographicKey = Encoding.UTF8.GetBytes(textBoxSteganographicKey.Text);
            byte[] passpharse = Encoding.UTF8.GetBytes(textBoxPassphrase.Text);
            byte[] message = Encoding.UTF8.GetBytes(textBoxMessage.Text);
            if (bitmap == null || passpharse.Length == 0 || message.Length == 0)
            {
                MessageBox.Show(
                    @"You need to:
                    - open an image (CTRL + O)
                    - enter the Passphrase
                    - enter the Message"
                );
                return;
            }

            Bitmap newBitmap = ImageDataHider.hideMessage(steganographicKey, passpharse, message, bitmap);
            pictureBoxRight.Image = newBitmap;
            MessageBox.Show("Successfully hidden message in the selected image!");
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = ((sender as Button).Text.Contains("right") ? pictureBoxRight.Image : pictureBoxLeft.Image) as Bitmap;
            byte[] steganographicKey = Encoding.UTF8.GetBytes(textBoxSteganographicKey.Text);
            byte[] passpharse = Encoding.UTF8.GetBytes(textBoxPassphrase.Text);
            if (bitmap == null || passpharse.Length == 0)
            {
                MessageBox.Show(
                    @"You need to:
                    - open an image (CTRL + O)
                    - enter the Key"
                );
                return;
            }

            byte[] message = ImageDataHider.readMessage(steganographicKey, passpharse, bitmap);
            textBoxMessage.Text = Encoding.UTF8.GetString(message);
            MessageBox.Show("Successfully retrieved message from the selected image!");
        }
    }
}

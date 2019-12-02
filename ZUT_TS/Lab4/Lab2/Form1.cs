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
            pictureBoxLeft.BackgroundImageLayout = ImageLayout.Zoom;
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
                            pictureBoxLeft.BackgroundImage = image;
                        }
                        break;

                    case Keys.S:
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "BMP Files (*.bmp) | *.bmp";
                        saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filenameLeft) + ".bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            pictureBoxMiddle.Image.Save(saveFileDialog.FileName);
                            MessageBox.Show("Successfully saved");
                        }
                        break;
                }
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if(pictureBoxLeft.BackgroundImage == null)
            {
                MessageBox.Show("No selected image");
                return;
            }

            pictureBoxMiddle.Image = JPEGAnalyzer.convertToJPEG(pictureBoxLeft.BackgroundImage as Bitmap);
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            if(pictureBoxLeft.BackgroundImage == null || pictureBoxMiddle.Image == null)
            {
                MessageBox.Show("Load an image and convert it beforehands");
                return;
            }

            (pictureBoxRight.Image, pictureBoxLeft.Image) = 
                JPEGAnalyzer.xor(pictureBoxLeft.BackgroundImage as Bitmap, pictureBoxMiddle.Image as Bitmap, updateProgressBar);

            MessageBox.Show("Done.");
            progressBar1.Value = 0;
        }

        bool updateProgressBar(int value)
        {
            this.Invoke(new Action(() => {
                    progressBar1.Value = value;
                    progressBar1.Update();
                }));

            return true;
        }
    }
}

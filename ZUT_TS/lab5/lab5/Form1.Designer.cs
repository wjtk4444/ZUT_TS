namespace lab5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonStartClients = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(50, 6);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(576, 20);
            this.textBoxUrl.TabIndex = 0;
            this.textBoxUrl.Text = "http://example.com/";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(12, 9);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(32, 13);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "URL:";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(15, 32);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(773, 406);
            this.webBrowser.TabIndex = 2;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(713, 4);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 4;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonStartClients
            // 
            this.buttonStartClients.Location = new System.Drawing.Point(632, 4);
            this.buttonStartClients.Name = "buttonStartClients";
            this.buttonStartClients.Size = new System.Drawing.Size(75, 23);
            this.buttonStartClients.TabIndex = 5;
            this.buttonStartClients.Text = "Start clients";
            this.buttonStartClients.UseVisualStyleBackColor = true;
            this.buttonStartClients.Click += new System.EventHandler(this.buttonStartClients_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartClients);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonStartClients;
    }
}


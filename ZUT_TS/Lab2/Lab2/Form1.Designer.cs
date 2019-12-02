namespace Lab2
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
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.textBoxPassphrase = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.labelPassphrase = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReadRight = new System.Windows.Forms.Button();
            this.labelSteganographicKey = new System.Windows.Forms.Label();
            this.textBoxSteganographicKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRight.Location = new System.Drawing.Point(391, 3);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(382, 333);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 0;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeft.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(382, 333);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 1;
            this.pictureBoxLeft.TabStop = false;
            // 
            // textBoxPassphrase
            // 
            this.textBoxPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassphrase.Location = new System.Drawing.Point(677, 359);
            this.textBoxPassphrase.Name = "textBoxPassphrase";
            this.textBoxPassphrase.Size = new System.Drawing.Size(111, 20);
            this.textBoxPassphrase.TabIndex = 2;
            this.textBoxPassphrase.Text = "1234567890ABCDEF";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Location = new System.Drawing.Point(12, 386);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(776, 52);
            this.textBoxMessage.TabIndex = 3;
            this.textBoxMessage.Text = "This is an example message.";
            // 
            // labelPassphrase
            // 
            this.labelPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassphrase.AutoSize = true;
            this.labelPassphrase.Location = new System.Drawing.Point(609, 362);
            this.labelPassphrase.Name = "labelPassphrase";
            this.labelPassphrase.Size = new System.Drawing.Size(62, 13);
            this.labelPassphrase.TabIndex = 4;
            this.labelPassphrase.Text = "Passphrase";
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 362);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(50, 13);
            this.labelMessage.TabIndex = 5;
            this.labelMessage.Text = "Message";
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHide.Location = new System.Drawing.Point(68, 357);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(75, 23);
            this.buttonHide.TabIndex = 6;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRead.Location = new System.Drawing.Point(149, 357);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 7;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.pictureBoxRight, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBoxLeft, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(776, 339);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // buttonReadRight
            // 
            this.buttonReadRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReadRight.Location = new System.Drawing.Point(230, 357);
            this.buttonReadRight.Name = "buttonReadRight";
            this.buttonReadRight.Size = new System.Drawing.Size(140, 23);
            this.buttonReadRight.TabIndex = 8;
            this.buttonReadRight.Text = "Read from the right image";
            this.buttonReadRight.UseVisualStyleBackColor = true;
            this.buttonReadRight.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelSteganographicKey
            // 
            this.labelSteganographicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSteganographicKey.AutoSize = true;
            this.labelSteganographicKey.Location = new System.Drawing.Point(400, 362);
            this.labelSteganographicKey.Name = "labelSteganographicKey";
            this.labelSteganographicKey.Size = new System.Drawing.Size(102, 13);
            this.labelSteganographicKey.TabIndex = 9;
            this.labelSteganographicKey.Text = "Steganographic key";
            // 
            // textBoxSteganographicKey
            // 
            this.textBoxSteganographicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSteganographicKey.Location = new System.Drawing.Point(508, 359);
            this.textBoxSteganographicKey.Name = "textBoxSteganographicKey";
            this.textBoxSteganographicKey.Size = new System.Drawing.Size(95, 20);
            this.textBoxSteganographicKey.TabIndex = 10;
            this.textBoxSteganographicKey.Text = "admin1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSteganographicKey);
            this.Controls.Add(this.labelSteganographicKey);
            this.Controls.Add(this.buttonReadRight);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelPassphrase);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxPassphrase);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.TextBox textBoxPassphrase;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelPassphrase;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonReadRight;
        private System.Windows.Forms.Label labelSteganographicKey;
        private System.Windows.Forms.TextBox textBoxSteganographicKey;
    }
}


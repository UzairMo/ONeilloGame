namespace ONeilloGame
{
    partial class HelpModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpModal));
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            lblInformation = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(21, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 326);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(287, 39);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(231, 42);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "O'Neillo Game";
            // 
            // lblInformation
            // 
            lblInformation.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblInformation.Location = new Point(287, 90);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(231, 258);
            lblInformation.TabIndex = 2;
            lblInformation.Text = resources.GetString("lblInformation.Text");
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.Location = new Point(227, 363);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // HelpModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 413);
            Controls.Add(btnClose);
            Controls.Add(lblInformation);
            Controls.Add(lblTitle);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(555, 452);
            MinimumSize = new Size(555, 452);
            Name = "HelpModal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Help";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblTitle;
        private Label lblInformation;
        private Button btnClose;
    }
}
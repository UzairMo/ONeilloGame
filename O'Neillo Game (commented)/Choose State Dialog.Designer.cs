namespace ONeilloGame
{
    partial class ChooseStateDialog
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
            listBoxGameStates = new ListBox();
            btnOk = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            lblGameStates = new Label();
            SuspendLayout();
            // 
            // listBoxGameStates
            // 
            listBoxGameStates.FormattingEnabled = true;
            listBoxGameStates.ItemHeight = 15;
            listBoxGameStates.Location = new Point(13, 47);
            listBoxGameStates.Name = "listBoxGameStates";
            listBoxGameStates.Size = new Size(235, 124);
            listBoxGameStates.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOk.Location = new Point(11, 177);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(173, 177);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(92, 177);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblGameStates
            // 
            lblGameStates.AutoSize = true;
            lblGameStates.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameStates.Location = new Point(68, 14);
            lblGameStates.Name = "lblGameStates";
            lblGameStates.Size = new Size(118, 25);
            lblGameStates.TabIndex = 4;
            lblGameStates.Text = "Game States";
            // 
            // ChooseStateDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 221);
            Controls.Add(lblGameStates);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(listBoxGameStates);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(276, 260);
            MinimumSize = new Size(276, 260);
            Name = "ChooseStateDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game States";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxGameStates;
        private Button btnOk;
        private Button btnCancel;
        private Button btnDelete;
        private Label lblGameStates;
    }
}
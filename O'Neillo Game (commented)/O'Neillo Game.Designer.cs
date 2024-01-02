namespace ONeilloGame
{
    partial class ONeilloGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ONeilloGame));
            lblBlackCounter = new Label();
            lblWhiteCounter = new Label();
            lblBlackCount = new Label();
            lblWhiteCount = new Label();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadGameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            gameToolStripMenuItem1 = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            txtPlayer1 = new TextBox();
            txtPlayer2 = new TextBox();
            pbToPlayBlack = new PictureBox();
            pbToPlayWhite = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbToPlayBlack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbToPlayWhite).BeginInit();
            SuspendLayout();
            // 
            // lblBlackCounter
            // 
            lblBlackCounter.AutoSize = true;
            lblBlackCounter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBlackCounter.ForeColor = Color.White;
            lblBlackCounter.Location = new Point(159, 622);
            lblBlackCounter.Name = "lblBlackCounter";
            lblBlackCounter.Size = new Size(14, 15);
            lblBlackCounter.TabIndex = 0;
            lblBlackCounter.Text = "0";
            // 
            // lblWhiteCounter
            // 
            lblWhiteCounter.AutoSize = true;
            lblWhiteCounter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWhiteCounter.ForeColor = Color.White;
            lblWhiteCounter.Location = new Point(410, 622);
            lblWhiteCounter.Name = "lblWhiteCounter";
            lblWhiteCounter.Size = new Size(14, 15);
            lblWhiteCounter.TabIndex = 1;
            lblWhiteCounter.Text = "0";
            // 
            // lblBlackCount
            // 
            lblBlackCount.AutoSize = true;
            lblBlackCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBlackCount.ForeColor = Color.White;
            lblBlackCount.Location = new Point(100, 622);
            lblBlackCount.Name = "lblBlackCount";
            lblBlackCount.Size = new Size(55, 15);
            lblBlackCount.TabIndex = 2;
            lblBlackCount.Text = "Counter:";
            // 
            // lblWhiteCount
            // 
            lblWhiteCount.AutoSize = true;
            lblWhiteCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWhiteCount.ForeColor = Color.White;
            lblWhiteCount.Location = new Point(351, 622);
            lblWhiteCount.Name = "lblWhiteCount";
            lblWhiteCount.Size = new Size(55, 15);
            lblWhiteCount.TabIndex = 3;
            lblWhiteCount.Text = "Counter:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, gameToolStripMenuItem1, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(538, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadGameToolStripMenuItem, saveGameToolStripMenuItem, exitToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(134, 22);
            newToolStripMenuItem.Text = "New Game";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // loadGameToolStripMenuItem
            // 
            loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            loadGameToolStripMenuItem.Size = new Size(134, 22);
            loadGameToolStripMenuItem.Text = "Load Game";
            loadGameToolStripMenuItem.Click += loadGameToolStripMenuItem_Click;
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(134, 22);
            saveGameToolStripMenuItem.Text = "Save Game";
            saveGameToolStripMenuItem.Click += saveGameToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(134, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // gameToolStripMenuItem1
            // 
            gameToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { speakToolStripMenuItem, informationPanelToolStripMenuItem });
            gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            gameToolStripMenuItem1.Size = new Size(61, 20);
            gameToolStripMenuItem1.Text = "Settings";
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.CheckOnClick = true;
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(169, 22);
            speakToolStripMenuItem.Text = "Speak";
            speakToolStripMenuItem.Click += SpeakToolStripMenuItem_Click;
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckOnClick = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(169, 22);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += informationPanelToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // txtPlayer1
            // 
            txtPlayer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPlayer1.Location = new Point(84, 596);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(100, 23);
            txtPlayer1.TabIndex = 5;
            // 
            // txtPlayer2
            // 
            txtPlayer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPlayer2.Location = new Point(333, 596);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(100, 23);
            txtPlayer2.TabIndex = 6;
            // 
            // pbToPlayBlack
            // 
            pbToPlayBlack.Image = (Image)resources.GetObject("pbToPlayBlack.Image");
            pbToPlayBlack.Location = new Point(70, 540);
            pbToPlayBlack.Name = "pbToPlayBlack";
            pbToPlayBlack.Size = new Size(137, 50);
            pbToPlayBlack.SizeMode = PictureBoxSizeMode.StretchImage;
            pbToPlayBlack.TabIndex = 7;
            pbToPlayBlack.TabStop = false;
            // 
            // pbToPlayWhite
            // 
            pbToPlayWhite.Image = (Image)resources.GetObject("pbToPlayWhite.Image");
            pbToPlayWhite.Location = new Point(316, 540);
            pbToPlayWhite.Name = "pbToPlayWhite";
            pbToPlayWhite.Size = new Size(137, 50);
            pbToPlayWhite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbToPlayWhite.TabIndex = 8;
            pbToPlayWhite.TabStop = false;
            // 
            // ONeilloGame
            // 
            BackColor = Color.DarkGreen;
            ClientSize = new Size(538, 655);
            Controls.Add(pbToPlayWhite);
            Controls.Add(pbToPlayBlack);
            Controls.Add(txtPlayer2);
            Controls.Add(txtPlayer1);
            Controls.Add(lblWhiteCount);
            Controls.Add(lblBlackCount);
            Controls.Add(lblWhiteCounter);
            Controls.Add(lblBlackCounter);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "ONeilloGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "O'Neillo Game";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbToPlayBlack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbToPlayWhite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBlackCounter;
        private Label lblWhiteCounter;
        private Label lblBlackCount;
        private Label lblWhiteCount;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox txtPlayer1;
        private TextBox txtPlayer2;
        private ToolStripMenuItem loadGameToolStripMenuItem;
        private ToolStripMenuItem gameToolStripMenuItem1;
        private ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private PictureBox pbToPlayBlack;
        private PictureBox pbToPlayWhite;
    }
}
namespace Tetris
{
    partial class TetrisGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisGUI));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.NextBlockHeadling = new System.Windows.Forms.ToolStripStatusLabel();
            this.NextBlock = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScoreHeadline = new System.Windows.Forms.ToolStripStatusLabel();
            this.Score = new System.Windows.Forms.ToolStripStatusLabel();
            this.LinesHeadline = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lines = new System.Windows.Forms.ToolStripStatusLabel();
            this.LevelHeadline = new System.Windows.Forms.ToolStripStatusLabel();
            this.Level = new System.Windows.Forms.ToolStripStatusLabel();
            this.highScoreHeading = new System.Windows.Forms.ToolStripStatusLabel();
            this.highScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.PauseBtn = new System.Windows.Forms.ToolStripStatusLabel();
            this.PauseMenu = new System.Windows.Forms.Panel();
            this.LoadgameFromPauseBtn = new System.Windows.Forms.Button();
            this.NewGameFromPauseBtn = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PauseHeadline = new System.Windows.Forms.Label();
            this.GameOverPanel = new System.Windows.Forms.Panel();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.GameOverHeading = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip.SuspendLayout();
            this.PauseMenu.SuspendLayout();
            this.GameOverPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.AutoSize = false;
            this.StatusStrip.BackColor = System.Drawing.Color.Maroon;
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NextBlockHeadling,
            this.NextBlock,
            this.ScoreHeadline,
            this.Score,
            this.LinesHeadline,
            this.Lines,
            this.LevelHeadline,
            this.Level,
            this.highScoreHeading,
            this.highScore,
            this.PauseBtn});
            this.StatusStrip.Location = new System.Drawing.Point(334, 24);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(200, 492);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // NextBlockHeadling
            // 
            this.NextBlockHeadling.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.NextBlockHeadling.Name = "NextBlockHeadling";
            this.NextBlockHeadling.Size = new System.Drawing.Size(198, 30);
            this.NextBlockHeadling.Text = "Next";
            // 
            // NextBlock
            // 
            this.NextBlock.AutoSize = false;
            this.NextBlock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NextBlock.Name = "NextBlock";
            this.NextBlock.Size = new System.Drawing.Size(198, 59);
            // 
            // ScoreHeadline
            // 
            this.ScoreHeadline.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.ScoreHeadline.Name = "ScoreHeadline";
            this.ScoreHeadline.Size = new System.Drawing.Size(198, 30);
            this.ScoreHeadline.Text = "Score";
            // 
            // Score
            // 
            this.Score.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(198, 30);
            this.Score.Text = "<Score>";
            // 
            // LinesHeadline
            // 
            this.LinesHeadline.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.LinesHeadline.Name = "LinesHeadline";
            this.LinesHeadline.Size = new System.Drawing.Size(198, 30);
            this.LinesHeadline.Text = "Lines";
            // 
            // Lines
            // 
            this.Lines.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.Lines.Name = "Lines";
            this.Lines.Size = new System.Drawing.Size(198, 30);
            this.Lines.Text = "<Lines>";
            // 
            // LevelHeadline
            // 
            this.LevelHeadline.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.LevelHeadline.Name = "LevelHeadline";
            this.LevelHeadline.Size = new System.Drawing.Size(198, 30);
            this.LevelHeadline.Text = "Level";
            // 
            // Level
            // 
            this.Level.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(198, 30);
            this.Level.Text = "<Level>";
            // 
            // highScoreHeading
            // 
            this.highScoreHeading.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.highScoreHeading.Name = "highScoreHeading";
            this.highScoreHeading.Size = new System.Drawing.Size(198, 30);
            this.highScoreHeading.Text = "High Score";
            // 
            // highScore
            // 
            this.highScore.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.highScore.Name = "highScore";
            this.highScore.Size = new System.Drawing.Size(198, 30);
            this.highScore.Text = "<High Score>";
            // 
            // PauseBtn
            // 
            this.PauseBtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.PauseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(0, 50, 0, 2);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(198, 30);
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PauseMenu
            // 
            this.PauseMenu.BackColor = System.Drawing.Color.DimGray;
            this.PauseMenu.Controls.Add(this.LoadgameFromPauseBtn);
            this.PauseMenu.Controls.Add(this.NewGameFromPauseBtn);
            this.PauseMenu.Controls.Add(this.SaveButton);
            this.PauseMenu.Controls.Add(this.PauseHeadline);
            this.PauseMenu.Location = new System.Drawing.Point(26, 42);
            this.PauseMenu.Name = "PauseMenu";
            this.PauseMenu.Size = new System.Drawing.Size(263, 443);
            this.PauseMenu.TabIndex = 1;
            // 
            // LoadgameFromPauseBtn
            // 
            this.LoadgameFromPauseBtn.BackColor = System.Drawing.Color.Maroon;
            this.LoadgameFromPauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadgameFromPauseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadgameFromPauseBtn.Location = new System.Drawing.Point(70, 255);
            this.LoadgameFromPauseBtn.Name = "LoadgameFromPauseBtn";
            this.LoadgameFromPauseBtn.Size = new System.Drawing.Size(130, 35);
            this.LoadgameFromPauseBtn.TabIndex = 3;
            this.LoadgameFromPauseBtn.Text = "Load Game";
            this.LoadgameFromPauseBtn.UseVisualStyleBackColor = false;
            this.LoadgameFromPauseBtn.Click += new System.EventHandler(this.LoadgameFromPauseBtn_Click);
            // 
            // NewGameFromPauseBtn
            // 
            this.NewGameFromPauseBtn.BackColor = System.Drawing.Color.Maroon;
            this.NewGameFromPauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameFromPauseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewGameFromPauseBtn.Location = new System.Drawing.Point(70, 200);
            this.NewGameFromPauseBtn.Name = "NewGameFromPauseBtn";
            this.NewGameFromPauseBtn.Size = new System.Drawing.Size(130, 35);
            this.NewGameFromPauseBtn.TabIndex = 2;
            this.NewGameFromPauseBtn.Text = "New Game";
            this.NewGameFromPauseBtn.UseVisualStyleBackColor = false;
            this.NewGameFromPauseBtn.Click += new System.EventHandler(this.NewGameFromPauseBtn_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Maroon;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(70, 145);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(130, 35);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save Game";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PauseHeadline
            // 
            this.PauseHeadline.AutoSize = true;
            this.PauseHeadline.BackColor = System.Drawing.Color.Transparent;
            this.PauseHeadline.Font = new System.Drawing.Font("MV Boli", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseHeadline.ForeColor = System.Drawing.Color.Maroon;
            this.PauseHeadline.Location = new System.Drawing.Point(45, 15);
            this.PauseHeadline.Name = "PauseHeadline";
            this.PauseHeadline.Size = new System.Drawing.Size(165, 55);
            this.PauseHeadline.TabIndex = 0;
            this.PauseHeadline.Text = "Paused";
            // 
            // GameOverPanel
            // 
            this.GameOverPanel.BackColor = System.Drawing.Color.DimGray;
            this.GameOverPanel.Controls.Add(this.LoadGameButton);
            this.GameOverPanel.Controls.Add(this.NewGameButton);
            this.GameOverPanel.Controls.Add(this.GameOverHeading);
            this.GameOverPanel.Location = new System.Drawing.Point(26, 42);
            this.GameOverPanel.Name = "GameOverPanel";
            this.GameOverPanel.Size = new System.Drawing.Size(263, 443);
            this.GameOverPanel.TabIndex = 2;
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.BackColor = System.Drawing.Color.Maroon;
            this.LoadGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadGameButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadGameButton.Location = new System.Drawing.Point(70, 200);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(130, 35);
            this.LoadGameButton.TabIndex = 2;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = false;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Maroon;
            this.NewGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewGameButton.Location = new System.Drawing.Point(70, 145);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(130, 35);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // GameOverHeading
            // 
            this.GameOverHeading.AutoSize = true;
            this.GameOverHeading.BackColor = System.Drawing.Color.Transparent;
            this.GameOverHeading.Font = new System.Drawing.Font("MV Boli", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverHeading.ForeColor = System.Drawing.Color.Maroon;
            this.GameOverHeading.Location = new System.Drawing.Point(7, 32);
            this.GameOverHeading.Name = "GameOverHeading";
            this.GameOverHeading.Size = new System.Drawing.Size(253, 55);
            this.GameOverHeading.TabIndex = 0;
            this.GameOverHeading.Text = "Game Over";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.newGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.playToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveGameToolStripMenuItem.Text = "Save Game as...";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadGameToolStripMenuItem.Text = "Open Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TetrisGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(534, 516);
            this.Controls.Add(this.GameOverPanel);
            this.Controls.Add(this.PauseMenu);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TetrisGUI";
            this.Text = "Tetromino Stacker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.PauseMenu.ResumeLayout(false);
            this.PauseMenu.PerformLayout();
            this.GameOverPanel.ResumeLayout(false);
            this.GameOverPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ScoreHeadline;
        private System.Windows.Forms.ToolStripStatusLabel Score;
        private System.Windows.Forms.ToolStripStatusLabel LevelHeadline;
        private System.Windows.Forms.ToolStripStatusLabel Level;
        private System.Windows.Forms.ToolStripStatusLabel LinesHeadline;
        private System.Windows.Forms.ToolStripStatusLabel Lines;
        private System.Windows.Forms.ToolStripStatusLabel PauseBtn;
        private System.Windows.Forms.Panel PauseMenu;
        private System.Windows.Forms.Label PauseHeadline;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel GameOverPanel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Label GameOverHeading;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button LoadgameFromPauseBtn;
        private System.Windows.Forms.Button NewGameFromPauseBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel highScoreHeading;
        private System.Windows.Forms.ToolStripStatusLabel highScore;
        private System.Windows.Forms.ToolStripStatusLabel NextBlockHeadling;
        private System.Windows.Forms.ToolStripStatusLabel NextBlock;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}


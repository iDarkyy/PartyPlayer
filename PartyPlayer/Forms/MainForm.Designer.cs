namespace PartyPlayer.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playbackPanel = new System.Windows.Forms.Panel();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeSlider = new MaterialSkin.Controls.MaterialSlider();
            this.songLengthLabel = new System.Windows.Forms.Label();
            this.songPositionLabel = new System.Windows.Forms.Label();
            this.songPositionSlider = new MaterialSkin.Controls.MaterialSlider();
            this.shuffleButton = new FontAwesome.Sharp.IconButton();
            this.repeatButton = new FontAwesome.Sharp.IconButton();
            this.backwardButton = new FontAwesome.Sharp.IconButton();
            this.forwardButton = new FontAwesome.Sharp.IconButton();
            this.playButton = new FontAwesome.Sharp.IconButton();
            this.songAuthorLabel = new System.Windows.Forms.Label();
            this.songNameLabel = new System.Windows.Forms.Label();
            this.songPictureBox = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.settingsButton = new FontAwesome.Sharp.IconButton();
            this.equalizerButton = new FontAwesome.Sharp.IconButton();
            this.requestsButton = new FontAwesome.Sharp.IconButton();
            this.libraryButton = new FontAwesome.Sharp.IconButton();
            this.queueButton = new FontAwesome.Sharp.IconButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.desktopPanel = new System.Windows.Forms.Panel();
            this.playbackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songPictureBox)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playbackPanel
            // 
            this.playbackPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.playbackPanel.Controls.Add(this.volumeLabel);
            this.playbackPanel.Controls.Add(this.volumeSlider);
            this.playbackPanel.Controls.Add(this.songLengthLabel);
            this.playbackPanel.Controls.Add(this.songPositionLabel);
            this.playbackPanel.Controls.Add(this.songPositionSlider);
            this.playbackPanel.Controls.Add(this.shuffleButton);
            this.playbackPanel.Controls.Add(this.repeatButton);
            this.playbackPanel.Controls.Add(this.backwardButton);
            this.playbackPanel.Controls.Add(this.forwardButton);
            this.playbackPanel.Controls.Add(this.playButton);
            this.playbackPanel.Controls.Add(this.songAuthorLabel);
            this.playbackPanel.Controls.Add(this.songNameLabel);
            this.playbackPanel.Controls.Add(this.songPictureBox);
            this.playbackPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playbackPanel.Location = new System.Drawing.Point(0, 511);
            this.playbackPanel.Name = "playbackPanel";
            this.playbackPanel.Size = new System.Drawing.Size(1184, 150);
            this.playbackPanel.TabIndex = 0;
            // 
            // volumeLabel
            // 
            this.volumeLabel.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.ForeColor = System.Drawing.Color.White;
            this.volumeLabel.Location = new System.Drawing.Point(938, 85);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.volumeLabel.Size = new System.Drawing.Size(87, 40);
            this.volumeLabel.TabIndex = 12;
            this.volumeLabel.Text = "50%";
            this.volumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeSlider
            // 
            this.volumeSlider.Depth = 0;
            this.volumeSlider.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.volumeSlider.ForeColor = System.Drawing.Color.White;
            this.volumeSlider.Location = new System.Drawing.Point(1022, 85);
            this.volumeSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.ShowText = false;
            this.volumeSlider.ShowValue = false;
            this.volumeSlider.Size = new System.Drawing.Size(150, 40);
            this.volumeSlider.TabIndex = 11;
            this.volumeSlider.Text = "";
            this.volumeSlider.ValueSuffix = "%";
            this.volumeSlider.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.volumeSlider_onValueChanged);
            // 
            // songLengthLabel
            // 
            this.songLengthLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLengthLabel.ForeColor = System.Drawing.Color.White;
            this.songLengthLabel.Location = new System.Drawing.Point(823, 85);
            this.songLengthLabel.Name = "songLengthLabel";
            this.songLengthLabel.Size = new System.Drawing.Size(83, 40);
            this.songLengthLabel.TabIndex = 10;
            this.songLengthLabel.Text = "00:00";
            this.songLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // songPositionLabel
            // 
            this.songPositionLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songPositionLabel.ForeColor = System.Drawing.Color.White;
            this.songPositionLabel.Location = new System.Drawing.Point(278, 85);
            this.songPositionLabel.Name = "songPositionLabel";
            this.songPositionLabel.Size = new System.Drawing.Size(83, 40);
            this.songPositionLabel.TabIndex = 9;
            this.songPositionLabel.Text = "00:00";
            this.songPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songPositionSlider
            // 
            this.songPositionSlider.Depth = 0;
            this.songPositionSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.songPositionSlider.Location = new System.Drawing.Point(367, 85);
            this.songPositionSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.songPositionSlider.Name = "songPositionSlider";
            this.songPositionSlider.ShowText = false;
            this.songPositionSlider.ShowValue = false;
            this.songPositionSlider.Size = new System.Drawing.Size(450, 40);
            this.songPositionSlider.TabIndex = 8;
            this.songPositionSlider.Text = "materialSlider1";
            this.songPositionSlider.Value = 0;
            this.songPositionSlider.ValueMax = 100;
            // 
            // shuffleButton
            // 
            this.shuffleButton.FlatAppearance.BorderSize = 0;
            this.shuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffleButton.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            this.shuffleButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.shuffleButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.shuffleButton.IconSize = 35;
            this.shuffleButton.Location = new System.Drawing.Point(455, 25);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(50, 50);
            this.shuffleButton.TabIndex = 7;
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.FlatAppearance.BorderSize = 0;
            this.repeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repeatButton.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.repeatButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.repeatButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.repeatButton.IconSize = 35;
            this.repeatButton.Location = new System.Drawing.Point(679, 25);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(50, 50);
            this.repeatButton.TabIndex = 6;
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.FlatAppearance.BorderSize = 0;
            this.backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backwardButton.IconChar = FontAwesome.Sharp.IconChar.Backward;
            this.backwardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.backwardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.backwardButton.IconSize = 35;
            this.backwardButton.Location = new System.Drawing.Point(511, 25);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(50, 50);
            this.backwardButton.TabIndex = 5;
            this.backwardButton.UseVisualStyleBackColor = true;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.forwardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.forwardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.forwardButton.IconSize = 35;
            this.forwardButton.Location = new System.Drawing.Point(623, 25);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(50, 50);
            this.forwardButton.TabIndex = 4;
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // playButton
            // 
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.playButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.playButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.playButton.IconSize = 40;
            this.playButton.Location = new System.Drawing.Point(567, 25);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(50, 50);
            this.playButton.TabIndex = 3;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // songAuthorLabel
            // 
            this.songAuthorLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.songAuthorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.songAuthorLabel.Location = new System.Drawing.Point(118, 75);
            this.songAuthorLabel.Name = "songAuthorLabel";
            this.songAuthorLabel.Size = new System.Drawing.Size(167, 50);
            this.songAuthorLabel.TabIndex = 2;
            this.songAuthorLabel.Text = "Author";
            // 
            // songNameLabel
            // 
            this.songNameLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.songNameLabel.Location = new System.Drawing.Point(118, 25);
            this.songNameLabel.Name = "songNameLabel";
            this.songNameLabel.Size = new System.Drawing.Size(167, 50);
            this.songNameLabel.TabIndex = 1;
            this.songNameLabel.Text = "Song name";
            this.songNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // songPictureBox
            // 
            this.songPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songPictureBox.Location = new System.Drawing.Point(12, 25);
            this.songPictureBox.Name = "songPictureBox";
            this.songPictureBox.Size = new System.Drawing.Size(100, 100);
            this.songPictureBox.TabIndex = 0;
            this.songPictureBox.TabStop = false;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.menuPanel.Controls.Add(this.settingsButton);
            this.menuPanel.Controls.Add(this.equalizerButton);
            this.menuPanel.Controls.Add(this.requestsButton);
            this.menuPanel.Controls.Add(this.libraryButton);
            this.menuPanel.Controls.Add(this.queueButton);
            this.menuPanel.Controls.Add(this.logoPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 511);
            this.menuPanel.TabIndex = 1;
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold);
            this.settingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.settingsButton.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.settingsButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.settingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(0, 376);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(200, 60);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // equalizerButton
            // 
            this.equalizerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.equalizerButton.FlatAppearance.BorderSize = 0;
            this.equalizerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.equalizerButton.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold);
            this.equalizerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.equalizerButton.IconChar = FontAwesome.Sharp.IconChar.SlidersH;
            this.equalizerButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.equalizerButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.equalizerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.equalizerButton.Location = new System.Drawing.Point(0, 316);
            this.equalizerButton.Name = "equalizerButton";
            this.equalizerButton.Size = new System.Drawing.Size(200, 60);
            this.equalizerButton.TabIndex = 4;
            this.equalizerButton.Text = "Equalizer";
            this.equalizerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.equalizerButton.UseVisualStyleBackColor = true;
            this.equalizerButton.Click += new System.EventHandler(this.equalizerButton_Click);
            // 
            // requestsButton
            // 
            this.requestsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.requestsButton.FlatAppearance.BorderSize = 0;
            this.requestsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.requestsButton.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold);
            this.requestsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.requestsButton.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            this.requestsButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.requestsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.requestsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.requestsButton.Location = new System.Drawing.Point(0, 256);
            this.requestsButton.Name = "requestsButton";
            this.requestsButton.Size = new System.Drawing.Size(200, 60);
            this.requestsButton.TabIndex = 3;
            this.requestsButton.Text = "Song requests";
            this.requestsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.requestsButton.UseVisualStyleBackColor = true;
            this.requestsButton.Click += new System.EventHandler(this.requestsButton_Click);
            // 
            // libraryButton
            // 
            this.libraryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.libraryButton.FlatAppearance.BorderSize = 0;
            this.libraryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.libraryButton.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold);
            this.libraryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.libraryButton.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.libraryButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.libraryButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.libraryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.libraryButton.Location = new System.Drawing.Point(0, 196);
            this.libraryButton.Name = "libraryButton";
            this.libraryButton.Size = new System.Drawing.Size(200, 60);
            this.libraryButton.TabIndex = 2;
            this.libraryButton.Text = "Library";
            this.libraryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.libraryButton.UseVisualStyleBackColor = true;
            this.libraryButton.Click += new System.EventHandler(this.libraryButton_Click);
            // 
            // queueButton
            // 
            this.queueButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.queueButton.FlatAppearance.BorderSize = 0;
            this.queueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queueButton.Font = new System.Drawing.Font("Quicksand Medium", 12F, System.Drawing.FontStyle.Bold);
            this.queueButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.queueButton.IconChar = FontAwesome.Sharp.IconChar.List12;
            this.queueButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.queueButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.queueButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queueButton.Location = new System.Drawing.Point(0, 136);
            this.queueButton.Name = "queueButton";
            this.queueButton.Size = new System.Drawing.Size(200, 60);
            this.queueButton.TabIndex = 1;
            this.queueButton.Text = "Queue";
            this.queueButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.queueButton.UseVisualStyleBackColor = true;
            this.queueButton.Click += new System.EventHandler(this.queueButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPanel.BackgroundImage")));
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(200, 136);
            this.logoPanel.TabIndex = 0;
            // 
            // desktopPanel
            // 
            this.desktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopPanel.Location = new System.Drawing.Point(200, 0);
            this.desktopPanel.Name = "desktopPanel";
            this.desktopPanel.Size = new System.Drawing.Size(984, 511);
            this.desktopPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.desktopPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.playbackPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.Text = "PartyPlayer BETA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.playbackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songPictureBox)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label volumeLabel;

        private MaterialSkin.Controls.MaterialSlider volumeSlider;

        private System.Windows.Forms.Label songLengthLabel;

        private System.Windows.Forms.Label songPositionLabel;

        private MaterialSkin.Controls.MaterialSlider songPositionSlider;

        private FontAwesome.Sharp.IconButton repeatButton;
        private FontAwesome.Sharp.IconButton shuffleButton;

        private FontAwesome.Sharp.IconButton forwardButton;
        private FontAwesome.Sharp.IconButton backwardButton;

        private FontAwesome.Sharp.IconButton playButton;

        private System.Windows.Forms.Label songNameLabel;
        private System.Windows.Forms.Label songAuthorLabel;

        private FontAwesome.Sharp.IconButton settingsButton;

        private System.Windows.Forms.PictureBox songPictureBox;

        private FontAwesome.Sharp.IconButton equalizerButton;

        private FontAwesome.Sharp.IconButton requestsButton;

        private FontAwesome.Sharp.IconButton libraryButton;

        private FontAwesome.Sharp.IconButton queueButton;

        private System.Windows.Forms.Panel desktopPanel;

        private System.Windows.Forms.Panel logoPanel;

        private System.Windows.Forms.Panel menuPanel;

        private System.Windows.Forms.Panel playbackPanel;

        #endregion
    }
}
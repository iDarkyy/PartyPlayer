using System.ComponentModel;

namespace PartyPlayer.Forms;

partial class LibraryForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.components = new System.ComponentModel.Container();
        System.Windows.Forms.Label songsTitleLabel;
        System.Windows.Forms.Label directoriesTitleLabel;
        this.songsListBox = new System.Windows.Forms.ListBox();
        this.directoriesListBox = new System.Windows.Forms.ListBox();
        this.playNowButton = new System.Windows.Forms.Button();
        this.playNextButton = new System.Windows.Forms.Button();
        this.enqueueButton = new System.Windows.Forms.Button();
        this.refreshSongsButton = new System.Windows.Forms.Button();
        this.addDirectoryButton = new System.Windows.Forms.Button();
        this.removeDirectoryButton = new System.Windows.Forms.Button();
        this.songsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.directoriesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.playNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.playNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.enqueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.refreshSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        songsTitleLabel = new System.Windows.Forms.Label();
        directoriesTitleLabel = new System.Windows.Forms.Label();
        this.songsContextMenu.SuspendLayout();
        this.directoriesContextMenu.SuspendLayout();
        this.SuspendLayout();
        // 
        // songsTitleLabel
        // 
        songsTitleLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 15.75F, System.Drawing.FontStyle.Bold);
        songsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
        songsTitleLabel.Location = new System.Drawing.Point(12, 25);
        songsTitleLabel.Name = "songsTitleLabel";
        songsTitleLabel.Size = new System.Drawing.Size(540, 32);
        songsTitleLabel.TabIndex = 2;
        songsTitleLabel.Text = "Songs";
        songsTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // directoriesTitleLabel
        // 
        directoriesTitleLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 15.75F, System.Drawing.FontStyle.Bold);
        directoriesTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
        directoriesTitleLabel.Location = new System.Drawing.Point(580, 25);
        directoriesTitleLabel.Name = "directoriesTitleLabel";
        directoriesTitleLabel.Size = new System.Drawing.Size(392, 32);
        directoriesTitleLabel.TabIndex = 3;
        directoriesTitleLabel.Text = "Directories";
        directoriesTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // songsListBox
        // 
        this.songsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.songsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.songsListBox.ContextMenuStrip = this.songsContextMenu;
        this.songsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.songsListBox.FormattingEnabled = true;
        this.songsListBox.ItemHeight = 40;
        this.songsListBox.Location = new System.Drawing.Point(12, 80);
        this.songsListBox.Name = "songsListBox";
        this.songsListBox.Size = new System.Drawing.Size(540, 360);
        this.songsListBox.TabIndex = 0;
        this.songsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.songsListBox_DrawItem);
        this.songsListBox.DoubleClick += new System.EventHandler(this.songsListBox_DoubleClick);
        this.songsListBox.Validated += new System.EventHandler(this.UnfocusHandler);
        // 
        // directoriesListBox
        // 
        this.directoriesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.directoriesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.directoriesListBox.ContextMenuStrip = this.directoriesContextMenu;
        this.directoriesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.directoriesListBox.FormattingEnabled = true;
        this.directoriesListBox.ItemHeight = 20;
        this.directoriesListBox.Location = new System.Drawing.Point(580, 60);
        this.directoriesListBox.Name = "directoriesListBox";
        this.directoriesListBox.Size = new System.Drawing.Size(392, 380);
        this.directoriesListBox.TabIndex = 1;
        this.directoriesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.directoriesListBox_DrawItem);
        this.directoriesListBox.Validated += new System.EventHandler(this.UnfocusHandler);
        // 
        // playNowButton
        // 
        this.playNowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.playNowButton.FlatAppearance.BorderSize = 0;
        this.playNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playNowButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.playNowButton.ForeColor = System.Drawing.Color.White;
        this.playNowButton.Location = new System.Drawing.Point(12, 446);
        this.playNowButton.Name = "playNowButton";
        this.playNowButton.Size = new System.Drawing.Size(100, 30);
        this.playNowButton.TabIndex = 4;
        this.playNowButton.Text = "Play now";
        this.playNowButton.UseVisualStyleBackColor = false;
        this.playNowButton.Click += new System.EventHandler(this.PlayNowAction);
        // 
        // playNextButton
        // 
        this.playNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.playNextButton.FlatAppearance.BorderSize = 0;
        this.playNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playNextButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.playNextButton.ForeColor = System.Drawing.Color.White;
        this.playNextButton.Location = new System.Drawing.Point(118, 446);
        this.playNextButton.Name = "playNextButton";
        this.playNextButton.Size = new System.Drawing.Size(100, 30);
        this.playNextButton.TabIndex = 5;
        this.playNextButton.Text = "Play next";
        this.playNextButton.UseVisualStyleBackColor = false;
        this.playNextButton.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // enqueueButton
        // 
        this.enqueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.enqueueButton.FlatAppearance.BorderSize = 0;
        this.enqueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.enqueueButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.enqueueButton.ForeColor = System.Drawing.Color.White;
        this.enqueueButton.Location = new System.Drawing.Point(224, 446);
        this.enqueueButton.Name = "enqueueButton";
        this.enqueueButton.Size = new System.Drawing.Size(100, 30);
        this.enqueueButton.TabIndex = 6;
        this.enqueueButton.Text = "Enqueue";
        this.enqueueButton.UseVisualStyleBackColor = false;
        this.enqueueButton.Click += new System.EventHandler(this.EnqueueAction);
        // 
        // refreshSongsButton
        // 
        this.refreshSongsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
        this.refreshSongsButton.FlatAppearance.BorderSize = 0;
        this.refreshSongsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.refreshSongsButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.refreshSongsButton.ForeColor = System.Drawing.Color.White;
        this.refreshSongsButton.Location = new System.Drawing.Point(452, 446);
        this.refreshSongsButton.Name = "refreshSongsButton";
        this.refreshSongsButton.Size = new System.Drawing.Size(100, 30);
        this.refreshSongsButton.TabIndex = 7;
        this.refreshSongsButton.Text = "Refresh";
        this.refreshSongsButton.UseVisualStyleBackColor = false;
        this.refreshSongsButton.Click += new System.EventHandler(this.RefreshSongsAction);
        // 
        // addDirectoryButton
        // 
        this.addDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.addDirectoryButton.FlatAppearance.BorderSize = 0;
        this.addDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.addDirectoryButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.addDirectoryButton.ForeColor = System.Drawing.Color.White;
        this.addDirectoryButton.Location = new System.Drawing.Point(580, 446);
        this.addDirectoryButton.Name = "addDirectoryButton";
        this.addDirectoryButton.Size = new System.Drawing.Size(100, 30);
        this.addDirectoryButton.TabIndex = 8;
        this.addDirectoryButton.Text = "Add";
        this.addDirectoryButton.UseVisualStyleBackColor = false;
        this.addDirectoryButton.Click += new System.EventHandler(this.AddDirectoryAction);
        // 
        // removeDirectoryButton
        // 
        this.removeDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.removeDirectoryButton.FlatAppearance.BorderSize = 0;
        this.removeDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.removeDirectoryButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.removeDirectoryButton.ForeColor = System.Drawing.Color.White;
        this.removeDirectoryButton.Location = new System.Drawing.Point(872, 446);
        this.removeDirectoryButton.Name = "removeDirectoryButton";
        this.removeDirectoryButton.Size = new System.Drawing.Size(100, 30);
        this.removeDirectoryButton.TabIndex = 9;
        this.removeDirectoryButton.Text = "Remove";
        this.removeDirectoryButton.UseVisualStyleBackColor = false;
        this.removeDirectoryButton.Click += new System.EventHandler(this.RemoveDirectoryAction);
        // 
        // songsContextMenu
        // 
        this.songsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.playNowToolStripMenuItem, this.playNextToolStripMenuItem, this.enqueueToolStripMenuItem, this.refreshSongsToolStripMenuItem });
        this.songsContextMenu.Name = "songsContextMenu";
        this.songsContextMenu.Size = new System.Drawing.Size(148, 92);
        // 
        // directoriesContextMenu
        // 
        this.directoriesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addToolStripMenuItem, this.removeSelectedToolStripMenuItem });
        this.directoriesContextMenu.Name = "directoriesContextMenu";
        this.directoriesContextMenu.Size = new System.Drawing.Size(164, 48);
        // 
        // playNowToolStripMenuItem
        // 
        this.playNowToolStripMenuItem.Name = "playNowToolStripMenuItem";
        this.playNowToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
        this.playNowToolStripMenuItem.Text = "Play now";
        this.playNowToolStripMenuItem.Click += new System.EventHandler(this.PlayNowAction);
        // 
        // playNextToolStripMenuItem
        // 
        this.playNextToolStripMenuItem.Name = "playNextToolStripMenuItem";
        this.playNextToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
        this.playNextToolStripMenuItem.Text = "Play next";
        this.playNextToolStripMenuItem.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // enqueueToolStripMenuItem
        // 
        this.enqueueToolStripMenuItem.Name = "enqueueToolStripMenuItem";
        this.enqueueToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
        this.enqueueToolStripMenuItem.Text = "Enqueue";
        this.enqueueToolStripMenuItem.Click += new System.EventHandler(this.EnqueueAction);
        // 
        // refreshSongsToolStripMenuItem
        // 
        this.refreshSongsToolStripMenuItem.Name = "refreshSongsToolStripMenuItem";
        this.refreshSongsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
        this.refreshSongsToolStripMenuItem.Text = "Refresh songs";
        this.refreshSongsToolStripMenuItem.Click += new System.EventHandler(this.RefreshSongsAction);
        // 
        // addToolStripMenuItem
        // 
        this.addToolStripMenuItem.Name = "addToolStripMenuItem";
        this.addToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
        this.addToolStripMenuItem.Text = "Add";
        this.addToolStripMenuItem.Click += new System.EventHandler(this.AddDirectoryAction);
        // 
        // removeSelectedToolStripMenuItem
        // 
        this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
        this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
        this.removeSelectedToolStripMenuItem.Text = "Remove selected";
        this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.RemoveDirectoryAction);
        // 
        // LibraryForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.ClientSize = new System.Drawing.Size(984, 511);
        this.Controls.Add(this.removeDirectoryButton);
        this.Controls.Add(this.addDirectoryButton);
        this.Controls.Add(this.refreshSongsButton);
        this.Controls.Add(this.enqueueButton);
        this.Controls.Add(this.playNextButton);
        this.Controls.Add(this.playNowButton);
        this.Controls.Add(directoriesTitleLabel);
        this.Controls.Add(songsTitleLabel);
        this.Controls.Add(this.directoriesListBox);
        this.Controls.Add(this.songsListBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "LibraryForm";
        this.Text = "LibraryForm";
        this.Load += new System.EventHandler(this.LibraryForm_Load);
        this.songsContextMenu.ResumeLayout(false);
        this.directoriesContextMenu.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;

    private System.Windows.Forms.ContextMenuStrip songsContextMenu;
    private System.Windows.Forms.ContextMenuStrip directoriesContextMenu;
    private System.Windows.Forms.ToolStripMenuItem playNowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playNextToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enqueueToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem refreshSongsToolStripMenuItem;

    private System.Windows.Forms.Button enqueueButton;
    private System.Windows.Forms.Button refreshSongsButton;
    private System.Windows.Forms.Button playNextButton;

    private System.Windows.Forms.Button addDirectoryButton;
    private System.Windows.Forms.Button removeDirectoryButton;

    private System.Windows.Forms.Button playNowButton;

    private System.Windows.Forms.ListBox directoriesListBox;

    private System.Windows.Forms.ListBox songsListBox;

    #endregion
}
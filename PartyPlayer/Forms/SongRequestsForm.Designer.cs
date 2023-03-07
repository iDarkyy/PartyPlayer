using System.ComponentModel;

namespace PartyPlayer.Forms;

partial class SongRequestsForm
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
        System.Windows.Forms.GroupBox groupBox1;
        System.Windows.Forms.Label titleLabel;
        System.Windows.Forms.Label titleLabel2;
        this.addToSongGroupBox = new System.Windows.Forms.GroupBox();
        this.autoFrontRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
        this.autoEndRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
        this.autoAcceptSwitch = new MaterialSkin.Controls.MaterialSwitch();
        this.requestsListBox = new System.Windows.Forms.ListBox();
        this.songRequestsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.playNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.playNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.enqueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeButton = new System.Windows.Forms.Button();
        this.playNextButton = new System.Windows.Forms.Button();
        this.playNowButton = new System.Windows.Forms.Button();
        this.clearButton = new System.Windows.Forms.Button();
        this.enqueueButton = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        groupBox1 = new System.Windows.Forms.GroupBox();
        titleLabel = new System.Windows.Forms.Label();
        titleLabel2 = new System.Windows.Forms.Label();
        groupBox1.SuspendLayout();
        this.addToSongGroupBox.SuspendLayout();
        this.songRequestsContextMenu.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(this.addToSongGroupBox);
        groupBox1.Controls.Add(this.autoAcceptSwitch);
        groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        groupBox1.Location = new System.Drawing.Point(642, 75);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(330, 126);
        groupBox1.TabIndex = 7;
        groupBox1.TabStop = false;
        groupBox1.Text = "Automation";
        // 
        // addToSongGroupBox
        // 
        this.addToSongGroupBox.Controls.Add(this.autoFrontRadioButton);
        this.addToSongGroupBox.Controls.Add(this.autoEndRadioButton);
        this.addToSongGroupBox.Location = new System.Drawing.Point(6, 49);
        this.addToSongGroupBox.Name = "addToSongGroupBox";
        this.addToSongGroupBox.Size = new System.Drawing.Size(318, 70);
        this.addToSongGroupBox.TabIndex = 4;
        this.addToSongGroupBox.TabStop = false;
        this.addToSongGroupBox.Text = "Add song to";
        // 
        // autoFrontRadioButton
        // 
        this.autoFrontRadioButton.Depth = 0;
        this.autoFrontRadioButton.Location = new System.Drawing.Point(3, 16);
        this.autoFrontRadioButton.Margin = new System.Windows.Forms.Padding(0);
        this.autoFrontRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
        this.autoFrontRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
        this.autoFrontRadioButton.Name = "autoFrontRadioButton";
        this.autoFrontRadioButton.Ripple = true;
        this.autoFrontRadioButton.Size = new System.Drawing.Size(241, 24);
        this.autoFrontRadioButton.TabIndex = 6;
        this.autoFrontRadioButton.TabStop = true;
        this.autoFrontRadioButton.Text = "Front";
        this.autoFrontRadioButton.UseVisualStyleBackColor = true;
        this.autoFrontRadioButton.CheckedChanged += new System.EventHandler(this.autoFrontRadioButton_CheckedChanged);
        // 
        // autoEndRadioButton
        // 
        this.autoEndRadioButton.Checked = true;
        this.autoEndRadioButton.Depth = 0;
        this.autoEndRadioButton.Location = new System.Drawing.Point(3, 40);
        this.autoEndRadioButton.Margin = new System.Windows.Forms.Padding(0);
        this.autoEndRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
        this.autoEndRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
        this.autoEndRadioButton.Name = "autoEndRadioButton";
        this.autoEndRadioButton.Ripple = true;
        this.autoEndRadioButton.Size = new System.Drawing.Size(241, 24);
        this.autoEndRadioButton.TabIndex = 2;
        this.autoEndRadioButton.TabStop = true;
        this.autoEndRadioButton.Text = "End";
        this.autoEndRadioButton.UseVisualStyleBackColor = true;
        this.autoEndRadioButton.CheckedChanged += new System.EventHandler(this.autoEndRadioButton_CheckedChanged);
        // 
        // autoAcceptSwitch
        // 
        this.autoAcceptSwitch.Depth = 0;
        this.autoAcceptSwitch.Location = new System.Drawing.Point(3, 16);
        this.autoAcceptSwitch.Margin = new System.Windows.Forms.Padding(0);
        this.autoAcceptSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
        this.autoAcceptSwitch.MouseState = MaterialSkin.MouseState.HOVER;
        this.autoAcceptSwitch.Name = "autoAcceptSwitch";
        this.autoAcceptSwitch.Ripple = true;
        this.autoAcceptSwitch.Size = new System.Drawing.Size(276, 30);
        this.autoAcceptSwitch.TabIndex = 3;
        this.autoAcceptSwitch.Text = "Automatically accept songs";
        this.autoAcceptSwitch.UseVisualStyleBackColor = true;
        this.autoAcceptSwitch.CheckedChanged += new System.EventHandler(this.autoAcceptSwitch_CheckedChanged);
        // 
        // titleLabel
        // 
        titleLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
        titleLabel.Location = new System.Drawing.Point(12, 32);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(624, 40);
        titleLabel.TabIndex = 8;
        titleLabel.Text = "Song requests";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // titleLabel2
        // 
        titleLabel2.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        titleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
        titleLabel2.Location = new System.Drawing.Point(642, 32);
        titleLabel2.Name = "titleLabel2";
        titleLabel2.Size = new System.Drawing.Size(330, 40);
        titleLabel2.TabIndex = 9;
        titleLabel2.Text = "Settings";
        titleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // requestsListBox
        // 
        this.requestsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.requestsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.requestsListBox.ContextMenuStrip = this.songRequestsContextMenu;
        this.requestsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.requestsListBox.ItemHeight = 40;
        this.requestsListBox.Location = new System.Drawing.Point(12, 75);
        this.requestsListBox.Name = "requestsListBox";
        this.requestsListBox.Size = new System.Drawing.Size(624, 360);
        this.requestsListBox.TabIndex = 1;
        this.requestsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.queueListBox_DrawItem);
        // 
        // songRequestsContextMenu
        // 
        this.songRequestsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.playNowToolStripMenuItem, this.playNextToolStripMenuItem, this.enqueueToolStripMenuItem, this.removeToolStripMenuItem, this.clearToolStripMenuItem });
        this.songRequestsContextMenu.Name = "songRequestsContextMenu";
        this.songRequestsContextMenu.Size = new System.Drawing.Size(123, 114);
        // 
        // playNowToolStripMenuItem
        // 
        this.playNowToolStripMenuItem.Name = "playNowToolStripMenuItem";
        this.playNowToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        this.playNowToolStripMenuItem.Text = "Play now";
        this.playNowToolStripMenuItem.Click += new System.EventHandler(this.PlayNowAction);
        // 
        // playNextToolStripMenuItem
        // 
        this.playNextToolStripMenuItem.Name = "playNextToolStripMenuItem";
        this.playNextToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        this.playNextToolStripMenuItem.Text = "Play next";
        this.playNextToolStripMenuItem.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // enqueueToolStripMenuItem
        // 
        this.enqueueToolStripMenuItem.Name = "enqueueToolStripMenuItem";
        this.enqueueToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        this.enqueueToolStripMenuItem.Text = "Enqueue";
        this.enqueueToolStripMenuItem.Click += new System.EventHandler(this.EnqueueAction);
        // 
        // removeToolStripMenuItem
        // 
        this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
        this.removeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        this.removeToolStripMenuItem.Text = "Remove";
        this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveAction);
        // 
        // clearToolStripMenuItem
        // 
        this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
        this.clearToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        this.clearToolStripMenuItem.Text = "Clear";
        this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearAction);
        // 
        // removeButton
        // 
        this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.removeButton.FlatAppearance.BorderSize = 0;
        this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.removeButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.removeButton.ForeColor = System.Drawing.Color.White;
        this.removeButton.Location = new System.Drawing.Point(330, 441);
        this.removeButton.Name = "removeButton";
        this.removeButton.Size = new System.Drawing.Size(100, 30);
        this.removeButton.TabIndex = 12;
        this.removeButton.Text = "Remove";
        this.removeButton.UseVisualStyleBackColor = false;
        this.removeButton.Click += new System.EventHandler(this.RemoveAction);
        // 
        // playNextButton
        // 
        this.playNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.playNextButton.FlatAppearance.BorderSize = 0;
        this.playNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playNextButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.playNextButton.ForeColor = System.Drawing.Color.White;
        this.playNextButton.Location = new System.Drawing.Point(118, 441);
        this.playNextButton.Name = "playNextButton";
        this.playNextButton.Size = new System.Drawing.Size(100, 30);
        this.playNextButton.TabIndex = 11;
        this.playNextButton.Text = "Play next";
        this.playNextButton.UseVisualStyleBackColor = false;
        this.playNextButton.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // playNowButton
        // 
        this.playNowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.playNowButton.FlatAppearance.BorderSize = 0;
        this.playNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playNowButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.playNowButton.ForeColor = System.Drawing.Color.White;
        this.playNowButton.Location = new System.Drawing.Point(12, 441);
        this.playNowButton.Name = "playNowButton";
        this.playNowButton.Size = new System.Drawing.Size(100, 30);
        this.playNowButton.TabIndex = 10;
        this.playNowButton.Text = "Play now";
        this.playNowButton.UseVisualStyleBackColor = false;
        this.playNowButton.Click += new System.EventHandler(this.PlayNowAction);
        // 
        // clearButton
        // 
        this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.clearButton.FlatAppearance.BorderSize = 0;
        this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.clearButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.clearButton.ForeColor = System.Drawing.Color.White;
        this.clearButton.Location = new System.Drawing.Point(536, 441);
        this.clearButton.Name = "clearButton";
        this.clearButton.Size = new System.Drawing.Size(100, 30);
        this.clearButton.TabIndex = 13;
        this.clearButton.Text = "Clear";
        this.clearButton.UseVisualStyleBackColor = false;
        this.clearButton.Click += new System.EventHandler(this.ClearAction);
        // 
        // enqueueButton
        // 
        this.enqueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.enqueueButton.FlatAppearance.BorderSize = 0;
        this.enqueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.enqueueButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.enqueueButton.ForeColor = System.Drawing.Color.White;
        this.enqueueButton.Location = new System.Drawing.Point(224, 441);
        this.enqueueButton.Name = "enqueueButton";
        this.enqueueButton.Size = new System.Drawing.Size(100, 30);
        this.enqueueButton.TabIndex = 14;
        this.enqueueButton.Text = "Enqueue";
        this.enqueueButton.UseVisualStyleBackColor = false;
        this.enqueueButton.Click += new System.EventHandler(this.EnqueueAction);
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(692, 296);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 15;
        this.button1.Text = "button1";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // SongRequestsForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.ClientSize = new System.Drawing.Size(984, 511);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.enqueueButton);
        this.Controls.Add(this.clearButton);
        this.Controls.Add(this.removeButton);
        this.Controls.Add(this.playNextButton);
        this.Controls.Add(this.playNowButton);
        this.Controls.Add(titleLabel2);
        this.Controls.Add(titleLabel);
        this.Controls.Add(groupBox1);
        this.Controls.Add(this.requestsListBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "SongRequestsForm";
        this.Text = "SongRequestsForm";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongRequestsForm_FormClosing);
        this.Load += new System.EventHandler(this.SongRequestsForm_Load);
        groupBox1.ResumeLayout(false);
        this.addToSongGroupBox.ResumeLayout(false);
        this.songRequestsContextMenu.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.ContextMenuStrip songRequestsContextMenu;
    private System.Windows.Forms.ToolStripMenuItem playNowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playNextToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enqueueToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;

    private System.Windows.Forms.Button enqueueButton;

    private System.Windows.Forms.Button removeButton;
    private System.Windows.Forms.Button playNextButton;
    private System.Windows.Forms.Button playNowButton;
    private System.Windows.Forms.Button clearButton;

    private System.Windows.Forms.GroupBox addToSongGroupBox;

    private MaterialSkin.Controls.MaterialRadioButton autoEndRadioButton;
    private MaterialSkin.Controls.MaterialRadioButton autoFrontRadioButton;

    public System.Windows.Forms.ListBox requestsListBox;
    private MaterialSkin.Controls.MaterialSwitch autoAcceptSwitch;

    #endregion
}
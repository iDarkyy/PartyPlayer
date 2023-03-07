using System.ComponentModel;

namespace PartyPlayer.Forms;

partial class QueueForm
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
        System.Windows.Forms.Label titleLabel;
        this.queueListBox = new System.Windows.Forms.ListBox();
        this.queueContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.playNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.playNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.playNowButton = new System.Windows.Forms.Button();
        this.playNextButton = new System.Windows.Forms.Button();
        this.removeButton = new System.Windows.Forms.Button();
        this.moveUpButton = new FontAwesome.Sharp.IconButton();
        this.moveDownButton = new FontAwesome.Sharp.IconButton();
        this.clearButton = new System.Windows.Forms.Button();
        titleLabel = new System.Windows.Forms.Label();
        this.queueContextMenu.SuspendLayout();
        this.SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.Font = new System.Drawing.Font("Quicksand SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
        titleLabel.Location = new System.Drawing.Point(12, 17);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(960, 40);
        titleLabel.TabIndex = 1;
        titleLabel.Text = "Queue";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // queueListBox
        // 
        this.queueListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
        this.queueListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.queueListBox.ContextMenuStrip = this.queueContextMenu;
        this.queueListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.queueListBox.ItemHeight = 40;
        this.queueListBox.Location = new System.Drawing.Point(12, 60);
        this.queueListBox.Name = "queueListBox";
        this.queueListBox.Size = new System.Drawing.Size(960, 360);
        this.queueListBox.TabIndex = 0;
        this.queueListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.queueListBox_DrawItem);
        // 
        // queueContextMenu
        // 
        this.queueContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.playNowToolStripMenuItem, this.playNextToolStripMenuItem, this.removeToolStripMenuItem, this.moveUpToolStripMenuItem, this.moveDownToolStripMenuItem, this.clearToolStripMenuItem });
        this.queueContextMenu.Name = "queueContextMenu";
        this.queueContextMenu.Size = new System.Drawing.Size(138, 136);
        // 
        // playNowToolStripMenuItem
        // 
        this.playNowToolStripMenuItem.Name = "playNowToolStripMenuItem";
        this.playNowToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.playNowToolStripMenuItem.Text = "Play now";
        this.playNowToolStripMenuItem.Click += new System.EventHandler(this.PlayNowAction);
        // 
        // playNextToolStripMenuItem
        // 
        this.playNextToolStripMenuItem.Name = "playNextToolStripMenuItem";
        this.playNextToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.playNextToolStripMenuItem.Text = "Play next";
        this.playNextToolStripMenuItem.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // removeToolStripMenuItem
        // 
        this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
        this.removeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.removeToolStripMenuItem.Text = "Remove";
        this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveAction);
        // 
        // moveUpToolStripMenuItem
        // 
        this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
        this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.moveUpToolStripMenuItem.Text = "Move up";
        this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.MoveUpAction);
        // 
        // moveDownToolStripMenuItem
        // 
        this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
        this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.moveDownToolStripMenuItem.Text = "Move down";
        this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.MoveDownAction);
        // 
        // clearToolStripMenuItem
        // 
        this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
        this.clearToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        this.clearToolStripMenuItem.Text = "Clear ";
        this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearAction);
        // 
        // playNowButton
        // 
        this.playNowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.playNowButton.FlatAppearance.BorderSize = 0;
        this.playNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playNowButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.playNowButton.ForeColor = System.Drawing.Color.White;
        this.playNowButton.Location = new System.Drawing.Point(12, 426);
        this.playNowButton.Name = "playNowButton";
        this.playNowButton.Size = new System.Drawing.Size(100, 30);
        this.playNowButton.TabIndex = 5;
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
        this.playNextButton.Location = new System.Drawing.Point(118, 426);
        this.playNextButton.Name = "playNextButton";
        this.playNextButton.Size = new System.Drawing.Size(100, 30);
        this.playNextButton.TabIndex = 6;
        this.playNextButton.Text = "Play next";
        this.playNextButton.UseVisualStyleBackColor = false;
        this.playNextButton.Click += new System.EventHandler(this.PlayNextAction);
        // 
        // removeButton
        // 
        this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.removeButton.FlatAppearance.BorderSize = 0;
        this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.removeButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.removeButton.ForeColor = System.Drawing.Color.White;
        this.removeButton.Location = new System.Drawing.Point(224, 426);
        this.removeButton.Name = "removeButton";
        this.removeButton.Size = new System.Drawing.Size(100, 30);
        this.removeButton.TabIndex = 7;
        this.removeButton.Text = "Remove";
        this.removeButton.UseVisualStyleBackColor = false;
        this.removeButton.Click += new System.EventHandler(this.RemoveAction);
        // 
        // moveUpButton
        // 
        this.moveUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.moveUpButton.FlatAppearance.BorderSize = 0;
        this.moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.moveUpButton.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
        this.moveUpButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
        this.moveUpButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        this.moveUpButton.IconSize = 30;
        this.moveUpButton.Location = new System.Drawing.Point(330, 427);
        this.moveUpButton.Name = "moveUpButton";
        this.moveUpButton.Size = new System.Drawing.Size(30, 30);
        this.moveUpButton.TabIndex = 9;
        this.moveUpButton.UseVisualStyleBackColor = false;
        this.moveUpButton.Click += new System.EventHandler(this.MoveUpAction);
        // 
        // moveDownButton
        // 
        this.moveDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.moveDownButton.FlatAppearance.BorderSize = 0;
        this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.moveDownButton.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
        this.moveDownButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
        this.moveDownButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        this.moveDownButton.IconSize = 30;
        this.moveDownButton.Location = new System.Drawing.Point(366, 427);
        this.moveDownButton.Name = "moveDownButton";
        this.moveDownButton.Size = new System.Drawing.Size(30, 30);
        this.moveDownButton.TabIndex = 10;
        this.moveDownButton.UseVisualStyleBackColor = false;
        this.moveDownButton.Click += new System.EventHandler(this.MoveDownAction);
        // 
        // clearButton
        // 
        this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        this.clearButton.FlatAppearance.BorderSize = 0;
        this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.clearButton.Font = new System.Drawing.Font("Quicksand Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.clearButton.ForeColor = System.Drawing.Color.White;
        this.clearButton.Location = new System.Drawing.Point(872, 427);
        this.clearButton.Name = "clearButton";
        this.clearButton.Size = new System.Drawing.Size(100, 30);
        this.clearButton.TabIndex = 11;
        this.clearButton.Text = "Clear";
        this.clearButton.UseVisualStyleBackColor = false;
        this.clearButton.Click += new System.EventHandler(this.ClearAction);
        // 
        // QueueForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.ClientSize = new System.Drawing.Size(984, 511);
        this.Controls.Add(this.clearButton);
        this.Controls.Add(this.moveDownButton);
        this.Controls.Add(this.moveUpButton);
        this.Controls.Add(this.removeButton);
        this.Controls.Add(this.playNextButton);
        this.Controls.Add(this.playNowButton);
        this.Controls.Add(titleLabel);
        this.Controls.Add(this.queueListBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "QueueForm";
        this.Text = "QueueForm";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueueForm_FormClosing);
        this.Load += new System.EventHandler(this.QueueForm_Load);
        this.queueContextMenu.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button clearButton;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;

    private System.Windows.Forms.ContextMenuStrip queueContextMenu;
    private System.Windows.Forms.ToolStripMenuItem playNowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playNextToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;

    private System.Windows.Forms.Button playNowButton;
    private System.Windows.Forms.Button playNextButton;
    private System.Windows.Forms.Button removeButton;
    private FontAwesome.Sharp.IconButton moveUpButton;
    private FontAwesome.Sharp.IconButton moveDownButton;

    public System.Windows.Forms.ListBox queueListBox;

    #endregion
}
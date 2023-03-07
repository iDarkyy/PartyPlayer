using System.ComponentModel;

namespace PartyPlayer.Forms;

partial class SettingsForm
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
        this.settingPanel = new System.Windows.Forms.Panel();
        this.SuspendLayout();
        // 
        // settingPanel
        // 
        this.settingPanel.Dock = System.Windows.Forms.DockStyle.Left;
        this.settingPanel.Location = new System.Drawing.Point(0, 0);
        this.settingPanel.Name = "settingPanel";
        this.settingPanel.Size = new System.Drawing.Size(320, 511);
        this.settingPanel.TabIndex = 0;
        // 
        // SettingsForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.ClientSize = new System.Drawing.Size(984, 511);
        this.Controls.Add(this.settingPanel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "SettingsForm";
        this.Text = "SettingsForm";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel settingPanel;

    #endregion
}
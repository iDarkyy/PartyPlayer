using System.ComponentModel;

namespace PartyPlayer.Forms;

partial class EqualizerForm
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
        System.Windows.Forms.Panel panel2;
        this.panel1 = new System.Windows.Forms.Panel();
        panel2 = new System.Windows.Forms.Panel();
        this.SuspendLayout();
        // 
        // panel2
        // 
        panel2.Dock = System.Windows.Forms.DockStyle.Left;
        panel2.Location = new System.Drawing.Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(91, 411);
        panel2.TabIndex = 11;
        // 
        // panel1
        // 
        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel1.Location = new System.Drawing.Point(0, 411);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(984, 100);
        this.panel1.TabIndex = 10;
        // 
        // EqualizerForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        this.ClientSize = new System.Drawing.Size(984, 511);
        this.Controls.Add(panel2);
        this.Controls.Add(this.panel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "EqualizerForm";
        this.Text = "EqualizerForm";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel1;

    #endregion
}
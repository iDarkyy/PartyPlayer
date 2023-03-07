using System;
using System.Drawing;
using System.Windows.Forms;

namespace PartyPlayer.Utils;

public static class FormUtils
{
    public static void GenerateGradient(this Control owner, Control other, DockStyle dock, int countOfPanels = 10,
        int preferredX = 1, int preferredY = 1)
    {
        var ownerColor = owner.BackColor;
        var otherColor = other.BackColor;

        var r = new int[countOfPanels];
        var g = new int[countOfPanels];
        var b = new int[countOfPanels];

        var incrR = (Math.Max(ownerColor.R, otherColor.R) - Math.Min(ownerColor.R, otherColor.R)) / countOfPanels;
        var incrG = (Math.Max(ownerColor.G, otherColor.G) - Math.Min(ownerColor.G, otherColor.G)) / countOfPanels;
        var incrB = (Math.Max(ownerColor.B, otherColor.B) - Math.Min(ownerColor.B, otherColor.B)) / countOfPanels;

        // red
        for (var i = 0; i < countOfPanels; i++)
        {
            var prev = i == 0 ? ownerColor.R > otherColor.R ? ownerColor.R : otherColor.R : r[i - 1];
            r[i] = ownerColor.R > otherColor.R ? prev - incrR : prev + incrR;
        }

        // green
        for (var i = 0; i < countOfPanels; i++)
        {
            var prev = i == 0 ? ownerColor.G > otherColor.G ? ownerColor.G : otherColor.G : g[i - 1];
            g[i] = ownerColor.G > otherColor.G ? prev - incrG : prev + incrG;
        }

        // blue
        for (var i = 0; i < countOfPanels; i++)
        {
            var prev = i == 0 ? ownerColor.B > otherColor.B ? ownerColor.B : otherColor.B : b[i - 1];
            b[i] = ownerColor.B > otherColor.B ? prev - incrB : prev + incrB;
        }

        // creating panels
        for (var i = 0; i < 10; i++)
        {
            var panel = new Panel();
            panel.Location = owner.Location;
            panel.Dock = dock;
            panel.Size = new Size(preferredX, preferredY);
            panel.BackColor = Color.FromArgb(r[i], g[i], b[i]);
            panel.Visible = true;
            panel.BringToFront();

            owner.Controls.Add(panel);
        }
    }
}
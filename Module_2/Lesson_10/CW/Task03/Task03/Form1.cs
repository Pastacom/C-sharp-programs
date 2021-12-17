using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task03
{
    public partial class Form1 : Form
    {
        int X { get; set; } = 0;
        int Y { get; set; } = 0;

        int W { get; set; } = 100;
        int H { get; set; } = 100;

        public Form1()
        {
            InitializeComponent();
            trackBar1.Maximum = Width - W-15;
            trackBar2.Maximum = Height - H-40;
            trackBar2.Value = trackBar2.Maximum;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), X, Y, W, H);
            TransparencyKey = SystemColors.ControlDark;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            X = trackBar1.Value;
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Y = trackBar2.Maximum - trackBar2.Value;
            Invalidate();
        }
    }
}

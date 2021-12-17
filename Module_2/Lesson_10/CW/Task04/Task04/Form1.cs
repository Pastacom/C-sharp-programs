using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task04
{

    public partial class Form1 : Form
    {
        Rate gameRating = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            gameRating.Hits++;
            hitsLabel.Text = gameRating.Hits.ToString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            gameRating.Fails++;
            failsLabel.Text = gameRating.Fails.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button.Visible = !button.Visible;
        }
    }

    class Rate
    {
        public uint Hits { get; set; }
        public uint Fails { get; set; }
    }
}

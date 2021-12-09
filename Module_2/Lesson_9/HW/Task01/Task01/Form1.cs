using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Text != "" && label1.Text != "Кот уже ушел!")
            {
                label1.Text = label1.Text[..^1];
            }
            else if(label1.Text == "")
            {
                Opacity -= 0.1;
                if (Opacity == 0)
                {
                    label1.Text = "Кот уже ушел!";
                }
            }
            else
            {
                Opacity += 0.1;
                if (Opacity == 1)
                {
                    timer1.Stop();
                }
            }
        }
    }
}

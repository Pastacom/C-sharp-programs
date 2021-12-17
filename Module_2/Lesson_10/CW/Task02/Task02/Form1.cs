using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size s = ClientSize;
            button1.Location = new Point(s.Width / 2 - button1.Width / 2, s.Height / 2 - button1.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var max = MaximumSize;
            var min = MinimumSize;
            bool flag = true;
            if (button1.Text == "Уменьшить форму")
            {
                flag = false;
            }
            if (flag)
            {
                Size = new Size(Size.Width / 2 * 3, Size.Height / 2 * 3);
            }
            else
            {
                Size = new Size(Size.Width / 3 * 2, Size.Height / 3 * 2);
            }
            if (Size == MaximumSize)
            {
                button1.Text = "Уменьшить форму";
            }
            else if(Size == MinimumSize)
            {
                button1.Text = "Увеличить форму";
            }
            CenterToScreen();
        }
    }
}

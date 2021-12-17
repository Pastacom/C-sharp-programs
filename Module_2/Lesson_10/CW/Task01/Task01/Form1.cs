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
        private BindingList<string> MyList { get; set; }
        public Form1()
        {
            InitializeComponent();
            textBox1.Lines = new string[] { "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь" };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Результаты изменений:\n" + string.Join(" ", textBox1.Lines));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] MyArray = { "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь" };
            textBox1.Lines = MyArray;
        }
    }
}
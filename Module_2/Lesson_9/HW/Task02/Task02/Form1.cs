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
        private BindingList<string> MyList { get; set; }
        public Form1()
        {
            InitializeComponent();
            MyList = new BindingList<string> { "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь" };
            listBox1.DataSource = MyList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.RemoveAt(listBox1.SelectedIndex);
            }
            catch(Exception)
            {
                MessageBox.Show("Закончились элементы списка!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyList = new BindingList<string> { "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь" };
            listBox1.DataSource = MyList;
        }
    }
}

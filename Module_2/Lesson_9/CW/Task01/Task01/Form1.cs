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
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }


        private void buttonMyForm_Click(object sender, EventArgs e)
        {
            labelFirstForm.Text = "after pressing";
            buttonMyForm.Visible = false;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            buttonMyForm.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                labelFirstForm.Text = "cheked";
            }
            else
            {
                labelFirstForm.Text = "uncheked";
            }
            var list = checkedListBox1.Items;
            string str = "";
            foreach (var item in list)
                str += " " + item.ToString();
            MessageBox.Show(str);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello " + textBox1.Text);
        }
    }
}
using System;
using System.Windows.Forms;

namespace task4_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private backend bc = new backend();
        private string selectFunction = string.Empty;
        private bool select;

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n = double.Parse(textBox1.Text);
            double a = (double)numericUpDown1.Value;
            double b = (double)numericUpDown2.Value;

            listBox1.Items.Add("Результат интегрирования");

            listBox1.Items.Add("-----------------------------------------------");

            listBox1.Items.Add(selectFunction);

            if (listBox2.SelectedIndex == 0) select = true;
            else select = false;

            listBox1.Items.Add(bc.leftTriangle(a, b, n, select));
            listBox1.Items.Add(bc.middleTriangle(a, b, n, select));
            listBox1.Items.Add(bc.Trapeze(a, b, n, select));
            listBox1.Items.Add(bc.Simpson(a, b, n, select));

            listBox1.Items.Add("-----------------------------------------------");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
                selectFunction = "Функция" + listBox2.Items[0].ToString();
            else selectFunction = "Функция " + listBox2.Items[1].ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace class_array_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList manageList = new ArrayList();

        private void button4_Click(object sender, EventArgs e) // Добавление в список предметов
        {
            if (textBox1.Text != "")
            {
                if (!manageList.ContainsDiscipline(textBox1.Text))
                {
                    manageList.addList(textBox1.Text);
                    textBox1.Clear();
                }
                else
                    MessageBox.Show("Данная дисциплина уже есть в базе!");
            }
            else
                MessageBox.Show("Поле пусто!");
        }

        private void button1_Click(object sender, EventArgs e) //Вывод списка предметов
        {
            listBox1.Items.Clear();

            List<string> list = manageList.getListDisc;

            if (manageList.isAlphavite)
                list.Sort();

            foreach (var elem in list)
                listBox1.Items.Add(elem);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            manageList.isAlphavite = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            manageList.clearListDisciplines();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                manageList.rmDiscipline(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
                MessageBox.Show("Не выбрана строка для удаления!");
        }
    }
}

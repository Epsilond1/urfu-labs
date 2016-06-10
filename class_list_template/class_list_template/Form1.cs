using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace class_list_template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public TBook manage;

        public string Title;
        public string Author;
        public int Year;

        private bool isEmpty()
        {
            return String.Empty != bookName.Text && String.Empty != bookAuthor.Text && String.Empty != bookYear.Text;
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            manage = new TBook();

            if (isEmpty())
            {
                Title = bookName.Text;
                Author = bookAuthor.Text;
                Year = int.Parse(bookYear.Text);

                if (!manage.isContains(Title))
                {
                    manage.addBooks(Title, Author, Year);

                    bookName.Text = string.Empty;
                    bookAuthor.Text = string.Empty;
                    bookYear.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Данная книга уже есть в базе данных!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Одно из поле не заполнено!");
                return;
            }
        }

        private void BShow_Click(object sender, EventArgs e)
        {
            manage = new TBook();
            bookList.Items.Clear();

            bool typeSort = radioName.Checked;
            List<string> books = manage.getBooks(typeSort);

            foreach (var book in books)
                bookList.Items.Add(book);
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if (bookList.SelectedIndex != -1)
            {
                string str = bookList.Items[bookList.SelectedIndex].ToString();
                if (MessageBox.Show("Вы уверены, что хотите удалить строку " + str + "?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    manage.deleteBooks(bookList.SelectedIndex);
                    bookList.Items.RemoveAt(bookList.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления!");
                return;
            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            manage.clearBooks();
            bookList.Items.Clear();
        }
    }
}

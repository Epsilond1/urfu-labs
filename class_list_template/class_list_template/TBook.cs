using System.Collections.Generic;
using System.Linq;

namespace class_list_template
{
    public class TBook
    {
        internal string Title;
        internal string Author;
        internal int Year;

        public static List<TBook> Books = new List<TBook>();

        myIComparer comparator = new myIComparer();
        //compareYears comparator2 = new compareYears(); Решилось лямбдой

        public TBook() { }

        public TBook(string kTitle, string kAuthor, int kYear)
        {
            Title = kTitle;
            Author = kAuthor;
            Year = kYear;
        }

        public List<string> getBooks(bool typeSort)
        {
            if (typeSort)
                Books.Sort(comparator);
            else
                Books = Books.OrderBy(book => book.Year).ToList<TBook>();

            List<string> books = new List<string>();

            foreach (var book in Books)
                 books.Add(string.Format("{0}, {1}, {2}", book.Title, book.Author, book.Year));

            return books;
        }

        public void addBooks(string bookName, string bookAuthor, int bookYear)
        {
            Books.Add(new TBook(bookName, bookAuthor, bookYear));
        }

        public void clearBooks()
        {
            Books.Clear();
        }

        public void deleteBooks(int index)
        {
            Books.RemoveAt(index);
        }

        public bool isContains(string bookName)
        {
            foreach(var book in Books)
                if (book.Title == bookName)
                    return true;

            return false;
        }

    }

    public class myIComparer : IComparer<TBook>
    {
        public int Compare(TBook x, TBook y)
        {
            return string.Compare(x.Title, y.Title);
        }
    }

    //public class compareYears : IComparer<TBook>
    //{
    //    public int Compare(TBook x, TBook y)
    //    {
    //        return x.Year > y.Year ? x.Year : y.Year;
    //    }
    //}
}

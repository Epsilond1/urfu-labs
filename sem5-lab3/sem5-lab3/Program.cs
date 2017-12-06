using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;

namespace sem5_lab3
{
    class News
    {
        private static string newsname;
        private static string newstext;

        public News(string _newsname, string _text)
        {
            newsname = _newsname.Replace("&nbsp", "").Replace("&quot", "").Replace(';', '\n');
            newstext = _text.Replace("&nbsp", "").Replace("&quot", "").Replace(';', '\n').Replace("&ndash", ""); 
        }

        public void Print(string filename)
        {
            // печать новости в файл
            Console.WriteLine(string.Format("Пишу новость {0} в файл {1}", newsname, filename));
            using (StreamWriter writer = File.CreateText(filename + ".txt"))
            {
                writer.WriteLine(newsname);
                writer.WriteLine(newstext);
                writer.Dispose();
            }
        }
    }

    class Program
    {

        static List<string> Split(string str, char delim)
        {
            List<string> answer = new List<string>();
            string buffer = string.Empty;

            foreach (char sym in str)
            {
                if (sym != delim)
                {
                    buffer += sym;
                }
                else
                {
                    if (buffer.Length > 0)
                    {
                        answer.Add(buffer);
                        buffer = "";
                    }
                }
            }
            if (buffer.Length > 0)
            {
                answer.Add(buffer);
            }

            return answer;
        }
        
        static void Main(string[] args)
        {
            string url = @"http://www.e1.ru/news/spool/";
            HtmlWeb page = new HtmlWeb();
            page.UserAgent = "Opera/9.80 (Windows NT 5.1; U; ru) Presto/2.9.168 Version/11.50')";
            var _document = page.Load(url);
            List<string> news_url = new List<string>();

            var all_news = _document.DocumentNode.SelectNodes("/html/body/div[6]/table/tr/td[2]/section/div/article/a");

            List<News> top_news = new List<News>();

            for (int index = 0; index < 10; ++index)
            {
                news_url.Add((all_news[index].Attributes["href"].Value));
            }

            foreach (string current_url in news_url)
            {
                HtmlWeb newspaper = new HtmlWeb();
                newspaper.OverrideEncoding = Encoding.Default;
                string fixed_url = Split(current_url, '/')[2];
                var buf_page = newspaper.Load(string.Format("http://www.e1.ru/news/print/{0}", fixed_url));
                string header_news = buf_page.DocumentNode.SelectSingleNode("//h1").InnerText;
                var raw_text_news = buf_page.DocumentNode.SelectNodes("//div/p");
                string text_news = string.Empty;
                foreach (var current_raw_text in raw_text_news)
                {
                    text_news += current_raw_text.InnerText + "\n";
                }

                News current_news = new News(header_news, text_news);
                current_news.Print(fixed_url);
            }
            Console.WriteLine("Запись новостей успешно завершена");
        }
    }
}
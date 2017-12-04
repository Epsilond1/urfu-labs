using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace sem5_lab2
{
    class Program
    {
        static string html = @"https://lenta.ru/";
        static string top_news = "//*[@id='root']/section[2]/div/div/div[2]/div[1]/section[1]/div/div[{0}]/a/text()";
        static string general_news = "//*[@id='root']/section[2]/div/div/div[1]/section[1]/div[2]/div[1]/div[{0}]/a/text()";

        static string normalize_string(string str)
        {
            return str.Replace("&nbsp;", " ");
        }


        static void print(int start, int count, string pattern, HtmlDocument _doc, string msg)
        {
            Console.WriteLine(msg);

            for (int index = start; index < count; ++index)
            {
                var response = _doc.DocumentNode.SelectNodes(string.Format(pattern, index));
                Console.WriteLine(normalize_string(response[0].OuterHtml));
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();

            var _doc = web.Load(html);

            int count_top_news = _doc.DocumentNode.SelectNodes("//*[@id='root']/section[2]/div/div/div[2]/div[1]/section[1]/div/div").Count;
            print(2, count_top_news, top_news, _doc, "Print Achtung News");

            int count_general_news = _doc.DocumentNode.SelectNodes("//*[@id='root']/section[2]/div/div/div[1]/section[1]/div[2]/div")[0].ChildNodes.Count;
            print(1, count_general_news, general_news, _doc, "Print Top Daily News");
        }
    }
}
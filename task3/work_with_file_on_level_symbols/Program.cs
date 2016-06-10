using System;
using System.IO;
using System.Linq;

namespace work_with_file_on_level_symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathName = Console.ReadLine();
            Console.WriteLine("Результат работы программы:");
            getSumThread(pathName);
        }

        static void getSumThread(string @path)
        {
            StreamReader file;

            try
            {
                file = new StreamReader(path);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Ошибка при открытии файла!");
                return;
            }

            while (!file.EndOfStream)
            {
                convertToInt(file.ReadLine().Split(' '));
            }

            file.Close();
        }

        static void convertToInt(string[] strNumbers)
        {
            try
            {
                printInfo(strNumbers.Select(x => int.Parse(x)).ToArray());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при чтении символов из строки!");
            }
        }

        static void printInfo(int[] listen)
        {
            foreach (var elem in listen)
                Console.Write("{0} ", elem);

            Console.Write("сумма: " + listen.Sum() + "\n");
        }
    }
}

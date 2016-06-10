using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace less
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.OutputEncoding = UTF8Encoding.UTF8;
			
            Console.WriteLine("Построчный вывод - <Enter>\nПоэкранный вывод - 2X<Space>\nВыход из режима чтения - <Q>");
            Console.Write("Файл: ");
            string filename = Console.ReadLine();
            Console.Write("Количество строк, выводимых за одну итерацию: ");
            int countStr = int.Parse(Console.ReadLine());
            readFileLines(filename, countStr);
        }

        static void readFileLines(string @path, int countStr)
        {
            try
            {
                StreamReader file = new StreamReader(path);

                while (!file.EndOfStream)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Write("\r");
                        Console.WriteLine(file.ReadLine());
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Write("\r");
                        for (int i = 0; i < countStr && !file.EndOfStream; i++)
                        {
                            Console.WriteLine(file.ReadLine());
                        }
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Q)
                        Environment.Exit(1);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Произошла ошибка при чтении файла!");
            }
        }
    }
}

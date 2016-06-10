using System;
using System.IO;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Вводит N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Вводит K: ");
            int k = int.Parse(Console.ReadLine());

            writeThread(generateByteThread(n)); //Генерим поток байт и пишем его в файл

            readByteThread(n); //Читаемт поток байт из файла и выводим на экран

            replaceByteThread(n, k); //Заменяем в потоке байт числа в позициях и выводим на экран
        }

        static void replaceByteThread(int n, int k)
        {
            FileStream file;

            try
            {
                file = new FileStream("input", FileMode.Open, FileAccess.ReadWrite);

                for (; file.Position < file.Length;)
                {
                    file.Position += k-1;
                    file.WriteByte(0);
                }

                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при работе с файлом!");
            }

            readByteThread(n);
        }

        static byte[] generateByteThread(int n)
        {
            byte[] arr = new byte[n];

            for (int i = 0, f = 1; i < n; i++, f += 2)
                arr[i] = (byte)f;

            return arr;
        }

        static void readByteThread(int n)
        {
            FileStream file;
            byte[] arr = new byte[n];

            try
            {
                file = new FileStream("input", FileMode.Open, FileAccess.Read);
                arr = new byte[n];
                file.Read(arr, 0,n);
                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при работе с файлом!");
            }

            printArray(arr);
        }

        static void writeThread(byte[] arr)
        {
            FileStream file;

            try
            {
                file = new FileStream("input", FileMode.Create, FileAccess.Write);
                file.Write(arr, 0, arr.Length);
                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при работе с файлом!");
            }
        }

        static void printArray(byte[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0} ", arr[i]);

            Console.WriteLine();
        }
    }
}

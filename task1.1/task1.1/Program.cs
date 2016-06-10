using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int countElement = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());

            byte[] listElements = getListElements(countElement);

            recordThread(listElements);

            readingThread();

            insertZero(K);

            readingThread();

            return;
        }

        static void readingThread()
        {
            FileStream file;

            try
            {
                file = new FileStream(@"1", FileMode.Open);

                byte[] thread = new byte[file.Length];

                file.Read(thread, 0, thread.Length);

                printThread(thread);

                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Произошла ошибка при работе с файлом!");
            }
        }

        static void insertZero(int K)
        {
            FileStream file;

            try
            {
                file = new FileStream(@"1", FileMode.Open, FileAccess.ReadWrite);

                byte[] bufThread;

                for (long position = K; position <= file.Length;)
                {
                    file.Position = position;

                    bufThread = new byte[file.Length - file.Position];

                    file.Read(bufThread, 0, (int)file.Length - (int)file.Position);

                    file.Position = position;

                    file.WriteByte(0);

                    position++;

                    file.Position = position;

                    file.Write(bufThread, 0, bufThread.Length);

                    position += K;

                    file.Position = position;
                }

                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Произошла ошибка при работе с файлом!");
            }
        }

        static void recordThread(byte[] arr)
        {
            FileStream file;

            //printThread(arr);

            try
            {
                file = new FileStream(@"1", FileMode.Create);

                //byte[] thread = arr.Select(x => (byte)x).ToArray(); А нужно ли?

                file.Write(arr, 0, arr.Length);

                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Произошла ошибка при работе с файлом!");
            }
        }

        static void printThread(byte[] arr)
        {
            foreach (var elem in arr)
                Console.Write("{0} ", elem);

            Console.WriteLine();
        }

        static byte[] getListElements(int n)
        {
            List<byte> arr = new List<byte>();

            for (byte i = 2; i <= n*2; i += 2)
                arr.Add(i);

            return arr.ToArray();
        }
    }
}

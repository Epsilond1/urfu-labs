using System;

namespace task4
{
    class Program
    {
        const int L = 5;
        const int K = 1;

        static void Main(string[] args)
        {
            Console.Write("a = ");
            int down = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int up = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int stepIntegration = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Результаты интегрирования");
            Console.WriteLine("--------- 1-я функция ------------------------------------------------------------");
            leftTriangle(down, up, stepIntegration, true);
            middleTriangle(down, up, stepIntegration, true);
            Console.WriteLine("--------- 2-я функция ------------------------------------------------------------");
            leftTriangle(down, up, stepIntegration, false);
            middleTriangle(down, up, stepIntegration, false);
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        static void leftTriangle(int a, int b, int N, bool flag)
        {
            double result = calculactionLeftTriangle(a, b, N, flag);
            double faulty = Math.Abs(calculactionLeftTriangle(a, b, N * 2, flag) - result);

            Console.WriteLine("Метод левых прямоугольников: {0}, погрешность: {1}", result, faulty);
        }

        static void middleTriangle(int a, int b, int N, bool flag)
        {
            double result = calculationMiddleTriangle(a, b, N, flag);
            double faulty = Math.Abs(calculationMiddleTriangle(a, b, N * 2, flag) - result);

            Console.WriteLine("Метод средних прямоугольников: {0}, погрешность: {1}", result, faulty);
        }

        static double calculactionLeftTriangle(int a, int b, int N, bool flag)
        {
            double h = Math.Abs((a - b) / (double)N);
            double result = 0;

            if (flag)
                for (double iter = a; iter < b; iter += h)
                    result += firstFunction(iter);
            else
                for (double iter = a; iter < b; iter += h)
                    result += secondFunction(iter);

            return result *= h;
        }

        static double calculationMiddleTriangle(int a, int b, int N, bool flag)
        {
            double h = Math.Abs((a - b) / (double)N);
            double result = 0;

            if (flag)
                for (double iter = a; iter < b; iter += h)
                    result += firstFunction(iter + (h / 2));
            else
                for (double iter = a; iter < b; iter += h)
                    result += secondFunction(iter + (h / 2));

            return result *= h;
        }

        static double firstFunction(double x)
        {
            return L * Math.Pow(x, 0.5);
            //return 1 / (Math.Log(x)); //при 5,2 {1 / lnx}
        }

        static double secondFunction(double x)
        {
            return L / (5 + 2 * Math.Pow(x, K));
        }
    }
}

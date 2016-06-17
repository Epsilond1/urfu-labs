using System;

namespace task4_gui
{
    public class backend
    {
        public const int L = 5;
        public const int K = 1;

        public string leftTriangle(double a, double b, double N, bool flag)
        {
            double result = calculactionLeftTriangle(a, b, N, flag);
            double faulty = Math.Abs(calculactionLeftTriangle(a, b, N * 2, flag) - result);

            return string.Format("Метод левых прямоугольников: {0}, погрешность: {1}", result, faulty);
        }

        public string middleTriangle(double a, double b, double N, bool flag)
        {
            double result = calculationMiddleTriangle(a, b, N, flag);
            double faulty = Math.Abs(calculationMiddleTriangle(a, b, N * 2, flag) - result);

            return string.Format("Метод средних прямоугольников: {0}, погрешность: {1}", result, faulty);
        }

        public string Trapeze(double a, double b, double N, bool flag)
        {
            double result = calculationTrapeze(a, b, N, flag);
            double faulty = Math.Abs(calculationTrapeze(a, b, N * 2, flag) - result);

            return string.Format("Метод трапеций: {0}, погрешность: {1}", result, faulty);
        }

        public string Simpson(double a, double b, double N, bool flag)
        {
            double result = calculationSimpson(a, b, N, flag);
            double faulty = Math.Abs(calculationSimpson(a, b, N * 2, flag) - result);

            return string.Format("Метод Симпсона: {0}, погрешность: {1}", result, faulty);
        }

        public double calculationSimpson(double a, double b, double N, bool flag)
        {
            double h = (double)(b - a) / (double)N;
            double result = 0;
            double buf = 0;
            if (flag)
            {
                double An = (double)a;
                double Bn = An + h;

                for (; An <= b; An = An + h, Bn = Bn + h)
                {
                    buf = ((Bn - An) / 6.0) * (firstFunction(An) + 4 * firstFunction((An + Bn) / 2.0) + firstFunction(Bn));

                    result += buf;
                }
            }
            else
            {
                double An = (double)a;
                double Bn = An + h;

                for (; An <= b; An = An + h, Bn = Bn + h)
                {
                    buf = ((Bn - An) / 6.0) * (secondFunction(An) + 4 * secondFunction((An + Bn) / 2.0) + secondFunction(Bn));

                    result += buf;
                }
            }

            return result;
        }

        public double calculationTrapeze(double a, double b, double N, bool flag)
        {
            double h = Math.Abs((a - b) / (double)N);
            double result = 0;

            if (flag)
            {
                result = (firstFunction(a) + firstFunction(b)) / 2;
                for (double iter = a; iter < b; iter += h)
                    result += firstFunction(iter);
            }
            else {
                result = (secondFunction(a) + secondFunction(b)) / 2;
                for (double iter = a; iter < b; iter += h)
                    result += secondFunction(iter);
            }

            return result * h;
        }

        public double calculactionLeftTriangle(double a, double b, double N, bool flag)
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

        public double calculationMiddleTriangle(double a, double b, double N, bool flag)
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

        public double firstFunction(double x)
        {
            return L * Math.Pow(x, 0.5);
        }

        public double secondFunction(double x)
        {
            return L / (5 + 2 * Math.Pow(x, K));
        }
    }
}

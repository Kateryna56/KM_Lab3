using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shemet_Lab3.CLasses
{
    public static class Calculator
    {
        private static Brush green = new SolidBrush(Color.Green);
        private static Brush brown = new SolidBrush(Color.Brown);
        private static double a = 0.5;
        private static double b = 1.0;
        private static double t0 = 0.5;
        private static double tMax = 3.5;
        private static double h = 0.001;
        private static double y0 = b;
        static double Function(double t, double y)
        {
            return a * t - b * y * y;
        }
        static double RungeKutta(double t, double y)
        {
            double k1 = h * Function(t, y);
            double k2 = h * Function(t + h, y + k1);
            return y + 0.5 * (k1 + k2);
        }
        public static void SolveRungeKutta2(double begin, double end)
        {
            Drawer.DrawPointMed(t0, y0, brown);
            Debug.WriteLine("Runge-kutta-2 method");

            for (double t = t0; t <= tMax; t += h)
            {
                y0 = RungeKutta(t, y0);
                Drawer.DrawPointMed(t, y0, brown);
                Debug.WriteLine("t = " + t + " y = " + y0);
            }
        }

        static double AdamsBashforth(double[] t, double[] y, int i, double h, double a, double b)
        {
            return y[i] + h * (3.0 * Function(t[i], y[i]) - Function(t[i - 1], y[i - 1])) / 2.0;
        }

        static double AdamsMoulton(double[] t, double[] y, int i, double h, double a, double b)
        {
            return y[i - 1] + h * (Function(t[i], AdamsBashforth(t, y, i, h, a, b)) + Function(t[i - 1], y[i - 1])) / 2.0;
        }

        public static void SolveABM(double begin, double end)
        {
            int n = (int)((tMax - t0) / h) + 1;
            double[] t = new double[n];
            double[] y = new double[n];
            y0 = b;
            t[0] = t0;
            y[0] = y0;
            Debug.WriteLine("ABM method");

            for (int i = 1; i < n; i++)
            {
                t[i] = t[i - 1] + h;
                y[i] = AdamsMoulton(t, y, i, h, a, b);
                Drawer.DrawPointMed(t[i], y[i], green);
                Debug.WriteLine("t = " + t[i] + " y = " + y[i]);
            }
        }
    }
}

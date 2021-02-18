using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class methods
    {
        static void Swap(ref double a, ref double b)
        {
            var t = a;
            a = b;
            b = t;
        }
        public static double[] ShellSort(double[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] < array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        public static double [] PN1(int m,double [] X)
        {
            double[] a = new double[m];
            double[,] c = new double[m,m];
            for (int i = 0; i < m; i++)
                c[i, 0] = X[i];
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (i < j)
                        c[i, j] = 0;
                    else
                        c[i, j] = (c[i, j - 1] - c[j - 1, j - 1]) / ((i + 1) - j);
                }
            }
            for (int i = 0; i < m; i++)
                a[i] = c[i, i];
            return a;
        }
        public static double[] PN2(double[] a, int m, double[] Y,double h,double my)
        {
            double p;
            double s;
            double t = 0;
            int k = 0;
            while (k < Y.Length)
            {
                s = 0;
                for (int i = 0; i < m; i++)
                {
                    p = 1;
                    for (int j = 0; j < i; j++)
                        p *= (t - j);
                    s += a[i] * p;
                }
                Y[k] = Math.Round(s, 2);
                k++;
                t += h;
            }
            return Y;
        }      
        public static void massacreate ()
        {
            Random rnd = new Random();
            Dan.A = new double[Dan.m, Dan.m];
            for (int i = 0; i < Dan.m; i++)
            {
                for (int j = 0; j < Dan.m; j++)
                {
                    Dan.A[i, j] = rnd.Next(Dan.a1, Dan.a2);

                    if (i == j) Dan.S += Dan.A[i, j];
                }
            }
        }
        public static void progression (ref double progr)
        {
            for (int i = 1; i < Dan.m; i++)
            {
                Dan.C[i] = progr + Dan.R;
                progr += Dan.R;
            }
        }
        public static void massxcreate ()
        {
            double sum = 0;
            for (int i = 0; i < Dan.m; i++)
            {
                for (int k = 0; k < Dan.m; k++)
                    sum += (Dan.A[k, i] + Dan.C[k]) / (Math.Pow(k, 2) + Dan.B);
                Dan.X[i] = Math.Round((Dan.S / (Dan.P * Dan.C[i])) + sum, 2);
                sum = 0;
                Dan.P = Dan.X[i];


            }
        }
        public static string[] slpitstr (string str,int i)
        {
            return str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
        public static void fileread(string fn)
        {
            string[] str; string[] elem;
            using (StreamReader filein = new StreamReader($"{fn}", Encoding.GetEncoding(65001)))
            {
                str = filein.ReadToEnd().ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Contains("Массив А:"))
                    {
                        elem = str[i + 1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.m = elem.Length;
                        Dan.A = new double[Dan.m, Dan.m];
                        for (int j = 0; j < Dan.m; j++)
                        {
                            elem = str[++i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            for (int v = 0; v < Dan.m; v++)
                            {
                                Dan.A[j, v] = Convert.ToDouble(elem[v]);
                            }
                        }
                    }
                    if (str[i].Contains("Массив C:"))
                    {
                        elem = str[i + 1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.C = new double[elem.Length];
                        for (int j = 0; j < elem.Length; j++)
                        {
                            Dan.C[j] = Convert.ToDouble(elem[j]);
                        }
                    }
                    if (str[i].Contains("Массив X:"))
                    {
                        elem = str[i + 1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.X = new double[elem.Length];
                        for (int j = 0; j < elem.Length; j++)
                        {
                            Dan.X[j] = Convert.ToDouble(elem[j]);
                        }
                    }
                    if (str[i].Contains("Массив Y:"))
                    {
                        elem = str[i + 1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.Y = new double[elem.Length];
                        for (int j = 0; j < elem.Length; j++)
                        {
                            Dan.Y[j] = Convert.ToDouble(elem[j]);
                        }
                    }
                    if (str[i].Contains("Отсортированный массив Y:"))
                    {
                        elem = str[i + 1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.Y_Sort = new double[elem.Length];
                        for (int j = 0; j < elem.Length; j++)
                        {
                            Dan.Y_Sort[j] = Convert.ToDouble(elem[j]);
                        }
                    }
                    if (str[i].Contains("m"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.m =Convert.ToInt32(elem[1]);
                    }
                    if (str[i].Contains("a1"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.a1 = Convert.ToInt32(elem[1]);
                    }
                    if (str[i].Contains("a2"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.a2 = Convert.ToInt32(elem[1]);
                    }
                    if (str[i].Contains("R"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.R = Convert.ToDouble(elem[1]);
                    }
                    if (str[i].Contains("C1"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.C1 = Convert.ToDouble(elem[1]);
                    }
                    if (str[i].Contains("b"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.B = Convert.ToDouble(elem[1]);
                    }
                    if (str[i].Contains("h"))
                    {
                        elem = str[i].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        Dan.h = Convert.ToDouble(elem[1]);
                    }
                }
            }
        }

    }
}

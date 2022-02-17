using System;

namespace lab_1_v
{
    public class HW1
    {
        public static void Turn(int[] customers, int[] c, int n, ref int i)
        {
            for (int j = 0; j < n; j++)
            {
                if (c[j] == 0)
                {
                    c[j] = customers[i];
                    i++;
                    if (i > customers.Length) break;
                }
            }
        }

        public static void Init(int[] c, int n)
        {
            for (int t = 0; t < n; t++) c[t] = 0;
        }

        public static int Max(int[] c, int n)
        {
            int max = 0;
            for (int j = 0; j < n; j++) if (max < c[j]) max = c[j];
            return max;
        }

        public static long QueueTime(int[] customers, int n)
        {

            int[] c = new int[n];
            Init(c, n);
            int i = 0;
            long time = 0;
            Turn(customers, c, n, ref i);
            while (i < customers.Length)
            {
                time++;
                for (int j = 0; j < n; j++) c[j]--;
                for (int j = 0; j < n; j++) Turn(customers, c, n, ref i);
            }
            int max = 0;
            time += Max(c, n);
            return time;
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            long time;
            int[] mas1 = new int[3] { 5, 3, 4 };
            time = HW1.QueueTime(mas1, 1);
            Console.WriteLine($"{time}");

            int[] mas2 = new int[4] { 10, 2, 3, 3 };
            time = HW1.QueueTime(mas2, 2);
            Console.WriteLine($"{time}");

            int[] mas3 = new int[3] { 2, 3, 10 };
            time = HW1.QueueTime(mas3, 2);
            Console.WriteLine($"{time}");
        }
    }
}
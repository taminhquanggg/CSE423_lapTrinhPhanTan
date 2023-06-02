using System;
using System.Drawing;
using System.Reflection;

namespace Lab3
{
    public class Program
    {
        static int SIZE = 10;
        const int k = 3;
        const int h = 1;

        static int[] data = new int[SIZE];

        /// <summary>
        /// Kiểm tra số đối xứng
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static bool IsPalindrome(int x)
        {
            int remineder, sum = 0;
            int temp = x;
            while (temp > 0)
            {
                remineder = temp % 10;

                sum = (sum * 10) + remineder;

                temp = temp / 10;
            }
            return sum == x;
        }

        static bool isEvenNumber(int x)
        {
            return x % 2 == 0;
        }

        static void Main(string[] args)
        {
            //BoundedBuffer buffer = new BoundedBuffer();
            //Consumer consumer = new Consumer(buffer, 1000);
            //Producer producer = new Producer(buffer, 50);

            //Console.ReadLine();

            ReaderWriter rw = new ReaderWriter();

            while (true)
            {
                for (int i = 0; i < k; i++)
                {
                    Thread tw = new Thread(() =>
                    {
                        rw.startWrite();
                        Random r = new Random();
                        if (data.Length > 0)
                        {
                            for (int j = 0; j < data.Length; j++)
                            {
                                data[j] = r.Next(100);
                                Console.WriteLine("W" + i + ": " + data[j] + " - " + DateTime.Now.ToString("HH:mm:ss tt"));
                            }
                        }
                        else
                        {
                            data = data.Concat(new int[] { r.Next(100) }).ToArray();
                        }

                        Console.WriteLine("-----------------------");
                        int temp = i;
                        Console.WriteLine("Writer " + i + " data:");
                        for (int j = 0; j < data.Length; j++)
                        {
                            Console.WriteLine("data[" + j + "] = " + data[i]);
                        }
                        Console.WriteLine("-----------------------");

                        rw.endWrite();
                    });
                    tw.Start();
                }
                for (int i = 0; i < h; i++)
                {
                    Thread tr = new Thread(() =>
                    {
                        rw.startRead();
                        if (data.Length != 0)
                        {
                            Random r = new Random();
                            int index = r.Next(data.Length);
                            if (index >= 0 && data.Length > 0)
                            {
                                int value = data[index];
                                data = data.Where((val, idx) => idx != index).ToArray();
                                Console.WriteLine("R" + i + ": " + value + " - " + (isEvenNumber(value) ? "SO CHAN" : "SO LE") + " - " + DateTime.Now.ToString("HH:mm:ss tt"));

                            }
                        }

                        rw.endRead();
                    });
                    tr.Start();
                }
            }

            Console.ReadLine();
        }

    }
}
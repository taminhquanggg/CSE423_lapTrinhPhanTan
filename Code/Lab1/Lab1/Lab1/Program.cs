using System;
using System.Reflection;
using System.Threading;

namespace Lab1
{
    class Program
    {
        const int MAX_LEN_ARR = 500;
        const int NUM_OF_THREAD = 50;
        static int[] data = new int[MAX_LEN_ARR];

        static void Main(string[] args)
        {
            int startArr, endArr = 0;
            int countInThread, countInArr = 0;
            int finalResult = 0;
            List<Thread> threads = new List<Thread>();

            Random rand = new Random();

            for (int i = 0; i < MAX_LEN_ARR; i++)
            {
                data[i] = rand.Next(100, 10000);
            }

            /* SHOW DATA
            Console.WriteLine("DATA");

            for (int i = 0; i < MAX_LEN_ARR; i++)
            {
                Console.WriteLine("data[" + i + "] = " + data[i]);
            }
            Console.WriteLine("_________________________");
            */

            for (int i = 0; i < NUM_OF_THREAD; i++)
            {
                int temp = i;
                Thread t = new Thread(() =>
                {
                    startArr = temp * (MAX_LEN_ARR / NUM_OF_THREAD);

                    if (temp == NUM_OF_THREAD - 1)
                    {
                        endArr = MAX_LEN_ARR;
                    }
                    else
                    {
                        endArr = temp * (MAX_LEN_ARR / NUM_OF_THREAD) + (MAX_LEN_ARR / NUM_OF_THREAD);
                    }

                    /* Test Thread
                    Console.WriteLine("Thread " + temp);
                    ThreadRun(startArr, endArr);
                    */

                    countInThread = ThreadRun(startArr, endArr);
                    finalResult += countInThread;
                    Console.WriteLine("T" + temp + ": " + countInThread);
                });
                t.Start();
                threads.Add(t);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("_________________________");
            Console.WriteLine("FINAL RESULT IN THREAD: " + finalResult);
            Console.WriteLine("_________________________");

            for (int i = 0; i < MAX_LEN_ARR; i++)
            {
                if (IsPalindrome(data[i]))
                {
                    countInArr++;
                }

            }
            Console.WriteLine("FINAL RESULT IN ARR: " + countInArr);
            Console.WriteLine("_________________________");

            Console.ReadLine();
        }
        
        //TestThread
        //static void ThreadRun(int start, int end)
        //{

        //    for (int i = start; i < end; i++)
        //    {
        //        Console.WriteLine("data[" + i + "] = " + data[i]);
        //    }
        //}

        /// <summary>
        /// Xử lý Thread
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static int ThreadRun(int start, int end)
        {
            int count = 0;
            for (int i = start; i < end; i++)
            {
                if (IsPalindrome(data[i]))
                {
                    //Console.WriteLine("data[" + i + "] = " + data[i]);
                    count++;
                }
            }
            return count;
        }

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

        //Kiểm tra số chính phương
        //static bool isSoCp(int x)
        //{
        //    int sqr = (int)Math.Sqrt(x);
        //    if (sqr * sqr == x)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}


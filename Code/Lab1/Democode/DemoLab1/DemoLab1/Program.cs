using System;
namespace DemoLab1
{
    class Program
    {
        const int MAX_LEN_ARR = 1000;
        const int NUM_OF_THREAD = 100;
        static int[] data = new int[MAX_LEN_ARR];

        static void Main(string[] args)
        {
            Random rand = new Random();
            int startArr, endArr = 0;
            int maxInThread;
            int maxInArr = data[0];
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < MAX_LEN_ARR; i++)
            {
                data[i] = rand.Next(100, 1000);
            }

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
                        endArr = startArr + (MAX_LEN_ARR / NUM_OF_THREAD);
                    }
                    maxInThread = ThreadRun(startArr, endArr);
                    if (maxInThread > maxInArr)
                    {
                        maxInArr = maxInThread;
                    }
                    Console.WriteLine("T" + temp + ":" + maxInThread);

                });
                t.Start();
                threads.Add(t);
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            Console.WriteLine("_________________");
            Console.WriteLine("MAX IN THREAD FINAL: " + maxInArr);
            Console.WriteLine("_________________");

            Console.WriteLine("_________________");
            Console.WriteLine("MAX IN ARRAY FINAL: " + ThreadRun(0, MAX_LEN_ARR));
            Console.WriteLine("_________________");

            Console.ReadLine();
        }

        static int ThreadRun(int start, int end)
        {
            int max = data[start];
            for (int i = start + 1; i < end; i++)
            {
                if (data[i] > max)
                {
                    max = data[i];
                }
            }
            return max;

        }
    }
}
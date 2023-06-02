using System.Text;
using System.Threading;

namespace Lab3Semaphore
{
    public class Program
    {
        const int k = 10;
        const int h = 10;

        static SemaphoreSlim semaphore = new SemaphoreSlim(1);

        static Stack<int> data = new Stack<int>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            Random r = new Random();

            while (true)
            {
                for (int i = 0; i < k; i++)
                {
                    int temp = i;
                    Thread write = new Thread(() =>
                    {
                        WriteThread(temp);

                    });

                    write.Start();
                }

                for (int i = 0; i < h; i++)
                {
                    int temp = i;
                    Thread read = new Thread(() =>
                    {
                        ReadThread(temp);

                    });

                    read.Start();
                }
            }

        }

        static void WriteThread(int i)
        {
            semaphore.Wait();

            Random random = new Random();
            Thread.Sleep(random.Next(500, 1000));
            int value = random.Next(0, 100);

            data.Push(value);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("W" + i + ":" + value + " - " + DateTime.Now);
            Console.ResetColor();

            semaphore.Release();
        }

        static void ReadThread(int i)
        {
            semaphore.Wait();

            if (data.Count > 0)
            {
                Random random = new Random();
                Thread.Sleep(random.Next(500, 1000));

                int val = data.Pop();
                Console.WriteLine("R" + i + ":" + val + " - " + (IsPalindrome(val) ? "Là số đối xứng - " : "Không là số đối xứng - ") + DateTime.Now);

            }

            semaphore.Release();
        }

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

        


    }
}
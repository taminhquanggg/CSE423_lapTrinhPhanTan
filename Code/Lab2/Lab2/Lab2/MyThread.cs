using System;
using Lab2;
namespace Lab2
{
    public class MyThread
    {
        const int MAX_LEN_ARR = 10;
        int _myId;
        Lock _lock;
        int[] data;


        int startArr, endArr;
        Random rand = new Random();

        public MyThread(int id, Lock _lock)
        {
            data = new int[MAX_LEN_ARR];

            this._myId = id;
            this._lock = _lock;

            startArr = _myId * (MAX_LEN_ARR / 2);

            if (_myId == 1)
            {
                endArr = MAX_LEN_ARR;
            }
            else
            {
                endArr = startArr + (MAX_LEN_ARR / 2);
            }
        }

        void CS()
        {
            try
            {
                for (int i = startArr; i < endArr; i++)
                {
                    data[i] = rand.Next(100, 1000);
                }
                Console.WriteLine("_______________________");

                Console.WriteLine("Thread " + _myId + " in CS. Show DATA: ");
                for (int i = 0; i < MAX_LEN_ARR; i++)
                {
                    Console.WriteLine("data[" + i + "] = " + data[i]);
                }
                Console.WriteLine("_______________________");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void nonCS()
        {
            try
            {
                int count = 0;
                for (int i = startArr; i < endArr; i++)
                {
                    if (IsPalindrome(data[i]))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("_______________________");
                    Console.WriteLine("Thread " + _myId + " out of CS. Show VALUE: ");
                    for (int i = startArr; i < endArr; i++)
                    {
                        if (IsPalindrome(data[i]))
                        {
                            Console.WriteLine("So doi xung data[" + i + "] = " + data[i]);
                        }
                    }
                    Console.WriteLine("_______________________");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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

        public void ThreadRun()
        {
            while (true)
            {
                _lock.requestCS(_myId);
                CS();
                _lock.releaseCS(_myId);
                nonCS();
            }
        }

        static void Main(string[] args)
        {
            Lock testLock = new PetersonAlgorithm();
            for (int i = 0; i < 2; i++)
            {
                int temp = i;
                Thread t = new Thread(() =>
                {
                    MyThread myThread = new MyThread(temp, testLock);
                    myThread.ThreadRun();
                });
                t.Start();
            }
        }
    }
}
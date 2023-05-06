class Program
{
    static void Main(string[] args)
    {
        Thread t1 = new Thread(() =>
        {
            DemoThread("1");
        });
        t1.Start();


        Thread t2 = new Thread(() =>
        {
            DemoThread("2");
        });
        t2.Start();

        t2.Join();

        Console.WriteLine("T-m");
        t1.Join();



        Console.ReadLine();
    }

    static void DemoThread(string threadIndex)
    {
        Console.WriteLine("T" + threadIndex);

    }
}
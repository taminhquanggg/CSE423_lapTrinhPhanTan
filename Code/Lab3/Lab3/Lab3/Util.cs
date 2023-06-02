using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Util
    {
        public static void mySleep(int time)
        {
            try
            {
                Thread.Sleep(time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public static void myWait(object obj)
        {
            try
            {
                Monitor.Wait(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}

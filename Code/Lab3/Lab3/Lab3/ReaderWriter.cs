using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ReaderWriter
    {
        int numReaders = 0;
        BinarySemaphore mutex = new BinarySemaphore(true);
        BinarySemaphore wlock = new BinarySemaphore(true);

        public void startRead()
        {
            mutex.P();
            numReaders++;
            if (numReaders == 1) wlock.P();
            mutex.V();
        }

        public void endRead()
        {
            mutex.P();
            numReaders--;
            if (numReaders == 0) wlock.V();
            mutex.V();
        }

        public void startWrite()
        {
            wlock.P();
        }

        public void endWrite()
        {
            wlock.V();
        }
    }
}

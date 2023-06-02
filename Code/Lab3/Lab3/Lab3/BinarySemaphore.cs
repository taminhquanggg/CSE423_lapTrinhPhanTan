using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class BinarySemaphore
    {
        bool value;

        public BinarySemaphore(bool initValue)
        {
            this.value = initValue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void P()
        {
            if (value == false)
                Util.myWait(this);
            value = false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void V()
        {
            value = true;
            Monitor.Pulse(this);
        }

    }
}

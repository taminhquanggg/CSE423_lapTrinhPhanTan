using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface Lock
    {
        public void requestCS(int pid);
        public void releaseCS(int pid);
    }
}

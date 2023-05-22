using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class PetersonAlgorithm : Lock
    {
        bool[] wantCS = { true, false };
        int turn = 1;

        public void requestCS(int i)
        {
            int j = 1 - i;
            wantCS[i] = true;
            turn = j;
            while (wantCS[j] && (turn == j)) ;
        }

        public void releaseCS(int i)
        {
            wantCS[i] = false;
        }
    }
}

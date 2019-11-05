using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class And
    {
        public static void and(WObj Object, int destReg, int andReg1, int andReg2)
        {
            RegisterClass.programCounter++;
            int len = 0;
            BitArray and1 = Object.Registers.registerLocations[andReg1];
            BitArray and2 = Object.Registers.registerLocations[andReg2];

            if (and1.Length > and2.Length)
                len = and1.Length;
            else
                len = and2.Length;
            BitArray output = new BitArray(len);

            for (int x = 0; x < len; x++)
            {
                if (and1[x] && and2[x] == true)
                    output[x] = true;
                else
                    output[x] = false;

            }

            Object.Registers.registerLocations[destReg] = output;

        }
    }
}

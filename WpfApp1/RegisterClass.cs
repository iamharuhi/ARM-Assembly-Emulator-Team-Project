using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RegisterClass
    {
        public Dictionary<int, BitArray> registerLocations;
        public static int programCounter = 0;

    public RegisterClass()
        {
            registerLocations = new Dictionary<int, BitArray>();
        }

        public static int getProgramCounter()
        {
            return programCounter;
        }

        public static void setProgramCounter(int newNum)
        {
            programCounter = newNum;
        }
    }
}

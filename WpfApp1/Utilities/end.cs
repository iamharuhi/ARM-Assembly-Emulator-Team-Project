using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class End
    {

        public static void end()
        {
            RegisterClass.setProgramCounter(Int32.MaxValue);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Ldr
    {

        public static void ldr(WObj Object, int regLocation, int ramLocation, Boolean pre, Boolean post, int op)
        {
            if (pre == true)
            {
                ramLocation += op;
                Object.Registers.registerLocations[regLocation] = Object.Ram.RamLocations[ramLocation];
            }
            else if (post == true)
            {
                Object.Registers.registerLocations[regLocation] = Object.Ram.RamLocations[ramLocation];
                ramLocation += op;
            }
            else
                Object.Registers.registerLocations[regLocation] = Object.Ram.RamLocations[ramLocation];

        }

    }
}

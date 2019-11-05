using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Str
    {

        public static void str(WObj Object, int regLocation, int ramLocation, Boolean pre, Boolean post, int op)
        {
            if(pre==true)
            {
                ramLocation += op;
                Object.Ram.RamLocations[ramLocation] = Object.Registers.registerLocations[regLocation];
            }
            else if(post==true)
            {
                Object.Ram.RamLocations[ramLocation] = Object.Registers.registerLocations[regLocation];
                ramLocation += op;
            }
            else
                Object.Ram.RamLocations[ramLocation] = Object.Registers.registerLocations[regLocation];

        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
     class WObj
    {

        public RamClass Ram;
        public RegisterClass Registers;
        public Helper h;

        public WObj()
        {
            Ram = new RamClass();
            Registers = new RegisterClass();
            h = new Helper();
        }
    }
}

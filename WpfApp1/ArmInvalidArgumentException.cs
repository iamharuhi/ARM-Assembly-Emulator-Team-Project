using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ArmInvalidArgumentException : Exception
    {
        public ArmInvalidArgumentException(string message) : base(message) {
            // Thrown when syntax is correct, but the arguments don't work
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ArmSyntaxException : Exception
    {
        public ArmSyntaxException(string message) : base(message) {
            // When command structure is invalid
        }
    }
}

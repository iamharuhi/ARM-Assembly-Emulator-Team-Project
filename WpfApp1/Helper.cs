using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Helper
    {
        public BitArray FlipTheBits(BitArray bitsToFlip)
        {
            for (int i = 0; i < bitsToFlip.Length; i++)
            {
                if (bitsToFlip[i] == false) bitsToFlip[i] = true;
                else bitsToFlip[i] = false;
            }
            return bitsToFlip;
        }
        public int bitArrayToInt(BitArray b)
        {
            int output = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                {
                    output += (int)Math.Pow(2, i);
                }
            }
            return output;
        }
        public String bitArrayToHex(BitArray b)
        {
            int x = bitArrayToInt(b);
            String newHex = x.ToString("X");
            return newHex;
        }

        public BitArray hexTobitArray(String hex)
        {
            int result = Convert.ToInt32(hex, 16);
            int len = (int)Math.Pow(2, result);
            return intToBin(result, len);
        }

        public BitArray intToBin(int input, int len)
        {
            BitArray output = new BitArray(len);
            int i = 1;
            int buf;
            int ne;
            if (input < 0)
            {
                ne = 1;
                input = Math.Abs(input);
            }
            else
            {
                ne = 0;
            }
            while (input != 0 && i <= output.Length)
            {
                buf = (int)Math.Pow(2, output.Length - i);
                if (input >= buf)
                {
                    input -= buf;
                    output[i - 1] = true;
                }
                i++;
            }
            if (ne == 1)
            {
                output = twosComplement(output);
            }
            return output;
        }
        public BitArray twosComplement(BitArray input)
        { // Binary to twos complement
            BitArray output = new BitArray(input.Length);
            bool foundOne = false;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (foundOne)
                {
                    output[i] = !input[i];
                }
                else
                {
                    foundOne = input[i] == true;
                    output[i] = !input[i];
                }
            }
            return output;
        }
    }
}

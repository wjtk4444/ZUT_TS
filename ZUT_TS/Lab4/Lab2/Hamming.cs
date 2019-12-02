using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Hamming
    {
        static private readonly bool[] TRUE  = { true,  true,  true,  true,  true  };
        static private readonly bool[] FALSE = { false, false, false, false, false };
        public static BitArray encode(BitArray input)
        {
            BitArray encoded = new BitArray(input.Length * 5);
            int index = 0;
            foreach (bool value in input)
            {
                foreach (bool b in (value ? TRUE : FALSE))
                {
                    encoded.Set(index, b);
                    index++;
                }
            }

            return encoded;
        }

        public static BitArray decode(BitArray input)
        {
            BitArray decoded = new BitArray(input.Length / 5);
            int trueVal  = 0,
                falseVal = 0;

            int counter = 0;
            int index   = 0;
            foreach (bool value in input)
            {
                if (TRUE[counter % 5] == value)
                    trueVal++;
                else if (FALSE[counter % 5] == value)
                    falseVal++;

                if (counter > 0 && counter % 5 == 0)
                {
                    decoded.Set(index, trueVal > falseVal);
                    index++;

                    counter  = 0;
                    trueVal  = 0;
                    falseVal = 0;
                }
                
                counter++;
            }

            return decoded;
        }
    }
}

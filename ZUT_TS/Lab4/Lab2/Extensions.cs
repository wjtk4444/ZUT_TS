using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Extensions
    {
        public static BitArray concatenate(this BitArray b1, params BitArray[] bitArrays)
        {
            int resultSize = b1.Length;
            foreach (BitArray bitArray in bitArrays)
                resultSize += bitArray.Length;

            BitArray result = new BitArray(resultSize);

            int index = 0;
            foreach (bool b in b1)
            {
                result.Set(index, b);
                index++;
            }

            foreach (BitArray bitArray in bitArrays)
                foreach (bool b in bitArray)
                {
                    result.Set(index, b);
                    index++;
                }

            return result;
        }
    }
}

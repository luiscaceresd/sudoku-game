using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caceres_Luis_Assignment2
{
    internal class Block
    {
        public int[] values;

        public Block(int[] blockValues)
        {
            if (blockValues.Length != 9)
            {
                throw new ArgumentException("Invalid number of values. Expected 9.");
            }

            values = blockValues;
        }

        // Get values of the block
        public int[] GetValues()
        {
            return values;
        }

        public bool Validate()
        {
            // Check for duplicate values
            HashSet<int> uniqueValues = new HashSet<int>();
            foreach (int value in values)
            {
                if (uniqueValues.Contains(value))
                {
                    return false;
                }
                uniqueValues.Add(value);
            }

            return true;
        }
    }
}

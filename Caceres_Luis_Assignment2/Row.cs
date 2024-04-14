using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caceres_Luis_Assignment2
{
    internal class Row
    {
        public int[] values;

        public Row()
        {
            values = new int[9];
        }

        public Row(int[] rowValues)
        {
            if (rowValues.Length != 9)
            {
                throw new ArgumentException("Invalid number of values. Expected 9.");
            }

            values = rowValues;
        }

        public int this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

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

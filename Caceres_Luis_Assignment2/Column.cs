using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caceres_Luis_Assignment2
{
    internal class Column
    {
        private int[] values;

        public Column()
        {
            values = new int[9];
        }

        public Column(int[] columnValues)
        {
            if (columnValues.Length != 9)
            {
                throw new ArgumentException("Invalid number of values. Expected 9.");
            }

            values = columnValues;
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

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Caceres_Luis_Assignment2
{
    internal class Sudoku
    {
        private Row[] rows;
        private Column[] columns;
        private Block[] blocks;

        public Sudoku()
        {
            rows = new Row[9];
            columns = new Column[9];
            blocks = new Block[9];
        }

        public void AddRow(Row row)
        {
            // Find the first empty row slot
            int index = Array.FindIndex(rows, r => r == null);

            if (index >= 0)
            {
                rows[index] = row;
            }
            else
            {
                throw new InvalidOperationException("Cannot add more rows. The Sudoku grid is already full.");
            }
        }

        public void AddColumn(Column column)
        {
            // Find the first empty column slot
            int index = Array.FindIndex(columns, c => c == null);

            if (index >= 0)
            {
                columns[index] = column;
            }
            else
            {
                throw new InvalidOperationException("Cannot add more columns. The Sudoku grid is already full.");
            }
        }

        public void AddBlock(Block block, int index)
        {
            if (index >= 0 && index < 9)
            {
                blocks[index] = block;
            }
            else
            {
                throw new IndexOutOfRangeException("Block index must be between 0 and 8.");
            }
        }

        public void CreateGridFromString(string input)
        {
            string[] rowsData = input.Split('\n');
            if (rowsData.Length != 9)
            {
                throw new ArgumentException("Invalid input. The Sudoku grid must have exactly 9 rows.");
            }

            for (int i = 0; i < 9; i++)
            {
                string[] rowData = rowsData[i].Split(',');
                if (rowData.Length != 9)
                {
                    throw new ArgumentException("Invalid input. Each row in the Sudoku grid must have exactly 9 columns.");
                }

                int[] values = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (!int.TryParse(rowData[j], out int value))
                    {
                        throw new ArgumentException("Invalid input. The Sudoku grid must contain only integer values.");
                    }
                    values[j] = value;
                }

                Row row = new Row(values);
                AddRow(row);

                Column column = new Column(values);
                AddColumn(column);

                // Create blocks
                if (i % 3 == 2)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        int[] blockValues = new int[9];
                        for (int l = 0; l < 3; l++)
                        {
                            Array.Copy(rows[i - 2 + l].values, k * 3, blockValues, l * 3, 3);
                        }
                        Block block = new Block(blockValues);
                        AddBlock(block, (i / 3) * 3 + k);
                    }
                }
            }
        }

        public Row[] GetRows()
        {
            return rows;
        }

        public Column[] GetColumns()
        {
            return columns;
        }

        public Block[] GetBlocks()
        {
            return blocks;
        }

    }
}

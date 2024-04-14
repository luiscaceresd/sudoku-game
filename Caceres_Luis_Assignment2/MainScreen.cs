using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caceres_Luis_Assignment2
{
    public partial class MainScreen : Form
    {
        private Sudoku sudoku1;
        private Sudoku sudoku2;
        private Sudoku sudoku3;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //instantiate a file loader object
            FileLoader fileLoader = new FileLoader();
            
            //read the file
            string sudoku1String = fileLoader.ReadFile("data/sudoku1.txt");
            string sudoku2String = fileLoader.ReadFile("data/sudoku2.txt");
            string sudoku3String = fileLoader.ReadFile("data/sudoku3.txt");

            sudoku1 = new Sudoku();
            sudoku2 = new Sudoku();
            sudoku3 = new Sudoku();

            sudoku1.CreateGridFromString(sudoku1String);
            sudoku2.CreateGridFromString(sudoku2String);
            sudoku3.CreateGridFromString(sudoku3String);

            //get numeric up downs objects from form
            FetchNumericUpDowns();



        }

        private void btnLoadSudoku1_Click(object sender, EventArgs e)
        {
            // Reset all NumericUpDown colors
            ResetNumericUpDownColors();
            LoadSudokuValues(sudoku1);
        }

        private void btnLoadSudoku2_Click(object sender, EventArgs e)
        {
            // Reset all NumericUpDown colors
            ResetNumericUpDownColors();
            LoadSudokuValues(sudoku2);
        }

        private void btnLoadSudoku3_Click(object sender, EventArgs e)
        {
            // Reset all NumericUpDown colors
            ResetNumericUpDownColors();
            LoadSudokuValues(sudoku3);
        }

        private void FetchNumericUpDowns()
        {
            // Create a list to store the values
            List<int> values = new List<int>();

            // Loop through all the controls in the form
            foreach (Control control in Controls)
            {
                // Check if the control is a NumericUpDown
                if (control is NumericUpDown numericUpDown)
                {
                    // Get the value from the NumericUpDown and add it to the list
                    values.Add((int)numericUpDown.Value);
                }
            }

            // Convert the list to an array
            int[] valuesArray = values.ToArray();

            // Use the valuesArray as needed
        }

        private void LoadSudokuValues(Sudoku sudoku)
        {
            if (sudoku != null)
            {
                Row[] rows = sudoku.GetRows();
                Column[] columns = sudoku.GetColumns();

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        // Find the NumericUpDown control by name
                        string numericUpDownName = $"nud{i + 1}{j + 1}";
                        Control[] controls = this.Controls.Find(numericUpDownName, true);

                        // If the control is found and it's a NumericUpDown, set its value
                        if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown)
                        {
                            int value = rows[i][j];
                            numericUpDown.Value = value;
                        }
                    }
                }
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            // Reset all NumericUpDown colors
            ResetNumericUpDownColors();

            // Create a string representation of the current Sudoku state
            string sudokuString = CreateSudokuStringFromControls();

            // Create a new Sudoku object from the string representation
            Sudoku currentSudoku = new Sudoku();
            currentSudoku.CreateGridFromString(sudokuString);

            // Validate the Sudoku
            bool isValid = ValidateSudoku(currentSudoku);

            if (isValid)
            {
                TurnControlsToGreen();
                MessageBox.Show("Sudoku is valid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
            else
            {
                MessageBox.Show("Sudoku is invalid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Highlight invalid controls
                HighlightInvalidControls(currentSudoku);
            }
        }


        private string CreateSudokuStringFromControls()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    string numericUpDownName = $"nud{i}{j}";
                    Control[] controls = Controls.Find(numericUpDownName, true);
                    if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown)
                    {
                        sb.Append((int)numericUpDown.Value);
                    }
                    else
                    {
                        // If no control is found, assume the value is 0
                        sb.Append("0");
                    }

                    // Add a comma between each value except for the last one in a row
                    if (j < 9)
                    {
                        sb.Append(",");
                    }
                }

                // Add a newline character after each row except for the last one
                if (i < 9)
                {
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }


        private bool ValidateSudoku(Sudoku sudoku)
        {
            Row[] rows = sudoku.GetRows();
            Column[] columns = sudoku.GetColumns();
            Block[] blocks = sudoku.GetBlocks();

            foreach (Row row in rows)
            {
                if (!row.Validate())
                {
                    return false;
                }
            }

            foreach (Column column in columns)
            {
                if (!column.Validate())
                {
                    return false;
                }
            }

            foreach (Block block in blocks)
            {
                if (!block.Validate())
                {
                    return false;
                }
            }

            return true;
        }


        private void HighlightInvalidControls(Sudoku sudoku)
        {
            Row[] rows = sudoku.GetRows();
            Column[] columns = sudoku.GetColumns();
            Block[] blocks = sudoku.GetBlocks();

            for (int i = 0; i < 9; i++)
            {
                if (!rows[i].Validate())
                {
                    HighlightControlsInRow(i + 1);
                }

                if (!columns[i].Validate())
                {
                    HighlightControlsInColumn(i + 1);
                }

                if (!blocks[i].Validate())
                {
                    HighlightControlsInBlock(i + 1);
                }
            }
        }

        private void HighlightControlsInRow(int row)
        {
            for (int i = 1; i <= 9; i++)
            {
                string numericUpDownName = $"nud{row}{i}";
                Control[] controls = this.Controls.Find(numericUpDownName, true);
                if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.Red;
                }
            }
        }

        private void HighlightControlsInColumn(int column)
        {
            for (int i = 1; i <= 9; i++)
            {
                string numericUpDownName = $"nud{i}{column}";
                Control[] controls = this.Controls.Find(numericUpDownName, true);
                if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.Red;
                }
            }
        }

        private void HighlightControlsInBlock(int block)
        {
            int startRow = ((block - 1) / 3) * 3 + 1;
            int startColumn = ((block - 1) % 3) * 3 + 1;

            for (int i = startRow; i <= startRow + 2; i++)
            {
                for (int j = startColumn; j <= startColumn + 2; j++)
                {
                    string numericUpDownName = $"nud{i}{j}";
                    Control[] controls = Controls.Find(numericUpDownName, true);
                    if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown)
                    {
                        numericUpDown.BackColor = Color.Red;
                    }
                }
            }
        }

        private void TurnControlsToGreen(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.Green;
                }

                // If the control has child controls, recursively call the method
                if (control.HasChildren)
                {
                    TurnControlsToGreen(control.Controls);
                }
            }
        }

        private void TurnControlsToGreen()
        {
            TurnControlsToGreen(this.Controls);
        }


        private void ResetNumericUpDownColors(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.White;
                }

                // If the control has child controls, recursively call the method
                if (control.HasChildren)
                {
                    ResetNumericUpDownColors(control.Controls);
                }
            }
        }

        private void ResetNumericUpDownColors()
        {
            ResetNumericUpDownColors(this.Controls);
        }
    }
}

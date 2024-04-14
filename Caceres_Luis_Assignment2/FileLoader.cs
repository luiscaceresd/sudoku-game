using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caceres_Luis_Assignment2
{
    internal class FileLoader
    {
        public string ReadFile(string filePath)
        //=====================================================================================
        //
        //  Method Name         :   ReafFile
        //
        //  Developer           :   Luis Caceres
        //                          NBCC Miramichi
        //
        //  Synopsis            :   This method reads a file's content and returns it as a string.
        //
        //          Date                    Developer               Comments
        //          ====                    =========               ========
        //          Apr 13 2024             Luis Caceres            Initial Setup
        //
        //======================================================================================
        {
            // Declare a variable to hold the encrypted message
            string fileContent = string.Empty;

            try
            {
                // Declare a variable to hold each line of the file
                string inputLine;
                // Create a StreamReader object
                StreamReader inputFile;

                // Instantiate the StreamReader object and open the file
                inputFile = new StreamReader(filePath);

                // Read the first line of the file
                inputLine = inputFile.ReadLine();

                // Read the file line by line until the end of the file is reached
                while (inputLine != null)
                {
                    // Append each line to the file content
                    fileContent += inputLine;
                    inputLine = inputFile.ReadLine();
                    if (inputLine != null)
                    {
                        fileContent += "\n";
                    }
                }
                // Close the file
                inputFile.Close();
                // Return the file's content
                return fileContent;
            }
            catch (Exception ex)
            {
                // Display an error message if there is an exception
                Console.WriteLine($"Error reading file: {ex.Message}");
                // exit the program
                Environment.Exit(1);
            }

            return string.Empty;
        }
    }
}

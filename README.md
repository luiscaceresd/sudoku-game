# Sudoku Solver

## Overview

Sudoku Solver is a simple Windows Forms application that allows users to load Sudoku puzzles from files and validate them to check if they are valid or not. It provides a graphical interface for loading Sudoku puzzles, validating them, and highlighting any errors.

## Features

- **Load Puzzles:** Load Sudoku puzzles from text files.
- **Validate Puzzles:** Validate loaded Sudoku puzzles to check if they are valid or not.
- **Highlight Errors:** If a puzzle is invalid, the application highlights the cells containing errors.
- **Reset Colors:** Reset the colors of all cells to their default state.
- **Turn Controls Green:** Turn all control colors to green when a puzzle is valid.

## How to Use

1. **Load Sudoku Puzzle:**
   - Click on one of the "Load Sudoku" buttons to load a Sudoku puzzle from a file. Three different puzzles are available.
   
2. **Validate Sudoku Puzzle:**
   - Click on the "Validate" button to validate the loaded Sudoku puzzle. If the puzzle is valid, a message box will display "Sudoku is valid." If it's invalid, the cells containing errors will be highlighted in red, and a message box will display "Sudoku is invalid."
   
3. **Reset Colors:**
   - Click on the "Reset Colors" button to reset the colors of all cells to their default state (white background).
   
4. **Turn Controls Green:**
   - After validating a Sudoku puzzle, click on the "Turn Controls Green" button to turn the background color of all cells to green if the puzzle is valid.

## File Structure

- **Form1.cs:** Contains the main form and the logic for loading Sudoku puzzles, validating them, and handling user interactions.
- **Sudoku.cs:** Defines the Sudoku class and its methods for creating, validating, and manipulating Sudoku puzzles.
- **FileLoader.cs:** Provides functionality for loading Sudoku puzzles from text files.

## Requirements

- Windows operating system
- .NET Framework

## How to Run

1. Clone this repository to your local machine.
2. Open the solution file (`.sln`) in Visual Studio.
3. Build the solution.
4. Run the application.

## Credits

- Developed by [Your Name]

## License

This project is licensed under the [MIT License](LICENSE).

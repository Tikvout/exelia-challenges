using System;
using System.Collections.Generic;

namespace _2_algorithm_test {
    class ValidSudoku {
        static void Main(string[] args) {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},
                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},
                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };

            if(Validate(goodSudoku1)) {
                Console.WriteLine("Good sudoku");
            }
        }

        public static bool Validate(int[][] sudoku) {
            if(
                ValidateRows(sudoku) &&
                ValidateColumns(sudoku) &&
                ValidateBlocks(sudoku)
            ) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidateRows(int[][] sudoku) {
            int numberBeingChecked; // Used to check for duplicates
            // check all rows for duplicate values
            // a duplication will mean a fail
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // assign the current column number to the number being checked variable
                    numberBeingChecked = sudoku[row][col];
                    for (int index = col + 1; index < 9; index++)
                    {
                        // check if the number being checked appears anywhere throught the list
                        if (numberBeingChecked == sudoku[row][index])
                        {
                            // Failed, opt out of the function - It is indeed a bad sudoku (duplicate in column)
                            Console.WriteLine("Failed - " + numberBeingChecked + " " + sudoku[row][index] + " in row:" + row + " col:" + col);
                            return false;
                        }
                    }

                }
            }
            return true;
        }

        public static bool ValidateColumns(int[][] sudoku) {
            int numberBeingChecked; // Used to check for duplicates
            // check all columns for duplicate values
            // a duplication will mean a fail
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    numberBeingChecked = sudoku[row][col];
                    for (int index = row + 1; index < 9; index++)
                    {
                        // check if the number being checked appears anywhere throught the list
                        if (numberBeingChecked == sudoku[index][col])
                        {
                            // Failed, opt out of the function - It is indeed a bad sudoku (duplicate in row)
                            Console.WriteLine("Failed - " + numberBeingChecked + " " + sudoku[index][col] + " in row:" + row + " col:" + col);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static bool ValidateBlocks(int[][] sudoku) {
            int numberBeingChecked; // Used to check for duplicates
            // check the 9 blocks (each block consists of 3 rows and 3 columns)
            // a duplication will mean a fail
            int xStart;
            int yStart;
            for (int block = 0; block < 9; block++) {
                xStart = (block / 3) * 3;
                yStart = (block % 3) *3;
                // We create an empty block numbers list in every block loop.
                // We check if the number being checked already exists within the array (if not append the number)
                // string[] blockNumbers = {};
                List<int> blockNumbers = new List<int>();
                // go through all the rows in the block
                for (int row = xStart; row < xStart + 3; row++) {
                    // go through all the rows in the block
                    for (int col = yStart; col < yStart + 3; col++) {
                        numberBeingChecked = sudoku[row][col];
                        // check if value already exists within list
                        // if it exists it means it's a duplicate
                        // else append the value to the list and move on to the next number
                        if(blockNumbers.Contains(numberBeingChecked)) {
                            // Failed, opt out of the function - It is indeed a bad sudoku(duplicate in block)
                            Console.WriteLine("Failed - " + numberBeingChecked + " in block " + (block+1) + " in row:" + row + " col:" + col);
                            return false;
                        } else {
                            blockNumbers.Add(numberBeingChecked);
                        }
                    }
                }
            }
            return true;
        }
    }
}

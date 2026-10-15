using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_TAC_Toe
{
    internal class Logic
    {
        const int FIRST_ARRAY_POSITION = Constants.FIRST_ARRAY_POSITION;
        static public bool CheckWinner(char[,] grid, int gridSideSize, out char winningChar)
        {
            return (CheckWinningRow(grid, gridSideSize, out winningChar) || CheckWinningColumn(grid, gridSideSize, out winningChar) || CheckWinningDiagonals(grid, gridSideSize, out winningChar));
        }

        static public char[,] FillFieldWithEmptyChars(char[,] grid, int gridSideSize)
        {
            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    grid[row, col] = '\0';
                }
            }
            return grid;
        }

        static public (int, int) FillRandomField(char xOrOComputer, char[,] grid, int gridSideSize)
        {
            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    if (!FieldIsFull(grid[row, col])) return (row, col);
                }
            }
            return (-1, -1);
        }
        static public bool FieldIsFull(char grid)
        {
            if (grid != '\0') return true;
            else return false;
        }
        static public bool GridIsFull(char[,] grid, int gridSideSize)
        {
            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    if (!FieldIsFull(grid[row, col])) return false;
                }
            }
            return true;
        }

        static public bool CheckWinningRow(char[,] grid, int gridSideSize, out char winningChar)
        {
            winningChar = '\0';
            char[] trackWinningRow = new char[gridSideSize];
            bool rowIsEqual = true;

            for (int row = 0; row < gridSideSize; row++)
            {
                rowIsEqual = true;

                for (int col = 0; col < gridSideSize; col++)
                {
                    trackWinningRow[col] = grid[row, col];
                    if (trackWinningRow[col] != trackWinningRow[FIRST_ARRAY_POSITION] || trackWinningRow[col] == '\0')
                    {
                        rowIsEqual = false;
                    }
                }
                if (rowIsEqual)
                {
                    winningChar = trackWinningRow[FIRST_ARRAY_POSITION];
                    return rowIsEqual;
                }
            }
            return rowIsEqual;

        }

        /// <summary>
        /// Checks if a row has 2 conscutive 'x' or 'o' charachters
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridSideSize"></param>
        /// <returns>number of the row that has 2 conscutive 'x' or 'o' charachters</returns>
        static public bool CheckRowWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cnt)
        {
            int[] trackWinningRow = new int[gridSideSize];
            bool rowIsEqual = true;
            cnt = 0;

            for (int row = 0; row < gridSideSize; row++)
            {
                cnt = 0;
                for (int col = 0; col < gridSideSize; col++)
                {
                    rowIsEqual = true;
                    trackWinningRow[col] = grid[row, col];
                    if (trackWinningRow[col] != xOrO)
                    {
                        rowIsEqual = false;
                        cnt = 0;
                    }
                    if (rowIsEqual) cnt++;
                    if (cnt == 2) break;
                }
                if (cnt == 2) break;
            }
            if (cnt == 2) return true;
            else return false;
        }



        static public bool CheckWinningColumn(char[,] grid, int gridSideSize, out char winningChar)
        {
            winningChar = '\0';
            char[] trackWinningCol = new char[gridSideSize];
            bool colIsEqual = true;

            for (int row = 0; row < gridSideSize; row++)
            {
                colIsEqual = true;
                for (int col = 0; col < gridSideSize; col++)
                {
                    trackWinningCol[col] = grid[col, row];
                    if (trackWinningCol[col] != trackWinningCol[FIRST_ARRAY_POSITION] || trackWinningCol[col] == '\0')
                    {
                        colIsEqual = false;
                    }
                }
                if (colIsEqual)
                {
                    winningChar = trackWinningCol[FIRST_ARRAY_POSITION];
                    return colIsEqual;
                }
            }
            return colIsEqual;

        }

        static public bool CheckColWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cnt)
        {
            int[] trackWinningRow = new int[gridSideSize];
            bool rowIsEqual = true;
            cnt = 0;

            for (int row = 0; row < gridSideSize; row++)
            {
                cnt = 0;
                for (int col = 0; col < gridSideSize; col++)
                {
                    rowIsEqual = true;
                    trackWinningRow[col] = grid[col, row];
                    if (trackWinningRow[col] != xOrO)
                    {
                        rowIsEqual = false;
                        cnt = 0;
                    }
                    if (rowIsEqual) cnt++;
                    if (cnt == 2) break;
                }
                if (cnt == 2) break;
            }
            if (cnt == 2) return true;
            else return false;
        }
        static public bool CheckWinningDiagonals(char[,] grid, int gridSideSize, out char winningChar)
        {
            winningChar = '\0';
            char[] trackWinningDiagonalOne = new char[gridSideSize];
            char[] trackWinningDiagonalTwo = new char[gridSideSize];

            bool diagOneIsEqual = true, diagTwoIsEqual = true;

            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    if (col == row)
                    {
                        trackWinningDiagonalOne[col] = grid[col, row];

                        if (trackWinningDiagonalOne[col] != trackWinningDiagonalOne[FIRST_ARRAY_POSITION] || trackWinningDiagonalOne[col] == '\0')
                        {
                            diagOneIsEqual = false;
                        }
                    }
                    if (col == gridSideSize - 1 - row)
                    {
                        trackWinningDiagonalTwo[row] = grid[row, col];

                        if (trackWinningDiagonalTwo[row] != trackWinningDiagonalTwo[FIRST_ARRAY_POSITION] || trackWinningDiagonalTwo[row] == '\0')
                        {
                            diagTwoIsEqual = false;
                        }
                    }

                }
            }
            if (diagOneIsEqual)
            {
                winningChar = trackWinningDiagonalOne[FIRST_ARRAY_POSITION];
            }
            if (diagTwoIsEqual)
            {
                winningChar = trackWinningDiagonalTwo[FIRST_ARRAY_POSITION];
            }

            return (diagOneIsEqual || diagTwoIsEqual);
        }
        static public bool CheckDiagsWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cntDiag1, out int cntDiag2)
        {
            int[] trackWinningDiagonalOne = new int[gridSideSize];
            int[] trackWinningDiagonalTwo = new int[gridSideSize];

            bool diagOneIsEqual = false, diagTwoIsEqual = false;
            cntDiag1 = 0;
            cntDiag2 = 0;

            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    diagOneIsEqual = true;
                    diagTwoIsEqual = true;
                    if (col == row)
                    {
                        trackWinningDiagonalOne[col] = grid[col, row];

                    }
                    if (trackWinningDiagonalOne[col] != xOrO)
                    {
                        diagOneIsEqual = false;
                        cntDiag1 = 0;
                    }
                    if (col == gridSideSize - 1 - row)
                    {
                        trackWinningDiagonalTwo[row] = grid[col, row];

                    }
                    if (trackWinningDiagonalTwo[col] != xOrO)
                    {
                        diagTwoIsEqual = false;
                        cntDiag2 = 0;
                    }

                    if (diagOneIsEqual) cntDiag1++;
                    if (diagTwoIsEqual) cntDiag2++;
                    if (cntDiag1 == 2 || cntDiag2 == 2) break;
                }
                if (cntDiag1 == 2 || cntDiag2 == 2) break;
            }
            if (cntDiag1 == 2 || cntDiag2 == 2) return true;
            else return false;
        }
    }
}

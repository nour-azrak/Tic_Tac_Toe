namespace Tic_TAC_Toe
{
    internal class Logic
    {
        const int FIRST_ARRAY_POSITION = 0;
        static void Main(string[] args)
        {
            const int GRID_SIDE_SIZE = 3;
            char[,] grid = new char[GRID_SIDE_SIZE, GRID_SIDE_SIZE];
            int x, y;
            char xOrO;
            char xOrOComputer;

            UI.Welcome();
            xOrO = UI.XOChoice();
            if (xOrO == 'x') xOrOComputer = 'o';
            else xOrOComputer = 'x';
            bool usersTurn = true;

            while (true)
            {
                usersTurn = true;
                UI.YouOrComputerTurn(usersTurn);
                (x, y) = UI.GetCoordinates(xOrO, GRID_SIDE_SIZE);
                if (FieldIsFull(grid, x - 1, y - 1))
                {
                    UI.ReEnterCoordinates();
                    continue;
                }
                grid[x - 1, y - 1] = xOrO;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                // Computers turn
                usersTurn = false;
                UI.YouOrComputerTurn(usersTurn);
                (x, y) = FillRandomField(xOrOComputer, grid, GRID_SIDE_SIZE);
                grid[x, y] = xOrOComputer;

            }


        }

        static (int,int) FillRandomField(char xOrOComputer, char[,] grid, int gridSideSize)
        {
            for (int row =0; row < gridSideSize; row++)
            {
                for (int col =0; col < gridSideSize; col++)
                {
                    if(!FieldIsFull(grid,row,col)) return (row,col);
                }
            }
            Console.WriteLine("all fields are full");
            return (-1,-1);
        }
        static bool FieldIsFull(char[,] grid, int row, int col)
        {
            if (grid[row, col] != '\0') return true;
            else return false;
        }

        static bool CheckWinningRow(char[,] grid, int gridSideSize)
        {
            int[] trackWinningRow = new int[gridSideSize];
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
                if (rowIsEqual) return rowIsEqual;
            }
            return rowIsEqual;

        }

        /// <summary>
        /// Checks if a row has 2 conscutive 'x' or 'o' charachters
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridSideSize"></param>
        /// <returns>number of the row that has 2 conscutive 'x' or 'o' charachters</returns>
        static bool CheckRowWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cnt)
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



        static bool CheckWinningColumn(char[,] grid, int gridSideSize)
        {
            int[] trackWinningCol = new int[gridSideSize];
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
                if (colIsEqual) return colIsEqual;
            }
            return colIsEqual;

        }

        static bool CheckColWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cnt)
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
        static bool CheckWinningDiagonals(char[,] grid, int gridSideSize)
        {
            int[] trackWinningDiagonalOne = new int[gridSideSize];
            int[] trackWinningDiagonalTwo = new int[gridSideSize];

            bool diagOneIsEqual = false, diagTwoIsEqual = false;

            for (int row = 0; row < gridSideSize; row++)
            {
                diagOneIsEqual = true;
                diagTwoIsEqual = true;
                for (int col = 0; col < gridSideSize; col++)
                {
                    if (col == row)
                    {
                        trackWinningDiagonalOne[col] = grid[col, row];

                    }
                    if (trackWinningDiagonalOne[col] != trackWinningDiagonalOne[FIRST_ARRAY_POSITION] || trackWinningDiagonalOne[col] == '\0')
                    {
                        diagOneIsEqual = false;
                    }
                    if (col == gridSideSize - 1 - row)
                    {
                        trackWinningDiagonalTwo[col] = grid[col, row];

                    }
                    if (trackWinningDiagonalTwo[col] != trackWinningDiagonalTwo[FIRST_ARRAY_POSITION] || trackWinningDiagonalTwo[col] == '\0')
                    {
                        diagTwoIsEqual = false;
                    }

                }
                if (diagOneIsEqual || diagTwoIsEqual) return true;
            }

            return (diagOneIsEqual && diagTwoIsEqual);
        }
        static bool CheckDiagsWith2XO(char[,] grid, int gridSideSize, char xOrO, out int cntDiag1, out int cntDiag2)
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

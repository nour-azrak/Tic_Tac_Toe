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
            char xOrOUser;
            char xOrOComputer;
            bool usersTurn;
            char winningChar;
            int userWins = 0, computerWins = 0, drwas = 0;

            UI.Welcome();
            xOrOUser = UI.XOChoice();
            if (xOrOUser == 'x') xOrOComputer = 'o';
            else xOrOComputer = 'x';

            while (true)
            {
                //Users turn
                usersTurn = true;
                UI.YouOrComputerTurn(usersTurn);
                (x, y) = UI.GetCoordinates(xOrOUser, GRID_SIDE_SIZE);
                if (FieldIsFull(grid[x, y]))
                {
                    UI.ReEnterCoordinates();
                    continue;
                }
                grid[x, y] = xOrOUser;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                // Check winner after every turn
                if (CheckWinner(grid, GRID_SIDE_SIZE, out winningChar))
                {
                    if (winningChar == xOrOUser)
                    {
                        UI.PrintWinner(winningChar, xOrOUser);
                        userWins++;
                    }
                    else
                    {
                        UI.PrintWinner(winningChar, xOrOUser);
                        computerWins++;
                    }
                    UI.PrintCurrentStandings(userWins, computerWins, drwas);
                    grid = FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    continue;
                }
                if (GridIsFull(grid, GRID_SIDE_SIZE))
                {
                    UI.PrintDraw();
                    grid = FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    drwas++;
                    UI.PrintCurrentStandings(userWins, computerWins, drwas);
                    continue;
                }

                // Computers turn
                usersTurn = false;
                UI.YouOrComputerTurn(usersTurn);
                (x, y) = FillRandomField(xOrOComputer, grid, GRID_SIDE_SIZE);
                grid[x, y] = xOrOComputer;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                // Check winner after every turn
                if (CheckWinner(grid, GRID_SIDE_SIZE, out winningChar))
                {
                    if (winningChar == xOrOUser)
                    {
                        UI.PrintWinner(winningChar, xOrOUser);
                        userWins++;
                    }
                    else
                    {
                        UI.PrintWinner(winningChar, xOrOUser);
                        computerWins++;
                    }
                    UI.PrintCurrentStandings(userWins, computerWins, drwas);
                    grid = FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    continue;
                }
            }
        }

        static bool CheckWinner(char[,] grid, int gridSideSize, out char winningChar)
        {
            return (CheckWinningRow(grid, gridSideSize, out winningChar) || CheckWinningColumn(grid, gridSideSize, out winningChar) || CheckWinningDiagonals(grid, gridSideSize, out winningChar));
        }

        static char[,] FillFieldWithEmptyChars(char[,] grid, int gridSideSize)
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

        static (int, int) FillRandomField(char xOrOComputer, char[,] grid, int gridSideSize)
        {
            for (int row = 0; row < gridSideSize; row++)
            {
                for (int col = 0; col < gridSideSize; col++)
                {
                    if (!FieldIsFull(grid[row, col])) return (row, col);
                }
            }
            Console.WriteLine("all fields are full");
            return (-1, -1);
        }
        static bool FieldIsFull(char grid)
        {
            if (grid != '\0') return true;
            else return false;
        }
        static bool GridIsFull(char[,] grid, int gridSideSize)
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

        static bool CheckWinningRow(char[,] grid, int gridSideSize, out char winningChar)
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



        static bool CheckWinningColumn(char[,] grid, int gridSideSize, out char winningChar)
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
        static bool CheckWinningDiagonals(char[,] grid, int gridSideSize, out char winningChar)
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

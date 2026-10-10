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

            UI.Welcome();
            xOrO = UI.XOChoice();

            while (true)
            {
                (x, y) = UI.GetCoordinates(xOrO, GRID_SIDE_SIZE);
                if (FieldIsFull(grid,x-1,y-1))
                {
                    UI.ReEnterCoordinates();
                    continue;
                }
                grid[x - 1, y - 1] = xOrO;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                if (CheckWinningRow(grid, GRID_SIDE_SIZE))
                {
                    Console.WriteLine("Winning Row");
                }

                if (CheckWinningColumn(grid, GRID_SIDE_SIZE))
                {
                    Console.WriteLine("Winning Col");
                }

                if (CheckWinningDiagonals(grid, GRID_SIDE_SIZE))
                {
                    Console.WriteLine("Winning Diags");
                }
            }


        }

       
        static bool FieldIsFull(char[,] grid, int row, int col)
        {
            if (grid[row,col] != '\0') return true;
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
    }
}

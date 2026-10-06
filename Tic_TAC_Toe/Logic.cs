namespace Tic_TAC_Toe
{
    internal class Logic
    {
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
            }


        }

       
        static bool FieldIsFull(char[,] grid, int row, int col)
        {
            if (grid[row,col] != '\0') return true;
            else return false;
        }
    }
}

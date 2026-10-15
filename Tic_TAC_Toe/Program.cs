namespace Tic_TAC_Toe
{
    internal class Program
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

            UI.PrintWelcomeMessage();
            xOrOUser = UI.GetXOChoice();
            if (xOrOUser == 'x') xOrOComputer = 'o';
            else xOrOComputer = 'x';

            while (true)
            {
                //Users turn
                usersTurn = true;
                UI.PrintUserOrComputerTurn(usersTurn);
                (x, y) = UI.GetCoordinates(xOrOUser, GRID_SIDE_SIZE);
                if (Logic.FieldIsFull(grid[x, y]))
                {
                    UI.ReEnterCoordinates();
                    continue;
                }
                grid[x, y] = xOrOUser;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                // Check winner after every turn
                if (Logic.CheckWinner(grid, GRID_SIDE_SIZE, out winningChar))
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
                    grid = Logic.FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    continue;
                }
                if (Logic.GridIsFull(grid, GRID_SIDE_SIZE))
                {
                    UI.PrintDraw();
                    grid = Logic.FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    drwas++;
                    UI.PrintCurrentStandings(userWins, computerWins, drwas);
                    continue;
                }

                // Computers turn
                usersTurn = false;
                UI.PrintUserOrComputerTurn(usersTurn);
                (x, y) = Logic.FillRandomField(xOrOComputer, grid, GRID_SIDE_SIZE);
                grid[x, y] = xOrOComputer;
                UI.PrintGrid(GRID_SIDE_SIZE, grid);

                // Check winner after every turn
                if (Logic.CheckWinner(grid, GRID_SIDE_SIZE, out winningChar))
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
                    grid = Logic.FillFieldWithEmptyChars(grid, GRID_SIDE_SIZE);
                    continue;
                }
            }
        }

       
    }
}

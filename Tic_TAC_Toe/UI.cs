using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_TAC_Toe
{
    internal class UI
    {
        const int GRID_FIRST_COORDINATE = 1;

        static public void Welcome()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("The grid consists of 3x3 fields");
            Console.WriteLine("First, you choose whether you want to play as x or o");
            Console.WriteLine("Then, you input the x,y coordinates where to play your next move when it is your turn");
            Console.WriteLine("The coordinates must be at least 1 and maximum 3");

        }

        static public void ReEnterCoordinates()
        {
            Console.WriteLine("This field is full. Please reenter coordinates");
        }

        static public char XOChoice()
        {
            Console.Write("Please choose whether you want to play as x or o: ");
            char xOrO;
            bool validUserInput;
            while (true)
            {
                validUserInput = char.TryParse(Console.ReadLine().ToLower(), out xOrO) && (xOrO == 'x' || xOrO == 'o');
                if (!validUserInput)
                {
                    Console.Write("Please input x or o: ");

                }
                else break;
            }
            return xOrO;
        }

        /// <summary>
        /// Prints current Tic Tac Toe grid
        /// </summary>
        /// <param name="sizeOfGridSize"></param>
        /// <param name="grid"></param>
        static public void PrintGrid(int sizeOfGridSize, char[,] grid)
        {
            for (int row = 0; row < sizeOfGridSize; row++)
            {
                for (int col = 0; col < sizeOfGridSize; col++)
                {
                    if (grid[row, col] == '\0')
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(grid[row, col] + " ");
                    }
                    if (col == sizeOfGridSize - 1) break;
                    Console.Write("|");

                }
                Console.WriteLine();
                if (row == sizeOfGridSize - 1) break;
                for (int col = 0; col < sizeOfGridSize; col++)
                {
                    Console.Write("--");
                    if (col == sizeOfGridSize - 1) break;
                    Console.Write("-");


                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// This methode returns the x and y coordinate of the user choice
        /// on where to place the 'x' or the 'y' on the grid
        /// </summary>
        /// <param name="xOrO">User input 'x' or 'y'</param>
        /// <param name="gridSize">Grid side size should be 3. This parameter is there to avoid using magic numbers inside the function</param>
        /// <returns> returns x and y coordinates</returns>
        static public (int, int) GetCoordinates(char xOrO, int gridSize)
        {

            int x, y;
            Console.Write($"please provide the X coordinate you want to place \'{xOrO}\': ");
            bool validUserInput = true;

            while (true)
            {
                validUserInput = int.TryParse(Console.ReadLine(), out x) && x >= GRID_FIRST_COORDINATE && x <= gridSize;
                if (!validUserInput)
                {
                    Console.Write($"Please enter a positive whole number between {GRID_FIRST_COORDINATE} and {gridSize}: ");
                    continue;
                }
                else break;

            }
            Console.Write($"please provide the Y coordinate you want to place \'{xOrO}\': ");
            while (true)
            {
                validUserInput = int.TryParse(Console.ReadLine(), out y) && y >= GRID_FIRST_COORDINATE && y <= gridSize;
                if (!validUserInput)
                {
                    Console.Write($"Please enter a positive whole number between {GRID_FIRST_COORDINATE} and {gridSize}: ");
                    continue;
                }
                else break;

            }
            return (x, y);
        }
    }
}

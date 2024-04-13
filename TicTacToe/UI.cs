using System;

namespace TicTacToe
{
    public class UI
    {
        const char X_PLAYER_VALUE = 'X';
        public static void DisplayGrid(char[,] grid)
        {
            // Displaying the grid
            Console.Write("  ");
            for (int j = 0; j < Program.GRID_SIZE; j++)
            {
                Console.Write((j + 1) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < Program.GRID_SIZE; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < Program.GRID_SIZE; j++)
                {
                    if (grid[i, j] != ' ')
                    {
                        Console.Write(grid[i, j]);
                    }
                    else
                    {
                        Console.Write("_");
                    }

                    if (j < Program.GRID_SIZE - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void UserMove(char[,] grid)
        {
            // Allow the user to make a move
            bool validMove = false;
            while (!validMove)
            {
                Console.Write("Choose a row between (1, 2 or 3): ");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Choose a column between (1, 2 or 3): ");
                int column = int.Parse(Console.ReadLine()) - 1;

                if (Logic.IsValidMove(grid, row, column))
                {
                    grid[row, column] = X_PLAYER_VALUE;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid spot. Please try again.");
                }
            }
        }

        public static void AIMove(char[,] grid)
        {
            // AI move
            Random rand = new Random();
            int row, column;
            do
            {
                row = rand.Next(0, Program.GRID_SIZE);
                column = rand.Next(0, Program.GRID_SIZE);
            } while (!Logic.IsValidMove(grid, row, column));

            grid[row, column] = 'O';
        }

        public static void DisplayGameOverMessage(char winner)
        {
            // Displaying the end of the game
            if (winner != ' ')
            {
                Console.WriteLine("Well done, " + winner + " is the winner!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }

       
    }
}


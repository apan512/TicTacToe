using System;

namespace TicTacToe
{
    public class UI
    {
        public static readonly Random rand = new Random();
        public static void DisplayGrid(char[,] grid)
        {
            Console.Write(Constants.SECOND_EMPTY_STRING);
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                Console.Write((j + 1) + Constants.EMPTY_STRING);
            }
            Console.WriteLine();

            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                Console.Write((i + 1) + Constants.EMPTY_STRING);
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (grid[i, j] != Constants.EMPTY_CHAR)
                    {
                        Console.Write(grid[i, j]);
                    }
                    else
                    {
                        Console.Write(Constants.SPECIAL_STRING_CHAR_GRID);
                    }

                    if (j < Constants.GRID_SIZE - 1)
                    {
                        Console.Write(Constants.EMPTY_STRING);
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
                        grid[row, column] = Constants.X_PLAYER_VALUE;
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
                int row, column;
                do
                {
                    row = rand.Next(0, Constants.GRID_SIZE);
                    column = UI.rand.Next(0, Constants.GRID_SIZE);
                } while (!Logic.IsValidMove(grid, row, column));

                grid[row, column] = Constants.AI_PLAYER_VALUE;
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
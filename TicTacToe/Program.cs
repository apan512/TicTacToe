using System;

namespace TicTacToe
{
    class Program
    {
        const int GRID_SIZE = 3;

        static void Main(string[] args)
        {
            char[,] grid = new char[GRID_SIZE, GRID_SIZE];

            InitializeGrid(grid);
            DisplayGrid(grid);

            while (!IsGameOver(grid))
            {
                Console.WriteLine("Your turn.");

                UserMove(grid);
                DisplayGrid(grid);

                if (IsGameOver(grid))
                    break;

                Console.WriteLine("AI turn.");

                AIMove(grid);
                DisplayGrid(grid);
            }

            char winner = CheckWinner(grid);
            if (winner != ' ')
            {
                Console.WriteLine("Well done, " + winner + " is the winner!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }

        static void InitializeGrid(char[,] grid)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        static void DisplayGrid(char[,] grid)
        {
            Console.Write("  ");
            for (int j = 0; j < GRID_SIZE; j++)
            {
                Console.Write((j + 1) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < GRID_SIZE; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (grid[i, j] != ' ')
                    {
                        Console.Write(grid[i, j]);
                    }
                    else
                    {
                        Console.Write("_");
                    }

                    if (j < GRID_SIZE - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void UserMove(char[,] grid)
        {
            bool validMove = false;
            while (!validMove)
            {
                Console.Write("Choose a row between (1, 2 or 3): ");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Choose a column between (1, 2 or 3): ");
                int column = int.Parse(Console.ReadLine()) - 1;

                if (IsValidMove(grid, row, column))
                {
                    grid[row, column] = 'X';
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid spot. Please try again.");
                }
            }
        }

        static void AIMove(char[,] grid)
        {
            Random rand = new Random();
            int row, column;
            do
            {
                row = rand.Next(0, GRID_SIZE);
                column = rand.Next(0, GRID_SIZE);
            } while (!IsValidMove(grid, row, column));

            grid[row, column] = 'O';
        }

        static bool IsValidMove(char[,] grid, int row, int column)
        {
            return row >= 0 && row < GRID_SIZE && column >= 0 && column < GRID_SIZE && grid[row, column] == ' ';
        }

        static bool IsGameOver(char[,] grid)
        {
            return CheckWinner(grid) != ' ' || IsBoardFull(grid);
        }

        static char CheckWinner(char[,] grid)
        {
            // Checking if there is a winner on rows, columns or diagonals
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (grid[i, 0] != ' ' && grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                    return grid[i, 0];
                if (grid[0, i] != ' ' && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                    return grid[0, i];
            }

            if (grid[0, 0] != ' ' && grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                return grid[0, 0];
            if (grid[0, 2] != ' ' && grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
                return grid[0, 2];

            return ' '; // No winner
        }

        static bool IsBoardFull(char[,] grid)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (grid[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}









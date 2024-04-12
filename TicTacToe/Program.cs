using System;

namespace TicTacToe
{
    class Program
    {
        public const int GRID_SIZE = 3;

        static void Main(string[] args)
        {
            char[,] grid = new char[GRID_SIZE, GRID_SIZE];

            Logic.InitializeGrid(grid);
            UI.DisplayGrid(grid);

            while (!Logic.IsGameOver(grid))
            {
                Console.WriteLine("Your turn.");
                UI.UserMove(grid);
                UI.DisplayGrid(grid);

                if (Logic.IsGameOver(grid))
                    break;

                Console.WriteLine("AI turn.");
                UI.AIMove(grid);
                UI.DisplayGrid(grid);
            }

            char winner = Logic.CheckWinner(grid);
            UI.DisplayGameOverMessage(winner);
        }
    }
}

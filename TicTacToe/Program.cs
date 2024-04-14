using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[Constants.GRID_SIZE, Constants.GRID_SIZE];

            Logic.InitializeGrid(grid);
            UI.DisplayGrid(grid);

            while (!Logic.IsGameOver(grid))
            {
                UI.DisplayMessage("Your turn.");
                UI.UserMove(grid);
                UI.DisplayGrid(grid);

                if (Logic.IsGameOver(grid))
                    break;

                UI.DisplayMessage("AI turn.");
                UI.AIMove(grid);
                UI.DisplayGrid(grid);
            }

            char winner = Logic.CheckWinner(grid);
            UI.DisplayGameOverMessage(winner);
        }
    }
}



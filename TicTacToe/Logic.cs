namespace TicTacToe
{
    public class Logic
    {
        public static bool IsValidMove(char[,] grid, int row, int column)
        {
            // Checking for invalid move
            return row >= 0 && row < Program.GRID_SIZE && column >= 0 && column < Program.GRID_SIZE && grid[row, column] == ' ';
        }

        public static bool IsGameOver(char[,] grid)
        {
            // Checking if the game is over
            return CheckWinner(grid) != ' ' || IsBoardFull(grid);
        }

        public static char CheckWinner(char[,] grid)
        {
            // Checking if there is a winner
            for (int i = 0; i < Program.GRID_SIZE; i++)
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

        public static bool IsBoardFull(char[,] grid)
        {
            // Checking if the grid is full
            for (int i = 0; i < Program.GRID_SIZE; i++)
            {
                for (int j = 0; j < Program.GRID_SIZE; j++)
                {
                    if (grid[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

        public static void InitializeGrid(char[,] grid)
        {
            // Initialize the grid
            for (int i = 0; i < Program.GRID_SIZE; i++)
            {
                for (int j = 0; j < Program.GRID_SIZE; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }
    }
}




namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        public class PlayerScore
        {
            string name;
            int score;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Score
            {
                get { return score; }
                set { score = value; }
            }

            public PlayerScore() { }

            public PlayerScore(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }

        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] playField = CreatePlayField();
            char[,] mines = placeMines();
            int counter = 0;
            bool isMineHitted = false;
            List<PlayerScore> highScores = new List<PlayerScore>(6);
            int row = 0;
            int column = 0;
            bool isStartingNewGame = true;
            const int MaxCells = 35; // or MAX_CELLS
            bool isGameWon = false;

            do
            {
                if (isStartingNewGame)
                {
                    Console.WriteLine("Lets play “Minesweeper”. Try our luck to find the fields without mines." +
                                      " Comman 'top' show the score chart, 'restart' start new game, 'exit' exit the game!");

                    DrawGameField(playField);
                    isStartingNewGame = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playField.GetLength(0) && column <= playField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreChart(highScores);
                        break;
                    case "restart":
                        playField = CreatePlayField();
                        mines = placeMines();
                        DrawGameField(playField);
                        isMineHitted = false;
                        isStartingNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                MakeMove(playField, mines, row, column);
                                counter++;
                            }

                            if (MaxCells == counter)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                DrawGameField(playField);
                            }
                        }
                        else
                        {
                            isMineHitted = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isMineHitted)
                {
                    DrawGameField(mines);
                    Console.Write("\nHrrrrrr! You are dead with {0} points. " +
                                  "Write yor nickname: ", counter);

                    string nickname = Console.ReadLine();
                    PlayerScore currentPlayer = new PlayerScore(nickname, counter);

                    if (highScores.Count < 5)
                    {
                        highScores.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Score < currentPlayer.Score)
                            {
                                highScores.Insert(i, currentPlayer);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Name.CompareTo(r1.Name));
                    highScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Score.CompareTo(r1.Score));
                    ShowScoreChart(highScores);

                    playField = CreatePlayField();
                    mines = placeMines();
                    counter = 0;
                    isMineHitted = false;
                    isStartingNewGame = true;
                }

                if (isGameWon)
                {
                    Console.WriteLine("\nCongratulations! You've opened 35 cells!");
                    DrawGameField(mines);

                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();

                    PlayerScore currentPlayerScore = new PlayerScore(nickname, counter);
                    highScores.Add(currentPlayerScore);
                    ShowScoreChart(highScores);

                    playField = CreatePlayField();
                    mines = placeMines();
                    counter = 0;
                    isGameWon = false;
                    isStartingNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Bye!");
            Console.Read();
        }

        private static void ShowScoreChart(List<PlayerScore> scores)
        {
            Console.WriteLine("\nScores:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells",
                        i + 1, scores[i].Name, scores[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty chart!\n");
            }
        }

        private static void MakeMove(char[,] playField, char[,] mines, int row, int column)
        {
            char amountOfMines = CalculateAmountOfMines(mines, row, column);

            mines[row, column] = amountOfMines;
            playField[row, column] = amountOfMines;
        }

        private static void DrawGameField(char[,] board)
        {
            int fieldRows = board.GetLength(0);
            int fieldCols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < fieldRows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < fieldCols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int fieldRows = 5;
            int fieldCols = 10;
            char[,] playField = new char[fieldRows, fieldCols];

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldCols; j++)
                {
                    playField[i, j] = '?';
                }
            }

            return playField;
        }

        private static char[,] placeMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> minesLocation = new List<int>();

            while (minesLocation.Count < 15)
            {
                Random random = new Random();

                int randomPlayFieldLocation = random.Next(50);

                if (!minesLocation.Contains(randomPlayFieldLocation))
                {
                    minesLocation.Add(randomPlayFieldLocation);
                }
            }

            foreach (int location in minesLocation)
            {
                int col = (location / cols);
                int row = (location % cols);

                if (row == 0 && location != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        // This method has 0 references. It is never called!
        private static void AssignSurroundingMinesNumber(char[,] playField)
        {
            int col = playField.GetLength(0);
            int row = playField.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playField[i, j] != '*')
                    {
                        char amountOfMines = CalculateAmountOfMines(playField, i, j);
                        playField[i, j] = amountOfMines;
                    }
                }
            }
        }

        private static char CalculateAmountOfMines(char[,] playField, int row, int column)
        {
            int amount = 0;
            int rows = playField.GetLength(0);
            int columns = playField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playField[row - 1, column] == '*')
                {
                    amount++;
                }
            }

            if (row + 1 < rows)
            {
                if (playField[row + 1, column] == '*')
                {
                    amount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (playField[row, column - 1] == '*')
                {
                    amount++;
                }
            }

            if (column + 1 < columns)
            {
                if (playField[row, column + 1] == '*')
                {
                    amount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (playField[row - 1, column - 1] == '*')
                {
                    amount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (playField[row - 1, column + 1] == '*')
                {
                    amount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (playField[row + 1, column - 1] == '*')
                {
                    amount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (playField[row + 1, column + 1] == '*')
                {
                    amount++;
                }
            }

            return char.Parse(amount.ToString());
        }
    }
}

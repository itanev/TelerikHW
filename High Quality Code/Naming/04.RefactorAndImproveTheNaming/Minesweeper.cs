namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Minesweeper
	{
		public static void Main()
		{
            const int Max = 35;

            List<UserScore> users = new List<UserScore>(6);

			char[,] field = CreateField();
			char[,] bombs = PutMines();

            string command = string.Empty;

			int counter = 0;
            int row = 0;
            int col = 0;

			bool hitMine = false;
            bool isGameStarted = true;
            bool allCellsWithoutMinesOpened = false;
			
			do
			{
				if (isGameStarted)
				{
                    Console.WriteLine("Let's play “Minesweeper”. Try your luck, finding field without mine.");
                    Console.WriteLine("The command 'top' shows the ranking, 'restart' starts new game, 'exit' exits the game.");

					DrawField(field);
					isGameStarted = false;
				}

				Console.Write("Enter row and col (row col) : ");

				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					    int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						CreateScoreStatistic(users);
						break;
					case "restart":
						field = CreateField();
						bombs = PutMines();
						DrawField(field);
						hitMine = false;
						isGameStarted = false;
						break;
					case "exit":
						Console.WriteLine("Bye Bye!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
								OnUserTurn(field, bombs, row, col);

								counter++;
							}

							if (Max == counter)
							{
								allCellsWithoutMinesOpened = true;
							}
							else
							{
								DrawField(field);
							}
						}
						else
						{
							hitMine = true;
						}

						break;
					default:
						Console.WriteLine("\nError! Invalid Command\n");
						break;
				}

				if (hitMine)
				{
					DrawField(bombs);

					Console.Write("\nHrrrrrr! You step on a mine. You have {0} points. Enter your nickname: ", counter);

					string nickname = Console.ReadLine();

                    UserScore userScore = new UserScore(nickname, counter);

					if (users.Count < 5)
					{
						users.Add(userScore);
					}
					else
					{
						for (int i = 0; i < users.Count; i++)
						{
							if (users[i].Points < userScore.Points)
							{
								users.Insert(i, userScore);
								users.RemoveAt(users.Count - 1);

								break;
							}
						}
					}

                    users.Sort((UserScore currUser, UserScore nextUser) => nextUser.Name.CompareTo(currUser.Name));
                    users.Sort((UserScore currUser, UserScore nextUser) => nextUser.Points.CompareTo(currUser.Points));

					CreateScoreStatistic(users);

					field = CreateField();
					bombs = PutMines();

					counter = 0;
					hitMine = false;
					isGameStarted = true;
				}

				if (allCellsWithoutMinesOpened)
				{
                    Console.WriteLine("\nCongratulations ! You have opened all 35 cells.");

					DrawField(bombs);

					Console.WriteLine("Enter a nickname: ");

					string nickname = Console.ReadLine();

                    UserScore userScore = new UserScore(nickname, counter);

					users.Add(userScore);

					CreateScoreStatistic(users);

					field = CreateField();

					bombs = PutMines();

					counter = 0;

					allCellsWithoutMinesOpened = false;
					isGameStarted = true;
				}
			}
			while (command != "exit");

			Console.WriteLine("Created in Bulgaria!");
			Console.Read();
		}

        private static void CreateScoreStatistic(List<UserScore> userScore)
		{
			Console.WriteLine("\nScore:");

			if (userScore.Count > 0)
			{
				for (int i = 0; i < userScore.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} Boxes", i + 1, userScore[i].Name, userScore[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No scores!\n");
			}
		}

		private static void OnUserTurn(char[,] board, char[,] mines, int row, int col)
		{
            char minesCount = CountMines(mines, row, col);
            mines[row, col] = minesCount;
			board[row, col] = minesCount;
		}

		private static void DrawField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);

			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
			{
				Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
				{
					Console.Write(string.Format("{0} ", board[row, col]));
				}

                Console.WriteLine("|");
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;

			char[,] board = new char[boardRows, boardColumns];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

        private static char[,] PutMines()
        {
			int rows = 5;
			int cols = 10;

            char[,] board = GenerateEmptyBoard(rows, cols);

            List<int> mineCoordBases = GenerateCoordBases();

			foreach (int coordBase in mineCoordBases)
			{
                int row = coordBase % rows;
				int col = coordBase / cols;

                if (row == 0 && coordBase != 0)
				{
                    col--;
                    row = rows;
				}
				else
				{
                    row++;
				}

                board[col, row - 1] = '*';
			}

            return board;
        }
  
        private static char[,] GenerateEmptyBoard(int rows, int cols)
        {
            char[,] board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = '-';
                }
            }
            return board;
        }

        private static List<int> GenerateCoordBases()
        {
            List<int> mineCoordBases = new List<int>();

            while (mineCoordBases.Count < 15)
            {
                Random randomNumber = new Random();

                int coordBase = randomNumber.Next(50);

                if (!mineCoordBases.Contains(coordBase))
                {
                    mineCoordBases.Add(coordBase);
                }
            }
            return mineCoordBases;
        }

		private static void CalcMines(char[,] board)
		{
			int rows = board.GetLength(0);
            int cols = board.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					if (board[row, col] != '*')
					{
						char minesCount = CountMines(board, row, col);

						board[row, col] = minesCount;
					}
				}
			}
		}

		private static char CountMines(char[,] board, int row, int col)
		{
			int totalCount = 0;
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);

			if (row - 1 >= 0)
			{
				if (board[row - 1, col] == '*')
				{ 
					totalCount++; 
				}
			}

			if (row + 1 < rows)
			{
				if (board[row + 1, col] == '*')
				{ 
					totalCount++; 
				}
			}

			if (col - 1 >= 0)
			{
				if (board[row, col - 1] == '*')
				{ 
					totalCount++;
				}
			}

			if (col + 1 < cols)
			{
				if (board[row, col + 1] == '*')
				{ 
					totalCount++;
				}
			}

			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (board[row - 1, col - 1] == '*')
				{ 
					totalCount++; 
				}
			}

			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (board[row - 1, col + 1] == '*')
				{ 
					totalCount++; 
				}
			}

			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (board[row + 1, col - 1] == '*')
				{ 
					totalCount++; 
				}
			}

			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (board[row + 1, col + 1] == '*')
				{ 
					totalCount++; 
				}
			}
			return char.Parse(totalCount.ToString());
		}
	}
}

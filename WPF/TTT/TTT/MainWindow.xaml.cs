using System;
using System.Windows;
using System.Windows.Controls;


namespace TTT
{
    public partial class MainWindow : Window
    {
        private bool _turnX = true;
        private bool _gameOver = false;
        public string[,] _board = new string[3, 3];

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "TTT: X TURN";
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            if (_gameOver)
            {
                return;
            }

            Button button = (sender as Button);
            if (button is null)
            {
                return;
            }

            var content = (button.Content as string);
            if (string.IsNullOrEmpty(content))
            {
                ChangeButtonContent(button);
                FillBoard(button);
                CheckGameOver();
                if (!_gameOver)
                {
                    ChangeTurn();
                }
            }
        }

        private void CheckGameOver()
        {
            if (_gameOver)
            {
                return;
            }

            string[] waysToWin = new string[]
            {
                WinningStreak(_board[0, 0], _board[0, 1], _board[0, 2]), // horizontally
                WinningStreak(_board[1, 0], _board[1, 1], _board[1, 2]),
                WinningStreak(_board[2, 0], _board[2, 1], _board[2, 2]),

                WinningStreak(_board[0, 0], _board[1, 0], _board[2, 0]), // vertically
                WinningStreak(_board[0, 1], _board[1, 1], _board[2, 1]),
                WinningStreak(_board[0, 2], _board[1, 2], _board[2, 2]),

                WinningStreak(_board[0, 0], _board[1, 1], _board[2, 2]), // diagonally
                WinningStreak(_board[0, 2], _board[1, 1], _board[2, 0]),
            };

            foreach(string winner in waysToWin)
            {
                if (winner.ToUpper().Equals("X"))
                {
                    _gameOver = true;
                    this.Title = "X Wins";
                }

                if (winner.ToUpper().Equals("O"))
                {
                    _gameOver = true;
                    this.Title = "O Wins";
                }
            }
        }

        private string WinningStreak(params string[] entries)
        {
            bool allX = true;
            bool allO = true;
            foreach(string entry in entries)
            {
                if (entry == null)
                {
                    return "";
                }

                if (!entry.ToUpper().Equals("X"))
                {
                    allX = false;
                }

                if (!entry.ToUpper().Equals("O"))
                {
                    allO = false;
                }
            }

            if (allX)
            {
                return "X";
            }

            if (allO)
            {
                return "O";
            }

            return "";
        }

        private void FillBoard(Button button)
        {
            string name = button.Name;
            string content = _turnX ? "X" : "O";
            switch (name)
            {
                case "btn00":
                    _board[0, 0] = content;
                    break;
                case "btn01":
                    _board[0, 1] = content;
                    break;
                case "btn02":
                    _board[0, 2] = content;
                    break;
                case "btn10":
                    _board[1, 0] = content;
                    break;
                case "btn11":
                    _board[1, 1] = content;
                    break;
                case "btn12":
                    _board[1, 2] = content;
                    break;
                case "btn20":
                    _board[2, 0] = content;
                    break;
                case "btn21":
                    _board[2, 1] = content;
                    break;
                case "btn22":
                    _board[2, 2] = content;
                    break;
            }
        }

        private void ChangeButtonContent(Button button)
        {
            if (_turnX)
            {
                button.Content = "X";
            } else
            {
                button.Content = "O";
            }
        }

        private void ChangeTurn()
        {
            if (_turnX)
            {
                _turnX = false;
                this.Title = "TTT: O TURN";
            } else
            {
                _turnX = true;
                this.Title = "TTT: X TURN";
            }
        }
    }
}

using Avalonia.Controls;
using Avalonia.Data;
using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;

namespace Frontend.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const int BoardSize = 3;

        private ObservableCollection<ObservableCollection<string>> _board;

        public MainWindowViewModel()
        {
            InitializeBoard();
            CellClickCommand = ReactiveCommand.Create<string>(HandleCellClick);
        }

        public ObservableCollection<ObservableCollection<string>> Board
        {
            get => _board;
            set => SetProperty(ref _board, value);
        }

        public ReactiveCommand<string, Unit> CellClickCommand { get; }

        private void InitializeBoard()
        {
            Board = new ObservableCollection<ObservableCollection<string>>();

            for (int i = 0; i < BoardSize; i++)
            {
                var row = new ObservableCollection<string>();
                for (int j = 0; j < BoardSize; j++)
                {
                    row.Add("");
                }
                Board.Add(row);
            }
        }

        private void HandleCellClick(string parameter)
        {
            if (Board != null)
            {
                // Parse the parameter to get the row and column
                string[] parts = parameter.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    // Check if the cell is empty before making a move
                    if (string.IsNullOrEmpty(Board[row][col]))
                    {
                        // For simplicity, we alternate between X and O
                        Board[row][col] = IsXNext ? "X" : "O";
                        IsXNext = !IsXNext;

                        // TODO: Add logic to check for a winner or a tie
                        // You can implement this based on the rules of Tic-Tac-Toe
                    }
                }
            }
        }

        // Additional properties or methods for game logic can be added here

        private bool _isXNext = true;

        public bool IsXNext
        {
            get => _isXNext;
            set => SetProperty(ref _isXNext, value);
        }
    }
}

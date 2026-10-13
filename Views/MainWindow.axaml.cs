using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace FirstLab1App.Views
{
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush _baseBackground = new(Colors.LightGray);
        private readonly SolidColorBrush _baseForeground = new(Colors.Black);
        private readonly SolidColorBrush _activeBackground = new(Colors.DarkGray);
        private readonly SolidColorBrush _activeForeground = new(Colors.White);

        public MainWindow()
        {
            InitializeComponent();
            foreach (var btn in AllButtons) SetBaseStyle(btn);
        }

        private Button[] AllButtons => new[] { BtnRed, BtnGreen, BtnBlue, BtnYellow };

        private void OnColorButtonClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button clickedButton) return;

            var newColor = clickedButton.Name switch
            {
                "BtnRed"    => Colors.Red,
                "BtnGreen"  => Colors.Green,
                "BtnBlue"   => Colors.Blue,
                "BtnYellow" => Colors.Yellow,
                _           => (Color?)null
            };

            if (newColor.HasValue)
                Background = new SolidColorBrush(newColor.Value);

            foreach (var btn in AllButtons) SetBaseStyle(btn);

            clickedButton.Background = _activeBackground;
            clickedButton.Foreground = _activeForeground;
        }

        private void SetBaseStyle(Button btn)
        {
            btn.Background = _baseBackground;
            btn.Foreground = _baseForeground;
        }
    }
}
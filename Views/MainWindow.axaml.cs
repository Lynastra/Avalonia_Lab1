using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace FirstLab1App.Views
{
    public partial class MainWindow : Window
    {
        // Базовые цвета для кнопок (серый фон, чёрный текст)
        private readonly SolidColorBrush _baseBackground = new SolidColorBrush(Colors.LightGray);
        private readonly SolidColorBrush _baseForeground = new SolidColorBrush(Colors.Black);
        
        // Цвета для активной кнопки (тёмный фон, белый текст)
        private readonly SolidColorBrush _activeBackground = new SolidColorBrush(Colors.DarkGray);
        private readonly SolidColorBrush _activeForeground = new SolidColorBrush(Colors.White);

        public MainWindow()
        {
            InitializeComponent();

            // 1. Подписываемся на события
            BtnRed.Click += OnColorButtonClick;
            BtnGreen.Click += OnColorButtonClick;
            BtnBlue.Click += OnColorButtonClick;
            BtnYellow.Click += OnColorButtonClick;

            // 2. Сразу задаём базовый стиль всем кнопкам.
            // Это решает проблему "полупрозрачности" и гарантирует читаемость.
            SetBaseStyle(BtnRed);
            SetBaseStyle(BtnGreen);
            SetBaseStyle(BtnBlue);
            SetBaseStyle(BtnYellow);
        }

        private void OnColorButtonClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button clickedButton)
                return;

            string colorText = clickedButton.Content?.ToString() ?? "";

            // Определяем цвет окна
            SolidColorBrush? newWindowColor = colorText switch
            {
                "Красный"  => new SolidColorBrush(Colors.Red),
                "Зелёный"  => new SolidColorBrush(Colors.Green),
                "Синий"    => new SolidColorBrush(Colors.Blue),
                "Жёлтый"   => new SolidColorBrush(Colors.Yellow),
                _          => null
            };

            if (newWindowColor != null)
            {
                this.Background = newWindowColor;
            }

            // Сбрасываем стили всех кнопок в базовый (серый фон, чёрный текст)
            ResetAllButtonsToBaseStyle();

            // Делаем нажатую кнопку контрастной (тёмный фон, белый текст)
            clickedButton.Background = _activeBackground;
            clickedButton.Foreground = _activeForeground;
        }

        // Метод, который ставит базовый стиль (серый фон, чёрный текст)
        private void SetBaseStyle(Button btn)
        {
            btn.Background = _baseBackground;
            btn.Foreground = _baseForeground;
        }

        // Метод, который сбрасывает ВСЕ кнопки в базовый стиль
        private void ResetAllButtonsToBaseStyle()
        {
            SetBaseStyle(BtnRed);
            SetBaseStyle(BtnGreen);
            SetBaseStyle(BtnBlue);
            SetBaseStyle(BtnYellow);
        }
    }
}

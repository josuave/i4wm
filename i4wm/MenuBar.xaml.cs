using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace i4wm
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : Window
    {
        int desktopCount = VirtualDesktop.Desktop.Count;

        public MenuBar()
        {
            InitializeComponent();

            for (int i = 0; i < desktopCount; i++)
            {
                Button button = new Button();
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Center;
                button.Height = 25;
                button.Width = 25;
                button.Content = i + 1;
                button.BorderThickness = new Thickness(0);
                button.Background = Brushes.Transparent;

                var current = VirtualDesktop.Desktop.Current.ToString();
                if (i.ToString() == current)
                {
                    button.Background = Brushes.Red;
                }

                button.Click += buttonClick;

                sp_main.Children.Add(button);
            }
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            foreach(Button button in sp_main.Children)
            {
                button.Background = Brushes.Transparent;
            }
            clicked.Background = Brushes.Red;
            var index = int.Parse(clicked.Content.ToString()) - 1;

            VirtualDesktop.Desktop.PinWindow(VirtualDesktop.Desktop.GetForegroundWindow());
            VirtualDesktop.Desktop.FromIndex(index).MakeVisible();
        }
    }
}

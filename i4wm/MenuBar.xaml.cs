using System;
using System.Windows;
using System.Windows.Controls;
using WindowsDesktop;

namespace i4wm
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : Window
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            int desktopCount = i4wm.VirtualDesktop.Desktop.Count;
            Grid buttonGrid = new Grid();

            for (int i = 0; i < desktopCount; i++)
            {
                Button button = new Button();
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Center;
                button.Height = 25;
                button.Width = 25;
                button.Content = "1";
                button.BorderThickness = new Thickness(0);

                button.Click += buttonClick;

                buttonGrid.Children.Add(button);
            }

            AddVisualChild(buttonGrid);
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

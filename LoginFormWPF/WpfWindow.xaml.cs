using System;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LoginFormWPF;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class WpfWindow : Window
    {
        private DispatcherTimer timer;
        public ChartValues<ObservablePoint> Line1Values { get; set; }
        public ChartValues<ObservablePoint> Line2Values { get; set; }
        public ChartValues<ObservablePoint> Line3Values { get; set; }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();


        public WpfWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Line1Values = new ChartValues<ObservablePoint>();

            Line2Values = new ChartValues<ObservablePoint>();

            Line3Values = new ChartValues<ObservablePoint>();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Adjust the interval as needed
            timer.Tick += Timer_Tick;
            timer.Start();


            // Initialize the slider value
            slider1.Value = 0;

        }

        private Random random = new Random();
        private int dataPointCount = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            double newValue1 = random.NextDouble() * 100; // Change this based on your data range
            Line1Values.Add(new ObservablePoint(dataPointCount, newValue1));

            double newValue2 = random.NextDouble() * 100;
            Line2Values.Add(new ObservablePoint(dataPointCount, newValue2));

            double newValue3 = random.NextDouble() * 100;
            Line3Values.Add(new ObservablePoint(dataPointCount, newValue3));

            dataPointCount++;

            // Limit the number of data points if needed
            if (Line1Values.Count > 100)
            {
                Line1Values.RemoveAt(0);
                Line2Values.RemoveAt(0);
                Line3Values.RemoveAt(0);
            }
        }

        private void PowerBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            FormWindow FW = new FormWindow();
            FW.Show();
            this.Close();
        }

        private void CloseMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuBtn.Visibility = Visibility.Visible;
            CloseMenuBtn.Visibility = Visibility.Collapsed;
            Mode.Visibility = Visibility.Collapsed;
        }

        private void OpenMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuBtn.Visibility = Visibility.Collapsed;
            CloseMenuBtn.Visibility = Visibility.Visible;
            Mode.Visibility = Visibility.Visible;
        }

        private void Home_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFC9C4C4");
            Home.Background = new SolidColorBrush(color);
            Home.Foreground = Brushes.Black;
        }

        private void Home_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF2857FB");
            Home.Background = new SolidColorBrush(color);
            Home.Foreground = Brushes.White;

        }

        private void Profile_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFC9C4C4");
            Profile.Background = new SolidColorBrush(color);
            Profile.Foreground = Brushes.Black;
        }

        private void Profile_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Color color = (Color)ColorConverter.ConvertFromString("#FF2857FB");
            Profile.Background = new SolidColorBrush(color);
            Profile.Foreground = Brushes.White;
        }

        private void Create_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFC9C4C4");
            Create.Background = new SolidColorBrush(color);
            Create.Foreground = Brushes.Black;
        }

        private void Create_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF2857FB");
            Create.Background = new SolidColorBrush(color);
            Create.Foreground = Brushes.White;
        }

        private void Discovery_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFC9C4C4");
            Discovery.Background = new SolidColorBrush(color);
            Discovery.Foreground = Brushes.Black;
        }

        private void Discovery_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Color color = (Color)ColorConverter.ConvertFromString("#FF2857FB");
            Discovery.Background = new SolidColorBrush(color);
            Discovery.Foreground = Brushes.White;
        }

        private void Featured_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Color color = (Color)ColorConverter.ConvertFromString("#FFC9C4C4");
            Featured.Background = new SolidColorBrush(color);
            Featured.Foreground = Brushes.Black;
        }

        private void Featured_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF2857FB");
            Featured.Background = new SolidColorBrush(color);
            Featured.Foreground = Brushes.White;
        }

        private void OpenSidebarBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenSidebarBtn.Visibility = Visibility.Collapsed;
            CloseSidebarBtn.Visibility = Visibility.Visible;
        }

        private void CloseSidebarBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenSidebarBtn.Visibility = Visibility.Visible;
            CloseSidebarBtn.Visibility = Visibility.Collapsed;
        }

        private void clickMe1_Click(object sender, RoutedEventArgs e)
        {
            Line1Values.Clear();
            Line2Values.Clear();
            Line3Values.Clear();

            dataPointCount = 0;
            slider1.Value = 0;
        }

        private void Btn2(object sender, RoutedEventArgs e)
        {

        }

        private void Slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int minValue = (int)e.NewValue;
            int maxValue = minValue + 10; // Adjust this value based on your preference

            // Check if the AxisX collection has elements
            if (chart.AxisX.Count > 0)
            {
                // Update the X-axis range of the chart
                chart.AxisX[0].MinValue = minValue;
                chart.AxisX[0].MaxValue = maxValue;
            }
        }

        private void DarkMode(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

    }
}

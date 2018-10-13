using CarDistanceGenerator.Logics;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CarDistanceGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CarGeneratorLogic CarGeneratorLogic { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitDependencies(); // TODO Dependency injection maybe?
            InitCalendar();
        }

        private void InitCalendar()
        {
            DateForReportCalendar.SelectedDate = DateTime.Today;
            DateForReportCalendar.DisplayDate = DateTime.Today;
        }

        private void InitDependencies()
        {
            CarGeneratorLogic = new CarGeneratorLogic();
        }

        private void GenerateCarPdf_Click(object sender, RoutedEventArgs e)
        {
            var month = DateForReportCalendar.DisplayDate.Month;
            var year = DateForReportCalendar.DisplayDate.Year;    
            CarGeneratorLogic.GenerateCarReport(month, year);
        }

        private void DateForReportCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            if (DateForReportCalendar.DisplayMode != CalendarMode.Year) // So that calendar shows only months to choose
            {
                DateForReportCalendar.DisplayMode = CalendarMode.Year;
            }
        }

        private void DateForReportCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            if (ChosenDateSpanTextBlock != null)
            {
                string year = DateForReportCalendar.DisplayDate.Year.ToString();
                string month = DateForReportCalendar.DisplayDate.Month.ToString();
                month = DateForReportCalendar.DisplayDate.Month >= 10 ? month : $"0{month}";
                ChosenDateSpanTextBlock.Text = $"{year}-{month}";
            }
        }

        private void DateForReportCalendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null); // So that choosen month does not change after leaving calendar with mouse
            }
        }

    }
}

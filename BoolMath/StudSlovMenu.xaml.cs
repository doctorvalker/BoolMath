using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoolMath
{
    /// <summary>
    /// Логика взаимодействия для StudSlovMenu.xaml
    /// </summary>
    public partial class StudSlovMenu : Page
    {
        public int TeachID;

        public StudSlovMenu(int ID)
        {
            InitializeComponent();
            TeachID = ID;
        }

        private void StudClear(object sender, RoutedEventArgs e)
        {
            if (StudID.Text == "Код ученика" || StudID.Text == "Неверный код")
            {
                StudID.Clear();
                StudID.Foreground = Brushes.Black;
            }
        }

        private void StudFill(object sender, RoutedEventArgs e)
        {
            if (StudID.Text == "")
            {
                StudID.Foreground = Brushes.LightGray;
                StudID.Text = "Код ученика";
            }
        }

        private void TestClear(object sender, RoutedEventArgs e)
        {
            if (TestID.Text == "Код теста" || TestID.Text == "Неверный код")
            {
                TestID.Clear();
                TestID.Foreground = Brushes.Black;
            }
        }

        private void TestFill(object sender, RoutedEventArgs e)
        {
            if (StudID.Text == "")
            {
                TestID.Foreground = Brushes.LightGray;
                TestID.Text = "Код теста";
            }
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ListTest(TeachID));
        }

        private void SSRAll(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudSolvResult(TeachID, 1, 0, 0));
        }

        private void SSRStud(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudSolvResult(TeachID, 2, Convert.ToInt32(StudID.Text), 0));
        }

        private void SSRTest(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudSolvResult(TeachID, 3, 0, Convert.ToInt32(TestID.Text)));
        }
    }
}

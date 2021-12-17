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
    /// Логика взаимодействия для StudMenu.xaml
    /// </summary>
    public partial class StudMenu : Page
    {
        public int SID;
        
        public StudMenu(int ID)
        {
            InitializeComponent();
            SID = ID;
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EntRegMenu());
        }

        private void ThOpen(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ru.wikipedia.org/wiki/%D0%91%D1%83%D0%BB%D0%B5%D0%B2%D0%B0_%D0%B0%D0%BB%D0%B3%D0%B5%D0%B1%D1%80%D0%B0");
        }

        private void LTOpen(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ListTest(SID));
        }

        private void STOpen(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SolvTest(SID));
        }
    }
}

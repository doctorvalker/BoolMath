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
    /// Логика взаимодействия для EntRegMenu.xaml
    /// </summary>
    public partial class EntRegMenu : Page
    {
        public EntRegMenu()
        {
            InitializeComponent();
        }
        private void EntryWin(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EntMenu());
        }

        private void RegisWin(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegMenu());
        }
    }
}

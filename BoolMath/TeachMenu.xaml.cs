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
    /// Логика взаимодействия для TeachMenu.xaml
    /// </summary>
    public partial class TeachMenu : Page
    {
        public int TID;

        public TeachMenu(int ID)
        {
            InitializeComponent();
            TID = ID;
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EntRegMenu());
        }

        private void LTOpen(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ListTest(TID));
        }
    }
}

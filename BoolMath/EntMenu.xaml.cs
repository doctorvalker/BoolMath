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
using System.Data.SqlClient;

namespace BoolMath
{
    /// <summary>
    /// Логика взаимодействия для EntMenu.xaml
    /// </summary>
    public partial class EntMenu : Page
    {
        private string ConStr = @"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=KursPr4Kurs; Integrated Security=True;";

        private bool LogCheck()
        {
            string PassComm = "SELECT count(*) FROM [Users] WHERE user_login = @log AND user_password = @pass";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand CMMND = new SqlCommand(PassComm, Con);
                if (Login.Text != null || Login.Text != "Логин")
                CMMND.Parameters.AddWithValue("@log", Login.Text);
                CMMND.Parameters.AddWithValue("@pass", Password.Text);
                int NC = (int)CMMND.ExecuteScalar();
                if (NC > 0)
                {
                    Con.Close();
                    return true;
                }
                else
                {
                    Login.Text = "";
                    Login.Foreground = Brushes.Red;
                    Login.Text = "Вы что-то неправильно ввели!!!!";
                }
                Con.Close();
                return false;
            }
        }

        private string AddUS()
        {
            string PassComm = "SELECT * FROM [Users] WHERE user_login = @log AND user_password = @pass";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand CMMND = new SqlCommand(PassComm, Con);
                CMMND.Parameters.AddWithValue("@log", Login.Text);
                CMMND.Parameters.AddWithValue("@pass", Password.Text);
                SqlDataReader UsSt = CMMND.ExecuteReader();
                UsSt.Read();
                string St = (string)UsSt["user_status"];
                UsSt.Close();
                Con.Close();
                return St;
            }
        }

        private int AddUID()
        {
            string PassComm = "SELECT * FROM [Users] WHERE user_login = @log AND user_password = @pass";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand CMMND = new SqlCommand(PassComm, Con);
                CMMND.Parameters.AddWithValue("@log", Login.Text);
                CMMND.Parameters.AddWithValue("@pass", Password.Text);
                SqlDataReader UsID = CMMND.ExecuteReader();
                UsID.Read();
                int ID = (int)UsID["user_id"];
                UsID.Close();
                Con.Close();
                return ID;
            }
        }

        private void EntProc(object sender, RoutedEventArgs e)
        {
            if (LogCheck() == true)
            {
                if (AddUS() == "Ученик")
                {
                    NavigationService?.Navigate(new StudMenu(AddUID()));
                } else
                {
                    NavigationService?.Navigate(new TeachMenu(AddUID()));
                }
            }

        }

        public EntMenu()
        {
            InitializeComponent();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EntRegMenu());
        }

        private void LogClear(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "Логин" || Login.Text == "Неверный логин" || Login.Text == "Вы что-то неправильно ввели!!!!")
            {
                Login.Clear();
                Login.Foreground = Brushes.Black;
            }
        }

        private void LogFill(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Foreground = Brushes.LightGray;
                Login.Text = "Логин";
            }
        }

        private void PasClear(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "Пароль" || Password.Text == "Неверный пароль")
            {
                Password.Clear();
                Password.Foreground = Brushes.Black;
            }
        }

        private void PasFill(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Foreground = Brushes.LightGray;
                Password.Text = "Пароль";
            }
        }

        private void CheckInput(object sender, TextCompositionEventArgs e)
        {
            if ((e.Text[0] >= '0' && e.Text[0] <= '9') || (e.Text[0] >= 'A' && e.Text[0] <= 'Z') || (e.Text[0] >= 'a' && e.Text[0] <= 'z')) e.Handled = false;
            else e.Handled = true;
        }
    }
}

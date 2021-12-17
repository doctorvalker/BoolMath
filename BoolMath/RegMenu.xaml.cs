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
    /// Логика взаимодействия для RegMenu.xaml
    /// </summary>
    public partial class RegMenu : Page
    {
        private string ConStr = @"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=KursPr4Kurs; Integrated Security=True;";

        private bool AddUser()
        {
            string UpdComm = "INSERT INTO [Users] (user_login, user_password, user_status) VALUES (@log, @pass, @us)";
            string LogCheck = "SELECT Count(*) FROM [Users] WHERE user_login = @Lg";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand NCC = new SqlCommand(LogCheck, Con);
                NCC.Parameters.AddWithValue("@Lg", LogReg.Text);
                int LgCo = (int)NCC.ExecuteScalar();
                if (LgCo > 0) 
                {
                    LogReg.Text = "";
                    LogReg.Foreground = Brushes.Red;
                    LogReg.Text = "Логин уже сущевствует";
                    return false;
                }
                else
                {
                    SqlCommand CMMND = new SqlCommand(UpdComm, Con);
                    CMMND.Parameters.AddWithValue("@log", LogReg.Text);
                    CMMND.Parameters.AddWithValue("@pass", PassReg.Text);
                    if (SB.IsChecked == true) 
                    {
                        CMMND.Parameters.AddWithValue("@us", "Ученик");
                    } else if (TB.IsChecked == true) 
                    {
                        CMMND.Parameters.AddWithValue("@us", "Учитель");
                    }
                    else 
                    {
                        MessageBox.Show("Вы не выбрали статус");
                        return false;
                    }
                    CMMND.ExecuteNonQuery();
                    Con.Close();
                    return true;
                }
            }
        }

        private int AddUID()
        {
            string PassComm = "SELECT * FROM [Users] WHERE user_login = @log AND user_password = @pass";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand CMMND = new SqlCommand(PassComm, Con);
                CMMND.Parameters.AddWithValue("@log", LogReg.Text);
                CMMND.Parameters.AddWithValue("@pass", PassReg.Text);
                SqlDataReader UsID = CMMND.ExecuteReader();
                UsID.Read();
                int ID = (int)UsID["user_id"];
                UsID.Close();
                Con.Close();
                return ID;
            }
        }

        private void RegProc(object sender, RoutedEventArgs e)
        {
            if (AddUser() == true)
            {
                NavigationService?.Navigate(new TeachMenu(AddUID()));
            }
            else MessageBox.Show("Вы что-то не ввели!!!!");
        }
        public RegMenu()
        {
            InitializeComponent();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EntRegMenu());
        }

        private void LogClear(object sender, RoutedEventArgs e)
        {
            if (LogReg.Text == "Логин" || LogReg.Text == "Логин уже сущевствует")
            {
                LogReg.Clear();
                LogReg.Foreground = Brushes.Black;
            }
        }

        private void LogFill(object sender, RoutedEventArgs e)
        {
            if (LogReg.Text == "")
            {
                LogReg.Foreground = Brushes.LightGray;
                LogReg.Text = "Логин";
            }
        }

        private void PasClear(object sender, RoutedEventArgs e)
        {
            if (PassReg.Text == "Пароль")
            {
                PassReg.Clear();
                PassReg.Foreground = Brushes.Black;
            }
        }

        private void PasFill(object sender, RoutedEventArgs e)
        {
            if (PassReg.Text == "")
            {
                PassReg.Foreground = Brushes.LightGray;
                PassReg.Text = "Пароль";
            }
        }

        private void CheckInput(object sender, TextCompositionEventArgs e)
        {
            if ((e.Text[0] >= '0' && e.Text[0] <= '9') || (e.Text[0] >= 'A' && e.Text[0] <= 'Z') || (e.Text[0] >= 'a' && e.Text[0] <= 'z')) e.Handled = false;
            else e.Handled = true;
        }
    }
}
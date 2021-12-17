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
    /// Логика взаимодействия для ListTest.xaml
    /// </summary>
    public partial class ListTest : Page
    {
        private string ConStr = @"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=KursPr4Kurs; Integrated Security=True;";
        public int STID;

        private void FillInterface(string Stat)
        {
            if (Stat == "Ученик")
            {
                StudSolv.Visibility = Visibility.Collapsed;
            }
            else if (Stat == "Учитель")
            {
                Complete.Visibility = Visibility.Collapsed;
            }
        }

        private void TestsLoad()
        {
            string TC = "SELECT COUNT(*) FROM ListTests";
            string TL = "Select * FROM ListTests WHERE test_id = @TID";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand TestCount = new SqlCommand(TC, Con);
                int TsC = (int)TestCount.ExecuteScalar();
                for (int TCnt = 1; TCnt <= TsC; TCnt++)
                {
                    Grid TG = new Grid();
                    TG.Width = 800;
                    TG.Height = 130;
                    TG.Opacity = 1;
                    TG.Margin = new Thickness(0, 0, 0, 50);
                    TextBlock TN = new TextBlock();
                    TN.Foreground = Brushes.Red;
                    TN.FontSize = 40;
                    TN.TextAlignment = TextAlignment.Left;
                    TextBlock TR = new TextBlock();
                    TR.Foreground = Brushes.Red;
                    TR.FontSize = 40;
                    TR.TextAlignment = TextAlignment.Right;
                    SqlCommand TD = new SqlCommand(TL, Con);
                    TD.Parameters.AddWithValue("TID", TCnt);
                    SqlDataReader TDR = TD.ExecuteReader();
                    TDR.Read();
                    TN.Text = TDR["test_name"].ToString();
                    TR.Text = TDR["test_author"].ToString();
                    TDR.Read();
                    TG.Children.Add(TN);
                    TG.Children.Add(TR);
                    TList.Children.Add(TG);
                }
                Con.Close();
            }
        }



        private string StatusCheck()
        {
            string PassComm = "SELECT * FROM [Users] WHERE user_id = @ID";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand CMMND = new SqlCommand(PassComm, Con);
                CMMND.Parameters.AddWithValue("@ID", STID);
                SqlDataReader UsSt = CMMND.ExecuteReader();
                UsSt.Read();
                string St = (string)UsSt["user_status"];
                UsSt.Close();
                Con.Close();
                return St;
            }
        }

        public ListTest(int ID)
        {
            InitializeComponent();
            STID = ID;
            FillInterface(StatusCheck());
            TestsLoad();
        }

        private void SSOpen(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudSlovMenu(STID));
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            if (StatusCheck() == "Ученик")
            {
                NavigationService?.Navigate(new StudMenu(STID));
            }
            else if (StatusCheck() == "Учитель")
            {
                NavigationService?.Navigate(new TeachMenu(STID));
            }
        }
    }
}

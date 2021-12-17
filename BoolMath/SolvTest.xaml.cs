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
using System.Data;

namespace BoolMath
{
    /// <summary>
    /// Логика взаимодействия для SolvTest.xaml
    /// </summary>
    public partial class SolvTest : Page
    {
        private string ConStr = @"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=KursPr4Kurs; Integrated Security=True;";
        public int SID;

        private void TestsLoad (int UI)
        {
            string AllTest = "SELECT * FROM SolvTests WHERE user_id = @SID";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand TD = new SqlCommand(AllTest, Con);
                TD.Parameters.AddWithValue("SID", UI);
                SqlDataAdapter FV = new SqlDataAdapter(TD);
                DataTable DS = new DataTable();
                FV.Fill(DS);
                DG.ItemsSource = DS.DefaultView;
            }
        }

        public SolvTest(int ID)
        {
            InitializeComponent();
            SID = ID;
            TestsLoad(SID);
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudMenu(SID));
        }
    }
}

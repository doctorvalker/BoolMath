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
    /// Логика взаимодействия для StudSolvResult.xaml
    /// </summary>
    public partial class StudSolvResult : Page
    {
        private string ConStr = @"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=KursPr4Kurs; Integrated Security=True;";
        public int TeachID;

        private void FillAllTests()
        {
            string AllTest = "SELECT * FROM SolvTests";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand TD = new SqlCommand(AllTest, Con);
                SqlDataAdapter FV = new SqlDataAdapter(TD);
                DataTable DS = new DataTable();
                FV.Fill(DS);
                DG.ItemsSource = DS.DefaultView;
            }
        }

        private void FillTestsbySID(int SID)
        {
            string AllTest = "SELECT * FROM SolvTests WHERE user_id = @SID";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand TD = new SqlCommand(AllTest, Con);
                TD.Parameters.AddWithValue("SID", SID);
                SqlDataAdapter FV = new SqlDataAdapter(TD);
                DataTable DS = new DataTable();
                FV.Fill(DS);
                DG.ItemsSource = DS.DefaultView;
            }
        }

        private void FillTestsbyTID(int TID)
        {
            string AllTest = "SELECT * FROM SolvTests WHERE test_id = @TID";

            using (SqlConnection Con = new SqlConnection(ConStr))
            {
                Con.Open();
                SqlCommand TD = new SqlCommand(AllTest, Con);
                TD.Parameters.AddWithValue("TID", TID);
                SqlDataAdapter FV = new SqlDataAdapter(TD);
                DataTable DS = new DataTable();
                FV.Fill(DS);
                DG.ItemsSource = DS.DefaultView;
            }
        }

        public StudSolvResult(int ID, int FuncID, int StudID, int TestID)
        {
            InitializeComponent();
            TeachID = ID;
            if (FuncID == 1)
            {
                FillAllTests();
            } else if (FuncID == 2)
            {
                FillTestsbySID(StudID);
            } else if (FuncID == 3)
            {
                FillTestsbyTID(TestID);
            }
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudSlovMenu(TeachID));
        }
    }
}

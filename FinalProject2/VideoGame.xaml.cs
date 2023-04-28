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

namespace FinalProject2
{
    /// <summary>
    /// Interaction logic for VideoGame.xaml
    /// </summary>
    public partial class VideoGame : Window
    {
        public VideoGame()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\FinalProject2\FinalProject2\Database1.mdf;Integrated Security = True");

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string query = "Select * from [Games]";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(sqlcmd);
                DataTable dtLoad = new DataTable();
                adapterLoad.Fill(dtLoad);
                Option.ItemsSource = dtLoad.DefaultView;
                adapterLoad.Update(dtLoad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string query = "delete from [Games] where Name='" + this.Name2.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("The order has been processed");

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}

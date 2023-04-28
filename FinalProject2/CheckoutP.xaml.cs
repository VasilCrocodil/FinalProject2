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
    /// Interaction logic for CheckoutP.xaml
    /// </summary>
    public partial class CheckoutP : Window
    {
        public CheckoutP()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\FinalProject2\FinalProject2\Database1.mdf;Integrated Security = True");

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string query = "Select * from [Plush]";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(sqlcmd);
                DataTable dtLoad = new DataTable();
                adapterLoad.Fill(dtLoad);
                PlushOrder.ItemsSource = dtLoad.DefaultView;
                adapterLoad.Update(dtLoad);
                MessageBox.Show("Succesfully loaded");
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string query = "delete from [Plush] where Name='" + this.Name1.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Character Deleted");
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Plush a = new Plush();
            a.Show();
            this.Close();
        }
    }
}

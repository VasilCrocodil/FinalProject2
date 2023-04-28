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
    /// Interaction logic for Plush.xaml
    /// </summary>
    public partial class Plush : Window
    {

        public string[] Size1 { get; set; }
        public string[] Color1 { get; set; }
        public Plush()
        {
            InitializeComponent();
            Size1 = new string[] { "Small", "Medium", "Large", "Extra Large" };
            DataContext = this;
            Color1 = new string[] { "Black", "White", "Gold", "Silver", "Original", "Shiny" };
            DataContext = this;
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\FinalProject2\FinalProject2\Database1.mdf;Integrated Security = True");

        private void CreatePlush_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlcon.Open();
                string query = "Insert into [PLush] (Name, Number, Size, Color) values ('" + this.Name.Text + "','" + this.Number.Text + "','" + this.Size.SelectedItem + "','" + this.Color.SelectedItem + "')";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Character created successfully");
                CheckoutP a = new CheckoutP();
                a.Show();
                this.Close();
            }
            catch (Exception exA)
            {
                MessageBox.Show(exA.Message);

            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Close();
        }
    }
}

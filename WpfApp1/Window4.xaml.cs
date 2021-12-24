using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

     
        private readonly object txtEmailId;
        private object errormessage;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmailId.Text.Length == 0)
            {
                errormessage.Text = "Enter an EmailId";

                txtEmailId.Focus();

            }

            else if (!Regex.IsMatch(txtEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {

                errormessage.Text = "Enter a valid email.";

                txtEmailId.Select(0, txtEmailId.Text.Length);

                txtEmailId.Focus();

            }

            else
            {

                string email = txtEmailId.Text;

                string password = txtPassword.Password;

                SqlConnection con = new SqlConnection("Data Source=INDIA11;Initial Catalog=WpfTest;Integrated Security=True");

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from User_Registration where EmailId='" + email + "'  and Password='" + password + "'", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataSet ds = new DataSet();

                da.Fill(ds);

              

                con.Close();

            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mm = new MainWindow();
            mm.Show();
        }


    }
}
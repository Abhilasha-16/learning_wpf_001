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

        WelComePage wc = new WelComePage();
        private object txtPassword;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmailId.Text.Length == 0)
            {
                errormessage.Text = "Enter an EmailId";

                txtEmailId.Focus();

            }

            else if (!Regex.IsMatch((string)txtEmailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {

                errormessage.Text = "Enter a valid email.";

                txtEmailId.Select(0, txtEmailId.Text.Length);

                txtEmailId.Focus();

            }

            else
            {

                string email = (string)txtEmailId.Text;

                string password = txtPassword.Text;

                SqlConnection con = new SqlConnection("Data Source=INDIA11;Initial Catalog=WpfTest;Integrated Security=True");

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from User_Registration where EmailId='" + email + "'  and Password='" + password + "'", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };

                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    wc.tbname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    wc.tbgender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    wc.tbemailid.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                  
                   /* wc.tbcontact.Text = ds.Tables[0].Rows[0]["Contact"].To();*/
                   
                    wc.Show();
                    Close();

                }

                else
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";

                }

                con.Close();

            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mm = new MainWindow();
            mm.Show();
        }


    }

   public class txtEmailId
    {
        public static object Text { get; internal set; }

        internal static void Focus()
        {
            throw new NotImplementedException();
        }

        internal static void Select(int v, object length)
        {
            throw new NotImplementedException();
        }
    }

    public class errormessage
    {
        internal static string Text;
    }

    internal class WelComePage
    {
        internal object tbname;
        internal object tbgender;
        internal object tbemailid;

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
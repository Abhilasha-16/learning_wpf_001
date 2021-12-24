using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for page2.xaml
    /// </summary>
    public partial class page2 : Window
    {
        string gen; 
           public page2()
        {
            InitializeComponent();
        }

       

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblmessage.Content = "";

            if (txtemailid.Text.Length == 0)

            {
                lblmessage.Visibility = System.Windows.Visibility.Visible;
                lblmessage.Foreground = Brushes.Red;
                lblmessage.Content = "Enter an email.";

                txtemailid.Focus();

            }

            else if (!Regex.IsMatch(txtemailid.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                lblmessage.Visibility = System.Windows.Visibility.Visible;
                lblmessage.Foreground = Brushes.Red;
                lblmessage.Content = "Enter a valid email.";

                txtemailid.Select(0, txtemailid.Text.Length);

                txtemailid.Focus();

            }

            else
            {


                if (txtpassword.Password.Length == 0)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;


                    lblmessage.Content = "Enter password.";

                    txtpassword.Focus();

                }

                else if (txtcpassword.Password.Length == 0)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Enter Confirm password.";

                    txtcpassword.Focus();

                }

                else if (txtpassword.Password != txtcpassword.Password)
                {
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Red;
                    lblmessage.Content = "Confirm password must be same as password.";

                    txtcpassword.Focus();

                }

                else
                {

                    
                    if (rbGender.IsChecked == true)
                    {
                        gen = rbGender.Content.ToString();
                    }
                    else
                    {
                        gen = rbGender1.Content.ToString();
                    }
                   
                    lblmessage.Visibility = System.Windows.Visibility.Visible;
                    lblmessage.Foreground = Brushes.Green;
                    lblmessage.Content = "Registration Successfully ";
                }
            }
        }
        // Resert all control
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetAllClear();
        }

        private void ResetAllClear()
        {
            foreach (UIElement ui in ChildGrid.Children)
            {
                if (ui is TextBox)
                {
                    TextBox tt = (TextBox)ui;
                    tt.Text = "";
                }
                if (ui is PasswordBox)
                {
                    PasswordBox pp = (PasswordBox)ui;
                    pp.Password = "";
                }

            }
            foreach (UIElement ui in stackCheckBox.Children)
            {
                if (ui.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = (CheckBox)ui;
                    chk.IsChecked = false;
                }
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow min = new MainWindow();
            min.Show();
        }

       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}


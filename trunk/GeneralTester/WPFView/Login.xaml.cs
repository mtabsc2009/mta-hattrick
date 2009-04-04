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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HatTrick;
using HatTrick.CommonModel;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Username must not be empty", "Login to hattrick", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else
            {
                if (txtPassword.Password == string.Empty)
                {
                    MessageBox.Show("Password must not be empty", "Login to hattrick", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    PerformLogin();
                }
            }
        }

        private void PerformLogin()
        {
            if (!CheckLogin(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else
            {
                this.DialogResult = true;
                MessageBox.Show("Success");
            }
        }

        private bool CheckLogin(string strUsername, string strPassword)
        {
            return (Game.Login(strUsername, strPassword) != null);
        }
    }

    public class EmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if ((string)(value) == String.Empty)
            {
                return new ValidationResult(false, "Cannot be empty");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

}

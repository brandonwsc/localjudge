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

namespace _Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            string login_success = App.system.login(username, password);
            if (login_success == "Student")
            {
                StudentWindow StuWin = new StudentWindow();
                StuWin.Show();
                Close();
            }
            else if (login_success == "Admin")
            {
                AdminWindow AdmWin = new AdminWindow();
                AdmWin.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Login fail.");
            }
            UsernameBox.Clear();
            PasswordBox.Clear();
        }
    }
}

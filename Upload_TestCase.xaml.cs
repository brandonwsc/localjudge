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
using System.Windows.Shapes;

namespace _Project
{
    /// <summary>
    /// Interaction logic for Upload_TestCase.xaml
    /// </summary>
    public partial class Upload_TestCase : Window
    {
        public Upload_TestCase()
        {
            InitializeComponent();
        }

        private void Submit_UploadTestCase_Click(object sender, RoutedEventArgs e)
        {
            string input = Input_Upload.Text;
            string output = Output_Upload.Text;
            App.system.add_testcases(input, output);
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }

        private void Upload_TestCase_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Upload_TestCase_Return_Click(object sender, RoutedEventArgs e)
        {
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }
    }
}

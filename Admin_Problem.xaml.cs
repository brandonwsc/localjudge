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
    /// Interaction logic for Admin_Problem.xaml
    /// </summary>
    public partial class Admin_Problem : Window
    {
        public Admin_Problem()
        {
            InitializeComponent();
        }

        private void Edit_Problem_Click(object sender, RoutedEventArgs e)
        {
            Edit_Problem edit = new Edit_Problem();
            edit.Show();
            Close();
        }

        private void View_Statistic_Click(object sender, RoutedEventArgs e)
        {
            Statistic Stat = new Statistic();
            Stat.Show();
            Close();
        }

        private void Upload_TestCase_Click(object sender, RoutedEventArgs e)
        {
            Upload_TestCase upload_testcase = new Upload_TestCase();
            upload_testcase.Show();
            Close();
        }

        private void Edit_TestCase_Click(object sender, RoutedEventArgs e)
        {
            TestCase_List edit_testcase = new TestCase_List();
            edit_testcase.Show();
            Close();
        }

        private void Admin_Problem_Return_Click(object sender, RoutedEventArgs e)
        {
            ProblemListWindow problemListWindow = new ProblemListWindow();
            problemListWindow.Show();
            Close();
        }

        private void Admin_Problem_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Submit_Problem_Click(object sender, RoutedEventArgs e)
        {
            Student_Upload_Problem student_upload = new Student_Upload_Problem();
            student_upload.Show();
            Close();         
        }
    }
}

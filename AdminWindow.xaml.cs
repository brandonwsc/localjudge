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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }

        private void Problem_Button_Click(object sender, RoutedEventArgs e)
        {
            ProblemListWindow PLWin = new ProblemListWindow();
            PLWin.Show();
            Close();
        }



        private void Upload_Button_Click(object sender, RoutedEventArgs e)
        {
            Upload_question upload = new Upload_question();
            upload.Show();
            Close();
        }

        private void Admin_View_Statistic_Click(object sender, RoutedEventArgs e)
        {
            Student_Statistic student_Statistic = new Student_Statistic();
            student_Statistic.Show();
            Close();
        }
    }
}

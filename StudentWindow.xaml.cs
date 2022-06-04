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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void Problem_Student_Click(object sender, RoutedEventArgs e)
        {
            Student_Problem_List student_problem_list = new Student_Problem_List();
            student_problem_list.Show();
            Close();
        }

        private void Student_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Show_Student_Statistic_Click(object sender, RoutedEventArgs e)
        {
            Student_Statistic student_Statistic = new Student_Statistic();
            student_Statistic.Show();
            Close();
        }
    }
}

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
    /// Interaction logic for Student_Statistic.xaml
    /// </summary>
    public partial class Student_Statistic : Window
    {
        public Student_Statistic()
        {
            InitializeComponent();
            List<string> problem = App.system.browse_problem_list();
            int[,] student_statistic = App.system.view_student_statistic();
            int problem_num = student_statistic.GetLength(0);
            bool complete = false;
            for (int i = 0; i < problem_num; i++)
            {
                if(student_statistic[i, 0] > 0) { complete = true; }
            }
            if (complete) 
            {
                Statistic_content.Text += "Congratulations, you have completed problem:\n";
                for (int i = 0; i < problem_num; i++)
                {
                    if (student_statistic[i, 0] > 0)
                    {
                        Statistic_content.Text += problem[i] +"\n";
                    }
                }
            }
            Statistic_content.Text += "\nStatistic:";
            for (int i=0;i < problem_num; i++)
            {
                Statistic_content.Text += "\n\nProblem"+(i+1)+": " + problem[i];
                Statistic_content.Text += "\nAnswer correct: " + student_statistic[i, 0];
                Statistic_content.Text += "\nAttempt: " + student_statistic[i, 1];
            }
        }

        private void Student_Statistic_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Student_Statistic_Return_Click(object sender, RoutedEventArgs e)
        {
            string user_type = App.system.Logined_type;
            if (user_type == "Admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                Close();
            }
            else
            {
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                Close();
            }
        }
    }
}

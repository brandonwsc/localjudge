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
    /// Interaction logic for Student_Problem_List.xaml
    /// </summary>
    public partial class Student_Problem_List : Window
    {
        public Student_Problem_List()
        {
            InitializeComponent();
            var problem_list = App.system.browse_problem_list();
            for (int i = 0; i < problem_list.Count; i++)
            {
                Student_ProblemList.Items.Add(problem_list[i]);
            }
        }

        private void Submit_Student_Select_Click(object sender, RoutedEventArgs e)
        {
            int selected_index = Student_ProblemList.SelectedIndex;
            if (selected_index == -1) 
            {
                MessageBox.Show("Please select a problem");
            }
            else
            {
                App.system.Question_selected = selected_index;
                Student_Upload_Problem student_upload = new Student_Upload_Problem();
                student_upload.Show();
                Close();
            }
        }

        private void Student_Problem_List_Return_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.Show();
            Close();
        }

        private void Student_Problem_List_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

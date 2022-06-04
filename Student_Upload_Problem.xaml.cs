using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Student_Upload_Problem.xaml
    /// </summary>
    public partial class Student_Upload_Problem : Window
    {
        string filepath = null;

        public Student_Upload_Problem()
        {
            InitializeComponent();
            List<string> problem = App.system.browse_problem();
            Message_Submit.Text += problem[0];
            Message_Submit.Text += "\nWrite your code here";
            Student_Problem_Code.Text = null;
        }

        private void Submit_Problem_File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            filepath = file.FileName;
        }

        private void Student_Submit_Problem_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(Student_Problem_Code.Text))
            {
                filepath = App.system.create_program_file(Student_Problem_Code.Text);
                App.system.submit_file(filepath);
            }
            else if (!String.IsNullOrEmpty(filepath))
            {
                App.system.submit_file(filepath);
            }else MessageBox.Show("Please write your code or submit your program file.");


        }

        private void Student_Upload_Problem_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Student_Upload_Problem_Return_Click(object sender, RoutedEventArgs e)
        {
            string user_type = App.system.Logined_type;
            if (user_type== "Admin")
            {
                Admin_Problem admin_Problem = new Admin_Problem();
                admin_Problem.Show();
                Close();
            }
            else
            {
                Student_Problem_List student_Problem_List = new Student_Problem_List();
                student_Problem_List.Show();
                Close();
            }

        }
    }
}

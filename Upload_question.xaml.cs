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
    /// Interaction logic for Upload_question.xaml
    /// </summary>
    public partial class Upload_question : Window
    {
        public Upload_question()
        {
            InitializeComponent();
        }

        private void Submit_UploadProblem_Click(object sender, RoutedEventArgs e)
        {
            string title = Title_Upload.Text;
            string content = Content_Upload.Text;
            App.system.upload_problem(title, content);
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void Upload_question_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Upload_question_Return_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}

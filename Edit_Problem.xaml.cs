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
    /// Interaction logic for Edit_Problem.xaml
    /// </summary>
    public partial class Edit_Problem : Window
    {
        int problem_selected;
        public Edit_Problem()
        {
            InitializeComponent();
            List<string> problem = App.system.browse_problem();
            Title_Edit.Text = problem[0];
            Content_Edit.Text = problem[1];
            problem_selected = Convert.ToInt32(problem[2]);
        }

        private void Submit_EditProblem_Click(object sender, RoutedEventArgs e)
        {
            string title = Title_Edit.Text;
            string content = Content_Edit.Text;
            App.system.edit_problem(problem_selected, title, content);
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }

        private void Edit_Problem_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Edit_Problem_Return_Click(object sender, RoutedEventArgs e)
        {
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }
    }
}

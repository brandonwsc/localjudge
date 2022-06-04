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
    /// Interaction logic for ProblemListWindow.xaml
    /// </summary>
    public partial class ProblemListWindow : Window
    {
        public ProblemListWindow()
        {
            InitializeComponent();
            var problem_list = App.system.browse_problem_list();
            for (int i = 0; i < problem_list.Count; i++)
            {
                ProblemCombo.Items.Add(problem_list[i]);
            }
        }

        private void ChooseProgram_Click(object sender, RoutedEventArgs e)
        {            
            int selected_index = ProblemCombo.SelectedIndex;
            if (selected_index == -1)
            {
                MessageBox.Show("Please select a problem");
            }
            else
            {
                App.system.Question_selected = selected_index;
                Admin_Problem admin_Problem = new Admin_Problem();
                admin_Problem.Show();
                Close();
            }
        }

        private void ProblemListWindow_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ProblemListWindow_Return_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}

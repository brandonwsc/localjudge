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
    /// Interaction logic for Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        public Statistic()
        {
            InitializeComponent();
            List<int> stat = App.system.browse_statistics(App.system.Question_selected);
            string problem_name = App.system.browser_problem_title(App.system.Question_selected);
            Show_Statistic.Text += problem_name;
            Show_Statistic.Text += "\nAnswer correct: " + stat[0] + "\nAttempt: " + stat[1];
        }

        private void Statistic_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Statistic_Return_Click(object sender, RoutedEventArgs e)
        {
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }
    }
}

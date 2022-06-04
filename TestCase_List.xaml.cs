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
    /// Interaction logic for TestCase_List.xaml
    /// </summary>
    public partial class TestCase_List : Window
    {
        public TestCase_List()
        {
            InitializeComponent();
            int question_num = App.system.Question_selected;
            int testcase_num = App.system.browse_testcase(question_num);
            for (int i = 0; i < testcase_num; i++)
            {
                int num = i + 1;
                TestCase_List_Combo.Items.Add("Testcase" + num);
            }
        }

        private void Submit_Select_TestCase_Click(object sender, RoutedEventArgs e)
        {
            int testcase_selected = TestCase_List_Combo.SelectedIndex;
            if (testcase_selected == -1) {
                MessageBox.Show("Please select a testcase");
            }
            else
            {
                App.system.select_testcase(testcase_selected);
                Edit_TestCase edit_test = new Edit_TestCase();
                edit_test.Show();
                Close();
            }
        }

        private void TestCase_List_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void TestCase_List_Return_Click(object sender, RoutedEventArgs e)
        {
            Admin_Problem admin_Problem = new Admin_Problem();
            admin_Problem.Show();
            Close();
        }
    }
}

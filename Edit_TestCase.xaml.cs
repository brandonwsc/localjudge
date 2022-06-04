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
    /// Interaction logic for Edit_TestCase.xaml
    /// </summary>
    public partial class Edit_TestCase : Window
    {
        int question_num;
        public Edit_TestCase()
        {
            InitializeComponent();
            question_num = App.system.Question_selected;
            List<string> testcase = App.system.get_testcase(question_num);
            Input_Edit.Text = testcase[0];
            Output_Edit.Text = testcase[1];
        }

        private void Submit_EditTestCase_Click(object sender, RoutedEventArgs e)
        {
            string input = Input_Edit.Text;
            string output = Output_Edit.Text;
            App.system.edit_testcases(question_num, input, output);
            TestCase_List testCase_List = new TestCase_List();
            testCase_List.Show();
            Close();
        }

        private void Edit_TestCase_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Edit_TestCase_Return_Click(object sender, RoutedEventArgs e)
        {
            TestCase_List testCase_List = new TestCase_List();
            testCase_List.Show();
            Close();
        }
    }
}

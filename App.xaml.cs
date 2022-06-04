using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace _Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static JudgeSystem system = new JudgeSystem();
    }
}


public class JudgeSystem
{

    protected List<ProgramProblem> problems = new List<ProgramProblem>();

    protected List<User> user = new List<User>();
    protected string logined_type = null;
    public string Logined_type
    {
        get { return logined_type; }
    }

    internal List<string> browse_testcases()
    {
        throw new NotImplementedException();
    }

    protected int user_logined;
    public int User_logined { get { return user_logined; } }
    protected int question_selected;

    public int Question_selected
    {
        get { return question_selected; }
        set { if (value >= 0) question_selected = value; }
    }

    public int browse_testcase_LIST { get; internal set; }
    public int testcases_num { get; internal set; }

    public JudgeSystem()
    {
        initialization();
    } // constructor
    private void initialization()
    {
        //Initialize User
        Admin Admin = new Admin("1", "Admin", "Admin");
        Student ChanSiuMing = new Student("2", "ChanSiuMing", "20000101");
        Student ChanTaiMing = new Student("3", "ChanTaiMing", "asdfghjkl;’");
        Student CatChu = new Student("4", "CatChu", "catcatcat");
        user.Add(Admin);
        user.Add(ChanSiuMing);
        user.Add(ChanTaiMing);
        user.Add(CatChu);
        user[1].new_attempt(0, true);
        
        //Initialize Problem
        ProgramProblem problem1 = new ProgramProblem("1", "HelloWorld", "Please write a c program to print HelloWorld.", "TA");
        ProgramProblem problem2 = new ProgramProblem("2", "Prime", "Please write a c program to identify prime number", "TA");
        problems.Add(problem1);
        problems.Add(problem2);
        problems[0].edit_statistics(1, 1);
        problems[1].edit_statistics(0, 0);
        problems[0].add_testcases("", "Hello World");
        problems[1].add_testcases("5", "Prime");
        problems[1].add_testcases("6", "Not prime");
    }



    public string login(string username, string password)
    {
        int user_position;
        int user_num = user.Count;
        for (user_position = 0; user_position < user_num; user_position++)
        {
            if (user[user_position].checklogin(username, password))
            {
                user_logined = user_position;
                logined_type = user[user_logined].Type;
                return logined_type;
            }
        }
        return null;
    }
    public void logout()
    {
        logined_type = null;
    }
    public string browser_problem_title(int problem_num)
    {
        return problems[problem_num].Title;
    }
    public List<string> browse_problem_list()
    {
        List<string> problem_list = new List<string>();
        for (int i = 0; i < problems.Count; i++)
        {
            problem_list.Add(problems[i].Title);
        }
        return problem_list;
    }
    public List<string> browse_problem()
    {
        List<string> problem = new List<string>();
        problem.Add(problems[question_selected].Title);
        problem.Add(problems[question_selected].Content);
        problem.Add(question_selected.ToString());
        return problem;
    }
    public List<int> browse_statistics(int question_selected)
    {
        if (logined_type == "Admin")
        {
            List<int> stat = new List<int>();
            stat.Add(problems[question_selected].Ac);
            stat.Add(problems[question_selected].Attempt);
            return stat;
        }
        return null;
    }
    public void load_admin_page() { }

    public void upload_problem(string title, string content)
    {
        for(int i = 0; i < user.Count; i++)
        {
            user[i].initialize_AC_attempt(0, 0);
        }
        string author = user[user_logined].Name;
        int problem_num = problems.Count;
        problem_num++;
        ProgramProblem new_program = new ProgramProblem(problem_num.ToString(), title, content, author);
        problems.Add(new_program);

    }

    public void edit_problem(int problem_num, string title, string content)
    {
        problems[problem_num].edit_problem(title, content);
    }
    public void add_testcases(string input, string output)
    {
        problems[question_selected].add_testcases(input, output);
    }
    public int browse_testcase(int question_selected)
    {
        return problems[question_selected].browse_testcases_list();
    }
    public void select_testcase(int testcase_selected)
    {
        problems[question_selected].Testcase_selected = testcase_selected;

    }

    public List<string> get_testcase(int question_num)
    {

        List<string> testcase_InAndOut = new List<string>();
        testcase_InAndOut.Add(problems[question_num].Testcase_input[problems[question_num].Testcase_selected]);
        testcase_InAndOut.Add(problems[question_num].Testcase_output[problems[question_num].Testcase_selected]);
        return testcase_InAndOut;
    }
    public void edit_testcases(int question_num, string input, string output)
    {
        int testcase_num = problems[question_num].Testcase_selected;
        problems[question_num].edit_testcase(testcase_num, input, output);
    }


    public int[,] view_student_statistic()
    {
        int problem_num = problems.Count;
        int[,] student_statistic = new int[problem_num,2];
        for(int i = 0; i < problem_num; i++)
        {
            student_statistic[i,0] = user[user_logined].Ac[i];
            student_statistic[i, 1] = user[user_logined].Attempt[i];
        }
        return student_statistic;
    }

    public void submit_file(string input_path) {
        List<bool> testcase_result = compile_run(input_path);
        bool student_corrct = !testcase_result.Contains(false);
        string Message;
        if (student_corrct)        
        {
            Message = "Congratulation, your program pass all the test cases";
        }
        else
        {
            Message = "Sorry, your program cannot pass all the test cases";
        }
        for (int i = 0; i < testcase_result.Count; i++)
        {
            Message += "\nTestcase" + (i+1) + ": " + testcase_result[i];
        }
        MessageBox.Show(Message);
        int user_AC = user[user_logined].Ac[question_selected];
        int user_Attempt = user[user_logined].Attempt[question_selected];
        problems[question_selected].new_attempt(student_corrct, user_AC, user_Attempt);
        user[user_logined].new_attempt(question_selected, student_corrct);
    }
    public List<bool> compile_run(string input_path)
    {
        List<bool> testcase_result = new List<bool>();
        string exe_path = input_path.Replace(".c", ".exe");
        File.Delete(exe_path);
        Gcc(input_path, exe_path);
        int num_testcase = problems[question_selected].Testcase_output.Count;
        for (int i = 0; i < num_testcase; i++)
        {
            string input = problems[question_selected].Testcase_input[i];
            string output = problems[question_selected].Testcase_output[i];
            string program_output = Run_exe(exe_path, input);
            if (program_output == output)
                testcase_result.Add(true);
            else testcase_result.Add(false);
        }
        return testcase_result;

    }
    public void Gcc(string input_path, string exe_path)
    {
        string GccCmd = "gcc -o " + exe_path + " " + input_path;
        Process gcc = new Process();
        gcc.StartInfo = new ProcessStartInfo()
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "cmd.exe",
            Arguments = "/C " + GccCmd,
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        gcc.Start();
        string program_error = gcc.StandardError.ReadToEnd();
        if (!String.IsNullOrEmpty(program_error))
        {
            MessageBox.Show("Gcc Error Message:\n" + program_error);
        }
        gcc.WaitForExit();
    }
    public string Run_exe(string exe_path, string input)
    {
        Process run_exe = new Process();
        run_exe.StartInfo = new ProcessStartInfo()
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "cmd.exe",
            Arguments = "/C " + exe_path,
            RedirectStandardInput = true,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        };
        run_exe.Start();
        run_exe.StandardInput.WriteLine(input);
        string program_error = run_exe.StandardError.ReadToEnd();
        if (!String.IsNullOrEmpty(program_error))
        {
            MessageBox.Show("Exe Error Message:\n" + program_error);
        }
        string program_output = run_exe.StandardOutput.ReadToEnd();
        run_exe.WaitForExit();
        return program_output;
    }

    public string create_program_file(string code)
    {
        //Change problem title to file name.
        string filename = problems[question_selected].Title;
        filename = filename.Replace(" ", "");
        filename = filename.ToLower();
        string filepath = "/Users/wscbr/Documents/BrandonDocument/CU/Year3Sem1/IERG3080/Project/" + filename + ".c";
        FileInfo file = new FileInfo(filepath);
        file.Directory.Create();
        File.WriteAllText(filepath, code);

        return filepath;
    }
}



// Each problems has its ID, title, text descriptions, test cases and stat
// Admin or author can edit the problems, including test cases
// Stat of the problem is updated once user attempts the problem
public class ProgramProblem
{
    protected string ID, title, content, author;
    protected int trial, difficulty, timeLimit, memoryLimit;
    protected int AC, attempt;
    
    public int Ac { 
        get { return AC; }
    }
    public int Attempt { 
        get { return attempt; }
    }
    protected double acRate, tags;
    protected bool isLive;
    protected List<string> testcase_input = new List<string>();
    protected List<string> testcase_output = new List<string>();
    protected List<string> testcase_correct = new List<string>();

    protected int testcase_selected;
    public int Testcase_selected
    {
        get { return testcase_selected; }
        set { if (value >= 0) testcase_selected = value; }
    }
    public ProgramProblem() { } // constructors
    public ProgramProblem(string ID, String title, string content, string author)
    {
        this.ID = ID;
        this.title = title;
        this.content = content;
        this.author = author;

    }
    public ProgramProblem(string filename) { }
    public string PID
    {
        get { return ID; }
    } // read-only property
    public string Title
    {
        get { return title; }
    } // read-only property
    public string Content
    {
        get { return content; }
    } // read-only property
    public string Author
    {
        get { return author; }
    } // read-only property
    public List<string> Testcase_input
    {
        get { return testcase_input; }
    }
    public List<string> Testcase_output
    {
        get { return testcase_output; }
    }
    public List<string> Testcase_correct
    {
        get { return testcase_correct; }
    }

    public string Difficulty
    { // Data abstraction, read-only property
        get
        {
            if (difficulty == 0) return "Easy";
            else if (difficulty == 1) return "Moderate";
            else if (difficulty == 2) return "Difficult";
            else return "Error";
        }
    }
    public double TimeLimit
    { // Data abstraction, read-only property
        get { return timeLimit / 1000; } // ms to sec
    }
    public double MemoryLimit
    { // Data abstraction, read-only property

        get { return memoryLimit / 1000000; } // Byte to MB
    }
    public double ACRate
    { // read-only property
        get { return acRate; }
    }
    // compile time polymorphism
    public void edit_problem(string title)
    {
        this.title = title;
    }
    public void edit_problem(string title, string content)
    {
        this.title = title;
        this.content = content;
    }
    public void edit_problem(string title, string content, int difficulty,
    int timeLimit, int memoryLimit)
    {
        this.title = title;
        this.content = content;
        this.difficulty = difficulty;
        this.timeLimit = timeLimit;
        this.memoryLimit = memoryLimit;

    }
    public void add_testcases(string input, string output)
    {
        testcase_input.Add(input);
        testcase_output.Add(output);
    }
    public void edit_statistics(int AC, int attempt)
    {
        this.AC = AC;
        this.attempt = attempt;
    }

    public int browse_testcases_list()
    {
        int testcase_num = 0;
        if (testcase_input.Count == testcase_output.Count)
        {
            testcase_num = testcase_input.Count;
        }
        return testcase_num;
    }
    public void edit_testcase(int testcase_num, string input, string output)
    {
        testcase_input[testcase_num] = input;
        testcase_output[testcase_num] = output;
    }
    public void new_attempt(bool problem_result, int user_AC, int user_Attempt)
    {
        if (user_Attempt == 0)
        {
            attempt++;
        }
        if (problem_result&user_AC==0)
        {
            AC++;
        }
    }

}
// User has his ID, name, password and user type
// User can edit problem, attempt problems
// If admin or TA login the system, they can create problems, view student
// submissions, view problem stat, ... et
// If students login the system, they can select and attempt problems
public class User
{
    protected string ID, name, password, type;
    protected List<int> AC = new List<int>();
    protected List<int> attempt = new List<int>();
    public List<int> Ac { get { return AC; } }
    public List<int> Attempt { get { return attempt;} }
    protected int selected_question;
    public string Type { get { return type; } }
    public string Name { get { return name; } }
    public User() { } // constructors
    public User(string ID, string name, string password)
    {
        initialize_AC_attempt(0, 0); //Problem 1
        initialize_AC_attempt(0, 0); //Problem 2
        this.ID = ID;
        this.name = name;
        this.password = password;
    }// runtime polymorphism
    public void initialize_AC_attempt(int AC_num, int attempt_num)
    {
        AC.Add(AC_num);
        attempt.Add(attempt_num);
    }
    public void new_attempt(int problem_num, bool problem_result)
    {
        attempt[problem_num]++;
        if (problem_result)
        {
            AC[problem_num]++;
        }
    }
    public bool checklogin(string name, string password)
    {
        if (this.name == name && this.password == password) return true;
        else return false;
    }
    public virtual void edit_profile(string name, string password)
    {
        this.name = name;
        this.password = password;
    }
    public void submit_problem(string problemID) { }
    public void select_problem(string problemID) { }
    public void upload_program(string problemID) { }
}
public class Student : User
{
    public Student() { } // constructor
    public Student(string ID, string name, string password) : base(ID, name, password)
    {
        type = "Student";
    }
    public override void edit_profile(string name, string password) { }
}
public class Admin : User
{
    public Admin() { } // constructor
    public Admin(string ID, string name, string password) : base(ID, name, password)
    {
        type = "Admin";
    }
    public override void edit_profile(string name, string password) { }
    public void create_problem(string title, string content)
    {
    }
    void check_record() { }
    void view_statistics() { }

}

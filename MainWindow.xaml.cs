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

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public List<Student>? DatabaseStudents { get; private set; } 
		public List<Courses>? DatabaseCourses { get; private set; }

		public MainWindow()
        {
            InitializeComponent();
        }

		public void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			ItemList.Items.Clear();
		}

		private void Enroll_Click(object sender, RoutedEventArgs e)
		{
			EnrollModulesWindow();
			Close();
		}

		public void EnrollModulesWindow()
		{
			ModuleReg module = new ModuleReg();
			module.Show();
		}

		private void Student_Profile_Click(object sender, RoutedEventArgs e)
		{
			EditProfileWindow();
			Close();
		}
		public void EditProfileWindow()
		{
			StudentDetails edit = new StudentDetails();
			edit.Show();

		}

		private void Log_Out_Click(object sender, RoutedEventArgs e)
		{
			LoginWindowOpen();
			Close();
		}

		public void LoginWindowOpen()
		{
			LoginWindow edit = new LoginWindow();
			edit.Show();

		}
		private void ViewModule_Click(object sender, RoutedEventArgs e)
		{
			using (StudentDataContext context = new StudentDataContext())
			{
				DatabaseStudents = context.Students.ToList();
				ItemList.ItemsSource = DatabaseStudents;
			}
		}

		private void Update_Profile_Click(object sender, RoutedEventArgs e)
		{
			Update();
			MessageBox.Show("User updated successfully");
		}

		public void Update()
		{
			using (StudentDataContext context = new StudentDataContext())

			{
				Student selectedStudent = ItemList.SelectedItem as Student;
				var RegNo = txtRegNo.Text;
				var Name = txtName.Text;
				var Age = txtAge.Text;
				var Department = txtdpt.Text;
				var YearOfStudy = txtyear.Text;


				if (RegNo!= null)
				{
					Student student = context.Students.Find(selectedStudent.RegNo);
					student.Name = Name;
					student.Age = Age;
					student.Department = Department;
					student.YearOfStudy = YearOfStudy;
					context.SaveChanges();
				}
			}

		}

	}
}

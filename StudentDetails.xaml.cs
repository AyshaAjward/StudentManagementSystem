using Microsoft.Xaml.Behaviors.Core;
using System.Windows;

namespace StudentRegistrationSystem
{
	/// <summary>
	/// Interaction logic for StudentDetails.xaml
	/// </summary>
	public partial class StudentDetails : Window
    {

		public List<Student> DatabaseStudents;
		public List<Courses> DatabaseCourses;

		public StudentDetails()
        {
            InitializeComponent();
        }

        public void Create()
        {

            using (StudentDataContext context = new StudentDataContext())
            {
                var RegNo = txtRegNo.Text;
                var Name = txtName.Text;
                var Age = txtAge.Text;
                var Department = txtdpt.Text;
                var YearOfStudy = txtyear.Text;

				

				if (RegNo != null)
                {
					context.Students.Add(new Student()
					{
						RegNo = RegNo,
						Name = Name,
						Age = Age,
						Department = Department,
						YearOfStudy = YearOfStudy
					});
					context.SaveChanges();
				}               
			}
        }

		public Student SelectedStudent { get; set; }

		
        public void Delete() 
        {
			using (StudentDataContext context = new StudentDataContext())
			{
				var RegNo = txtRegNo.Text;
				var Name = txtName.Text;
				var Age = txtAge.Text;
				var Department = txtdpt.Text;
				var YearOfStudy = txtyear.Text;

				if (RegNo != null)
				{
					Student Student = context.Students.Single(x => x.RegNo == RegNo); ;
					context.Remove(Student);
					context.SaveChanges();
				}
			}
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			Create();
			MessageBox.Show("User created successfully");
		}
		
		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			Delete();
			MessageBox.Show("User deleted successfully");
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			GoBack();
			Close();
		}

		public void GoBack()
		{
			MainWindow main = new MainWindow();
			main.Show();

		}

		

	}

}

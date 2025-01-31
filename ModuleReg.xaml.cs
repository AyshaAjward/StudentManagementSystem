using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for ModuleReg.xaml
    /// </summary>
    public partial class ModuleReg : Window
    {
		public List<Courses>? DatabaseCourses { get; private set; }
		public ModuleReg()
        {
            InitializeComponent();
        }

		public void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			ItemList.Items.Clear();
		}

		public void RegisterModule()
		{

			using (CourseDataContext context = new CourseDataContext())
			{
				var CourseID = CourseIDTextBox.Text;
				var CourseName = CourseNameTextBox.Text;
				var Credits = CreditsTextBox.Text;

				if (CourseID != null)
				{
					context.Courses.Add(new Courses()
					{
						CourseID = CourseID,
						CourseName = CourseName,
						Credits = Credits
					});
					context.SaveChanges();
					MessageBox.Show("Module successfully registered");
				}
			}
		}
		public void DeleteModule()
		{

			using (CourseDataContext context = new CourseDataContext())
			{
				var CourseID = CourseIDTextBox.Text;
				var CourseName = CourseNameTextBox.Text;
				var Credits = CreditsTextBox.Text;


				if (CourseID != null)
				{
					Courses course = context.Courses.Single(x => x.CourseID == CourseID);
					context.Remove(course);
					context.SaveChanges();
					MessageBox.Show("Module successfully deleted");
				}
			}
		}
		public void ViewModule ()
		{
			using (CourseDataContext context = new CourseDataContext())
			{
				DatabaseCourses = context.Courses.ToList();
				ItemList.ItemsSource = DatabaseCourses;

			}
		}
		private void Register_Module_Click(object sender, RoutedEventArgs e)
		{
			RegisterModule();
		}

		private void Delete_Module_Click(object sender, RoutedEventArgs e)
		{
			DeleteModule();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			GoBack();
			Close();
		}

		public void GoBack()
		{
			MainWindow main = new MainWindow();
			main.Show();

		}
		private void View_Module_Click(object sender, RoutedEventArgs e)
		{
			ViewModule();
		}
	}
}

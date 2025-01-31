using System;
using System.Collections.Generic;
using System.Configuration;
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
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void OpenWindow(object sender, RoutedEventArgs e)
		{

			var Username = UsernameText.Text;
			var Password = PasswordText.Password;

			using (StudentDataContext context = new StudentDataContext())
			{
				bool userfound = context.Students.Any(Student => Student.Name == Username && Student.Password == Password);

				if (userfound)
				{
					GrantAccess();
					Close();
				}
				else
				{
					MessageBox.Show("User Not Found");
				}

			}

        }

		public void GrantAccess()
		{
			MainWindow main = new MainWindow();
			main.Show();

		}
    }
}

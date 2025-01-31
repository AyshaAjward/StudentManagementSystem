using System.Configuration;
using System.Data;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace StudentRegistrationSystem
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			DatabaseFacade facade = new DatabaseFacade(new StudentDataContext());
			facade.EnsureCreated();

			DatabaseFacade facade1 = new DatabaseFacade(new CourseDataContext());
			facade1.EnsureCreated();
		}


	}

}

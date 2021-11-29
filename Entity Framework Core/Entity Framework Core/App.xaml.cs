using Entity_Framework_Core.DataContext;
using Entity_Framework_Core.Interfaces;
using Entity_Framework_Core.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entity_Framework_Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new BooksPage());
        }
        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCoreya.db");

            return new AppDbContext(DbPath);
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}

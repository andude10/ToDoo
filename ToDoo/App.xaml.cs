using System;
using System.IO;
using Xamarin.Forms;
using ToDoo.Data;

namespace ToDoo
{
    public partial class App : Application
    {
        static CaseDatabase database;
        public static CaseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CaseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyToDo.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Xamarin.Forms.Device.SetFlags(new string[] { "AppTheme_Experimental" });
            InitializeComponent();
            MainPage = new AppShell();
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

using System;
using TatExpress2.Services;
using TatExpress2.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;

namespace TatExpress2
{
    public partial class App : Application
    {
        public static MyDbContext myDb;
        public const string DATABASE_NAME = "Testdb.db";

        public static MyDbContext dbContext
        {
            get
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                if (myDb == null)
                {
                    
                  
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"TatExpress2.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                myDb = new MyDbContext(dbPath);
                               fs.Flush();
                            }
                        }
                    
                   
                }
                else
                {
                    myDb = new MyDbContext(dbPath);
                }
                    
                return myDb;
            }
        }
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
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

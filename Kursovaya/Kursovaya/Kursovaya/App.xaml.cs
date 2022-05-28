using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kursovaya.Data;

namespace Kursovaya
{
    public partial class App : Application
    {
        public static FFDB ffDB = new FFDB();

        public App()
        {


            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("Kursovaya.FFDB.db"))
                {
                    using (FileStream ms = new FileStream(FFDB.dbPath, FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(ms);
                        ms.Flush();
                    }
                }

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

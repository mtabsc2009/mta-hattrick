using System;
using WPFView;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WPFMainProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Application_Startup_1(object sender, StartupEventArgs e)
        {
            

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Window1 wnd = new Window1();
            wnd.Show();
        }
    }
}

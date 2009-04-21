using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HatTrick.Views.WinformsView
{
    public partial class GettingStartedForm : DefaultForm
    {
        public GettingStartedForm()
        {
            InitializeComponent();
        }

        private void GettingStartedForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Environment.CurrentDirectory + "\\" +  "Getting Started With Hattrick.mht");
            //webBrowser1.Navigate(@"C:\Elad\Hattrick2\GeneralTester\WinformsView\Getting Started With Hattrick.mht");
        }


    }
}

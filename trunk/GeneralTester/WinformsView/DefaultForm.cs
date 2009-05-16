using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HatTrick.Views.WinformsView.localhost;

namespace HatTrick.Views.WinformsView
{
    public partial class DefaultForm : Form
    {
        protected Game Game = WelcomeScreen.Game;
        
        public DefaultForm()
        {
            InitializeComponent();
        }
    }
}

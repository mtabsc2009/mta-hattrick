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
    public partial class FirstTimeTooTipForm : DefaultForm
    {
        public FirstTimeTooTipForm()
        {
            InitializeComponent();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            bool isOutOfView = Location.Y + Height > Parent.Size.Height;
            if (isOutOfView)
            {
                adjustFormPosition();
            }
        }

        private void adjustFormPosition()
        {
            int delta = Location.Y + Height - Parent.Size.Height;
            Location = new Point(Location.X, Location.Y - delta);
        }
    }
}

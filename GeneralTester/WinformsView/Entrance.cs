using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HatTrick;

namespace HatTrick.Views.WinformsView
{
    public partial class Entrance : DefaultForm
    {
        public Entrance()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsername, "Username must not be empty");
            }
            else
            {
                errorProvider1.Clear();
                if (txtPassword.Text == string.Empty)
                {
                    errorProvider1.SetError(txtPassword, "Password must not be empty");
                }
                else if (txtTeamName.Visible)
                {
                    if (txtTeamName.Text == string.Empty)
                    {
                        errorProvider1.SetError(txtTeamName, "Team name must not be empty");
                    }
                    else if (Game.UserExists(txtUsername.Text))
                    {
                        errorProvider1.SetError(txtUsername, "Username already exists");
                    }
                    else if (Game.TeamExists(txtTeamName.Text))
                    {
                        errorProvider1.SetError(txtTeamName, "Team name already exists");
                    }
                    else if (!Game.CreateUser(txtUsername.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Unknwon error occured creating your account", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (!CheckLogin(txtUsername.Text, txtPassword.Text))
                    {
                            MessageBox.Show("Unknwon error occured in login", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (Game.CreateTeam(txtTeamName.Text) == null)
                    {
                        MessageBox.Show("Unknwon error occured creating your team", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        PerformLogin();
                    }
                }
                else 
                {
                    PerformLogin();
                }
            }
        }

        private bool CheckLogin(string strUsername, string strPassword)
        {
            return (Game.Login(strUsername, strPassword) != null);
        }

        private void PerformLogin()
        {
            if (!CheckLogin(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GettingStartedForm gs = new GettingStartedForm();
            gs.Show();
            btnNewAccount.Hide();
            lblTeamName.Show();
            txtTeamName.Show();
            btnLogin.Text = "Join!";
            txtUsername.Focus();
        }

        private void Entrance_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            // Uncomment for "auto login"
           // txtUsername.Text = "oron";
            //txtPassword.Text = "oron";
            //btnLogin_Click(sender, e);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEXT;

namespace T.EX.T
{
    public partial class FrmLogIn : Form
    {
        public string Username => txtUsername.Text;
        public FrmLogIn()
        {
            InitializeComponent();
            lblUsername.Click += lblUsername_Click;
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Visible = true;
            txtUsername.Focus();

        }
        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Visible = true;
            txtPassword.Focus();
        }

        private void FrmLogIn_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;


            LoginBG.Location = new Point((formWidth - LoginBG.Width) / 2, (formHeight - LoginBG.Height) / 2);
            btnLogin.Location = new Point((formWidth - btnLogin.Width) / 2, btnLogin.Location.Y);
            pnlUsername.Location = new Point((formWidth - pnlUsername.Width) / 2, (formHeight - pnlUsername.Height) / 2);
            pnlPassword.Location = new Point((formWidth - pnlPassword.Width) / 2, (formHeight / 2 ) + pnlUsername.Height);
            btnLogin.MakeButtonRounded(6);
            pnlUsername.MakePanelRounded(6);
            pnlPassword.MakePanelRounded(6);
        }

  
        
        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            Session.Username = username;

            this.Hide();
            FrmOpn FrmOpn = new FrmOpn();
            FrmOpn.FormClosed += (s, args) => Application.Exit();
            FrmOpn.Show();


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

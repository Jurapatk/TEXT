using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T.EX.T;

namespace TEXT
{
    public partial class Frm0400 : Form
    {
        public Frm0400()
        {
            InitializeComponent();

        }
        private void Frm0400_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;
        }
        private void Frm0400_Shown(object sender, EventArgs e)
        {
            pnl0400.Focus();

        }
        private void Frm0400_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;


            pnlHeader.Width = formWidth;
            pnl0400.Width = formWidth - 160;
            pnl0400.Height = formHeight - pnlHeader.Height - 80;
            pnl0400.Location = new Point((formWidth - pnl0400.Width) / 2, (formHeight - pnl0400.Height + pnlHeader.Height) / 2);

            pnl0400.MakePanelRounded(20);
        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.FormClosed += (s, args) => Application.Exit();
            OpnForm.Show();
        }

        private void icoLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn loginForm = new FrmLogIn();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.Show();
        }

        private void icoSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSetting FrmSetting = new FrmSetting();
            FrmSetting.FormClosed += (s, args) => Application.Exit();
            FrmSetting.Show();
        }
    }
}

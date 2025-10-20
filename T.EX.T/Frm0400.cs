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
            this.Load += Frm0400_Load;

        }
        private void Frm0400_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;
            Center();


        }
        private void Center()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;


            pnlHeader4.Width = formWidth;
            pnl0400.Width = formWidth - 160;
            pnl0400.Height = formHeight - pnlHeader4.Height - 80;
            pnl0400.Location = new Point((formWidth - pnl0400.Width) / 2, (formHeight - pnl0400.Height + pnlHeader4.Height) / 2);

            pnl0400.MakePanelRounded(20);
            //btn392Back.MakeButtonRounded(8);
            //btn392Print.MakeButtonRounded(8);

        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.Show();
        }

        private void icoLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn loginForm = new FrmLogIn();
            loginForm.Show();
        }

        private void icoSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSetting FrmSetting = new FrmSetting();
            FrmSetting.Show();
        }
    }
}

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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;


        }
        private void FrmSetting_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;


            pnlHeader.Width = formWidth;
            pnlSetting.Width = formWidth - 160;
            pnlSetting.Height = formHeight - pnlHeader.Height - 80;
            pnlSetting.Location = new Point((formWidth - pnlSetting.Width) / 2, (formHeight - pnlSetting.Height+ pnlHeader.Height) / 2);

            pnlSetting.MakePanelRounded(20);
        }
        private void icoLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn loginForm = new FrmLogIn();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.Show();
        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.FormClosed += (s, args) => Application.Exit();
            OpnForm.Show();
        }

        private void btnSettingSave_Click(object sender, EventArgs e)
        {

        }
    }
}

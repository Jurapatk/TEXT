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
            this.Load += FrmSetting_Load;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;
            Center();


        }
        private void Center()
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
            loginForm.Show();
        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.Show();
        }

        private void btnSettingSave_Click(object sender, EventArgs e)
        {

        }
    }
}

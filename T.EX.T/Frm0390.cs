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
    public partial class Frm0390 : Form
    {
        public Frm0390()
        {
            InitializeComponent();
            this.Load += Frm0390_Load;
        }

        private void Frm0390_Load(object sender, EventArgs e)
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
            pnl0390.Width = formWidth - 160;
            pnl0390.Height = formHeight - pnlHeader.Height - 20;
            pnl0390.Location = new Point((formWidth - pnl0390.Width) / 2, (formHeight - pnl0390.Height + pnlHeader.Height) / 2);

            pnl0390.MakePanelRounded(20);
            btn39Reset.MakeButtonRounded(6);
            btn39ChkBar.MakeButtonRounded(6);
            btn39Save.MakeButtonRounded(6);
            btn39Next.MakeButtonRounded(6);
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn39ChkBar_Click(object sender, EventArgs e)
        {

        }

        private void icoSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSetting FrmSetting = new FrmSetting();
            FrmSetting.Show();
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

        private void btn39Next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm03902 Frm03902 = new Frm03902();
            Frm03902.Show();
        }
    }
}

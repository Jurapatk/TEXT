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
    public partial class Frm03902 : Form
    {
        public Frm03902()
        {
            InitializeComponent();
            this.Load += Frm03902_Load;
        }

        private void Frm03902_Load(object sender, EventArgs e)
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
            pnl03902.Width = formWidth - 160;
            pnl03902.Height = formHeight - pnlHeader.Height - 80;
            pnl03902.Location = new Point((formWidth - pnl03902.Width) / 2, (formHeight - pnl03902.Height + pnlHeader.Height) / 2);

            pnl03902.MakePanelRounded(20);
            btn392Back.MakeButtonRounded(8);
            btn392Print.MakeButtonRounded(8);

        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.Show();
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

        private void btn392Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm0390 Frm0390 = new Frm0390();
            Frm0390.Show();
        }

        private void txt39BarcodeS_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt39BarcodeS_Click(object sender, EventArgs e)
        {
            txt39BarcodeS.Text = "";
        }

        private void txt39BarcodeE_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt39BarcodeE_Clik(object sender, EventArgs e)
        {
            txt39BarcodeE.Text = "";
        }
    }
}

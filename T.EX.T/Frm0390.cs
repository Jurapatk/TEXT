using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using T.EX.T;



namespace TEXT
{
    public partial class Frm0390 : Form
    {
        public Frm0390()
        {
            InitializeComponent();

        }


        private void Frm0390_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;
            using (var cn = new SqlConnection(g_.ConStr))
            {
                try
                {
                    cbbPartName.Items.Clear();
                    cbbCoverMaterialCode.Items.Clear();
                    cbbReOven.Items.Clear();
                    cbbShift.Items.Clear();
                    cbbFIPGMatCode.Items.Clear();
                    cbbProductRevision.Items.AddRange(Enumerable.Range('A', 26)
                        .Select(i => ((char)i).ToString())
                        .ToArray());
                    cbbTool.Items.AddRange(Enumerable.Range(1, 9).Select(n => n.ToString()).ToArray());
                    cbbReOven.Items.Add("F");
                    cbbReOven.Items.Add("Q");
                    cbbReOven.Items.Add("R");
                    cbbReOven.Items.Add("T");
                    cbbShift.Items.Add("A");
                    cbbShift.Items.Add("B");


                    cn.Open();

                    string sqlPart = $@"SELECT DISTINCT cell_value FROM {g_.MainDB}.dbo.tb_master_data WITH (NOLOCK)
                             WHERE column_name = 'Part name' ORDER BY cell_value";
                    string sqlCover = $@"SELECT DISTINCT cell_value FROM {g_.MainDB}.dbo.tb_master_data WITH (NOLOCK)
                             WHERE column_name = 'Cover material name' ORDER BY cell_value";
                    string sqlFIPG = $@"SELECT DISTINCT cell_value FROM {g_.MainDB}.dbo.tb_master_data WITH (NOLOCK)
                             WHERE column_name = 'FIPG Material name' ORDER BY cell_value";


                    using (var cmdPart = new SqlCommand(sqlPart, cn))
                    using (var rdPart = cmdPart.ExecuteReader())
                    {
                        while (rdPart.Read())
                        {
                            cbbPartName.Items.Add(rdPart.GetString(0));
                        }
                    }

                    using (var cmdCover = new SqlCommand(sqlCover, cn))
                    using (var rdCover = cmdCover.ExecuteReader())
                    {
                        while (rdCover.Read())
                        {
                            cbbCoverMaterialCode.Items.Add(rdCover.GetString(0));
                        }
                    }

                    using (var cmdFIPG = new SqlCommand(sqlFIPG, cn))
                    using (var rdFIPG = cmdFIPG.ExecuteReader())
                    {
                        while (rdFIPG.Read())
                        {
                            cbbFIPGMatCode.Items.Add(rdFIPG.GetString(0));
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Load error: " + ex.ToString());
                }

            }
        }
        private void Frm0390_Shown(object sender, EventArgs e)
        {
            pnl0390.Focus();
            cbbPartName.Focus();
        }
        private void Frm0390_Resize(object sender, EventArgs e)
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
            FrmSetting.FormClosed += (s, args) => Application.Exit();
            FrmSetting.Show();
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

        private void btn39Next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm03902 Frm03902 = new Frm03902();
            Frm03902.FormClosed += (s, args) => Application.Exit();
            Frm03902.Show();
        }

        private void cbbPartName_click(object sender, EventArgs e)
        {
            //SqlConnection cn = new SqlConnection(g_.ConStr);
            //try
            //{
            //    cbbProductName.Items.Clear();
            //    cn.Open();
            //    string Sql = $"SELECT DISTINCT cell_value FROM {g_.MainDB}.dbo.tb_master_data (NOLOCK) where column_name = 'Part name' ORDER BY cell_value";
            //    SqlCommand cm = new SqlCommand(Sql, cn);
            //    SqlDataReader rd = cm.ExecuteReader();
            //    while (rd.Read())
            //    {
            //        cbbPartName.Items.Add(rd[0]);
            //    }
            //    rd.Close();

            //}
            //catch (Exception) { }
        }

        private void btn39ChkBar_Click_1(object sender, EventArgs e)
        {

        }
    }
}

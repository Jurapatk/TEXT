using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T.EX.T;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TEXT
{
    public partial class FrmOpn : Form
    {
        public FrmOpn()
        {
            InitializeComponent();
        }


        private Timer _slideTimer;
        private bool _isSlidingOut = false;
        private bool _isShowingOut = true;
        private bool _isOutShown = false;
        private class SlideInfo
        {
            public Control Ctrl;
            public int StartX, StartY;
            public int TargetX, TargetY;
        }

        private List<SlideInfo> _slides;

        private void FrmOpn_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;
            _slideTimer = new Timer();
            _slideTimer.Interval = 15; // ms
            _slideTimer.Tick += SlideTimer_Tick;
            List<string> arrTable = SqlSelect.GetTableArray();
            var dataTables = new List<DataTable>();

            for (int i = 0; i < arrTable.Count; i++)
            {
                DataTable dt = SqlSelect.GetDataTable(arrTable[i]);
                dataTables.Add(dt);
            }


            lblUsername.Text = user;
          

        }

    
    private void FrmOpn_Resize(object sender, EventArgs e)
        {
    int formWidth = this.ClientSize.Width;
    int formHeight = this.ClientSize.Height;

    btnOpn.MakeButtonRounded(10);
    btn39.MakeButtonRounded(10);
    btn40.MakeButtonRounded(10);
    btn50.MakeButtonRounded(10);
    btn61.MakeButtonRounded(10);

    pnlHeader.Width = formWidth;

    int w = this.ClientSize.Width;
    int h = this.ClientSize.Height;

    int marginX = 180;
    int yTop = 180;
    int yMid = h / 2 - 40;
    int yBottom = h - 280;

    int centerX = (w - btn40.Width) / 2;

    btnOpn.Location = new Point(centerX, yMid);
    btn39.Location  = new Point(centerX, yMid);
    btn50.Location  = new Point(centerX, yMid);
    btn61.Location  = new Point(centerX, yMid);
    btn40.Location  = new Point(centerX, yMid);
}

private void btnOpn_Click(object sender, EventArgs e)
{
    int w = this.ClientSize.Width;
    int h = this.ClientSize.Height;

    int yTop = 180;
    int yMid = h / 2 - 40;
    int yBottom = h - 280;

    int centerX = (w - btn40.Width) / 2;

    _isOutShown = !_isOutShown; 

    BuildSlidesForMode(_isOutShown);

    foreach (var s in _slides)
    {
        s.StartX = s.Ctrl.Location.X;
        s.StartY = s.Ctrl.Location.Y;
    }

    _isSlidingOut = true;
    _slideTimer.Start();
}

private void BuildSlidesForMode(bool showOut)
{
    int w = this.ClientSize.Width;
    int h = this.ClientSize.Height;

    _slides = new List<SlideInfo>();

    int marginX = 180;
    int yTop = 180;
    int yMid = h / 2 - 40;
    int yBottom = h - 280;

    int centerX = (w - btn40.Width) / 2;

    if (showOut)
    {
        _slides.Add(new SlideInfo { Ctrl = btn39, StartX = centerX, StartY = yMid, TargetX = marginX, TargetY = yTop });
        _slides.Add(new SlideInfo { Ctrl = btn50, StartX = centerX, StartY = yMid, TargetX = marginX, TargetY = yBottom });
        _slides.Add(new SlideInfo { Ctrl = btn61, StartX = centerX, StartY = yMid, TargetX = w - btn61.Width - marginX, TargetY = yBottom });
        _slides.Add(new SlideInfo { Ctrl = btn40, StartX = centerX, StartY = yMid, TargetX = w - btn61.Width - marginX, TargetY = yTop });
    }
    else
    {
        _slides.Add(new SlideInfo { Ctrl = btn39, StartX = centerX, StartY = yMid, TargetX = centerX, TargetY = yMid });
        _slides.Add(new SlideInfo { Ctrl = btn50, StartX = centerX, StartY = yMid, TargetX = centerX, TargetY = yMid });
        _slides.Add(new SlideInfo { Ctrl = btn61, StartX = centerX, StartY = yMid, TargetX = centerX, TargetY = yMid });
        _slides.Add(new SlideInfo { Ctrl = btn40, StartX = centerX, StartY = yMid, TargetX = centerX, TargetY = yMid });
    }
}

private void SlideTimer_Tick(object sender, EventArgs e)
{
    if (!_isSlidingOut || _slides == null || _slides.Count == 0)
        return;

    int step = 15; 
    bool allAtTarget = true;

    foreach (var s in _slides)
    {
        int curX = s.Ctrl.Location.X;
        int curY = s.Ctrl.Location.Y;

        int dirX = Math.Sign(s.TargetX - curX);
        int nextX = curX + dirX * step;
        if (dirX == 0) nextX = curX;

        int dirY = Math.Sign(s.TargetY - curY);
        int nextY = curY + dirY * step;
        if (dirY == 0) nextY = curY;

        if ((dirX > 0 && nextX >= s.TargetX) || (dirX < 0 && nextX <= s.TargetX))
            nextX = s.TargetX;
        if ((dirY > 0 && nextY >= s.TargetY) || (dirY < 0 && nextY <= s.TargetY))
            nextY = s.TargetY;

        s.Ctrl.Location = new Point(nextX, nextY);

        if (nextX != s.TargetX || nextY != s.TargetY)
            allAtTarget = false;
    }

    if (allAtTarget)
    {
        _slideTimer.Stop();
        _isSlidingOut = false;
    }
}
        private void btn39_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm0390 Frm0390 = new Frm0390();
            Frm0390.FormClosed += (s, args) => Application.Exit();
            Frm0390.Show();
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

        private void icoBacktoOpn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn loginForm = new FrmLogIn();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.Show();
            
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm0400 Frm0400 = new Frm0400();
            Frm0400.FormClosed += (s, args) => Application.Exit();
            Frm0400.Show();
            
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm0500 Frm0500 = new Frm0500();
            Frm0500.FormClosed += (s, args) => Application.Exit();
            Frm0500.Show();
        }

        private void btn61_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm0610 Frm0610 = new Frm0610();
            Frm0610.FormClosed += (s, args) => Application.Exit();
            Frm0610.Show();
        }
    }


}

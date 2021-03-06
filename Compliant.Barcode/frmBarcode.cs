﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Compliant.Barcode
{
    public partial class frmBarcode : Form
    {
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //private static extern IntPtr CreateRoundRectRgn
        //(
        //    int nLeftRect, // x-coordinate of upper-left corner
        //    int nTopRect, // y-coordinate of upper-left corner
        //    int nRightRect, // x-coordinate of lower-right corner
        //    int nBottomRect, // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        // );

        public frmBarcode()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            //this.Location = new Point(1000,100);
            //this.Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2 - this.Height;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - (this.Width/2)) - (this.Width) ;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var form = new frmCamera();
            form.Show();
        }

        private void frmBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;
        //        paras.ClassStyle |= 0x200;
        //        return paras;
        //    }
        //}
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;

                const int WS_EX_NOACTIVATE = 0x08000000;
                //const int WS_EX_TOOLWINDOW = 0x00000080;
                //baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE);

                return baseParams;
            }
        }
    }
}

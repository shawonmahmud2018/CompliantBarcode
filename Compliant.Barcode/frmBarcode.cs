using System;
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
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var form = new frmCamera();
            form.Show();
        }

        private void frmBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //WindowState = FormWindowState.Minimized;
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
    }
}

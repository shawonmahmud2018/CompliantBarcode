using System.Windows.Forms;

namespace Compliant.Barcode
{
    public partial class frmBarcode : Form
    {
        public frmBarcode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var form = new frmCamera();
            form.Show();
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

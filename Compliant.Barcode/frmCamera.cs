using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Compliant.Barcode
{
    public partial class frmCamera : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;

        public frmCamera()
        {
            InitializeComponent();
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //if (videoDevices.Count > 1)
            //    videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //else
            //    videoDevice = new VideoCaptureDevice(videoDevices[1].MonikerString);

            videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            StartCameras();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var bitmap = videoSourcePlayer.GetCurrentVideoFrame();
            if (bitmap == null)
                return;

            var reader = new BarcodeReader();
            var result = reader.Decode((Bitmap)bitmap.Clone());
            if (result != null)
            {
                Clipboard.SetText(result.Text);
                StopCameras();
                SendKeys.SendWait("^v");
            }
        }
        // Start cameras
        private void StartCameras()
        {
            videoSourcePlayer.VideoSource = videoDevice;
            videoSourcePlayer.Start();

            timer1.Start();
        }
        // Stop cameras
        private void StopCameras()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;
                timer1.Stop();
                this.Hide();
            }
        }

        private void frmCamera_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close camera?", "Compliant Camera", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.
                StopCameras();
                // Call method to save file...
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}

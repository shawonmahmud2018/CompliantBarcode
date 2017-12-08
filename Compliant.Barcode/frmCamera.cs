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
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }

                //if (videoDevices.Count > 1)
                //    videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                //else
                //    videoDevice = new VideoCaptureDevice(videoDevices[1].MonikerString);

                videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                StartCameras();
            }
            catch
            {
                MessageBox.Show("Camera not found !");
            }
        }
        // Start cameras
        private void StartCameras()
        {
            videoSourcePlayer.VideoSource = videoDevice;
            videoSourcePlayer.Start();

            timer1.Start();
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
                if (result.BarcodeFormat.ToString().Equals("CODE_128") || result.BarcodeFormat.ToString().Equals("DATA_MATRIX"))
                {
                    Clipboard.SetText(result.Text);
                    StopCameras();
                    SendKeys.SendWait("^v");
                }
                //else
                //{
                //    StopCameras();
                //    MessageBox.Show(string.Format("Barcode format ({0}) is not valid", result.BarcodeFormat.ToString()));
                //}
            }
        }
        
        // Stop cameras
        private void StopCameras()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                timer1.Stop();
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;                
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

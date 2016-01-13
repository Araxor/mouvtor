using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouvtorEditor
{
    public partial class FrmEditor : Form
    {

        private Timer refreshTimer;
        private bool isRecording;

        public Timer RefreshTimer { get { return refreshTimer; } set { refreshTimer = value; } }
        private bool IsRecording { set { ChangeStateRecording(value); } get { return isRecording; } }


        public FrmEditor()
        {
            InitializeComponent();
            DZEditor.InitProperties(Color.Blue, 12);
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            TSCBXInputDevice.SelectedIndex = 0;
            this.IsRecording = false;
            

            // Initialize timer
            this.RefreshTimer = new Timer();
            this.RefreshTimer.Interval = 10;
            this.RefreshTimer.Tick += RefreshTimer_Tick;
            this.RefreshTimer.Enabled = true;

            /*DZEditor.AddPointDrawing(new Point3DNormalized(0.5, 1, 1));
            DZEditor.AddPointDrawing(new Point3DNormalized(0.25, 0.5, 1));
            DZEditor.AddPointDrawing(new Point3DNormalized(1, 0.5, 1));*/
        }

        void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void TSMIQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TSBRecordAndStop_Click(object sender, EventArgs e)
        {
            this.IsRecording = !this.IsRecording;
        }

        /// <summary>
        /// Change the record state and show the good picture on the tools bar
        /// </summary>
        /// <param name="val">Boolean value</param>
        private void ChangeStateRecording(bool val)
        {
            TSBRecordAndStop.Image = (val) ? Properties.Resources.shape_square : Properties.Resources.bullet_red;
            TSBRecordAndStop.Text = (val) ? "Stop record" : "Record";
            TSSLRecordInfo.Text = (val) ? "Recording" : "Not record";

            this.isRecording = val;
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsRecording = true;
        }

        private void TSMIStopRecording_Click(object sender, EventArgs e)
        {
            this.IsRecording = false;
        }
    }
}

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

        #region Fields
        private Timer refreshTimer;
        private bool isRecording;
        #endregion

        #region Properties
        public Timer RefreshTimer { get { return refreshTimer; } set { refreshTimer = value; } }
        private bool IsRecording { set { ChangeStateRecording(value); } get { return isRecording; } }
        #endregion

        #region Personnal methods
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
        #endregion

        public FrmEditor()
        {
            InitializeComponent();
            DZEditor.InitProperties(Color.Blue, 12);
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            TSCBXInputDevice.SelectedIndex = 0;
            this.DoubleBuffered = true;
            this.IsRecording = false;


            // Initialize timer
            this.RefreshTimer = new Timer();
            this.RefreshTimer.Interval = 100;
            this.RefreshTimer.Tick += RefreshTimer_Tick;
            this.RefreshTimer.Enabled = true;
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

        private void TSMIRecord_Click(object sender, EventArgs e)
        {
            this.IsRecording = true;
        }

        private void TSMIStopRecording_Click(object sender, EventArgs e)
        {
            this.IsRecording = false;
        }
    }
}

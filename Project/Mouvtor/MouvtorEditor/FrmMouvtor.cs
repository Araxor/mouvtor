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

        private bool isRecording;
        private bool IsRecording { set { ChangeStateRecording(value); } get { return isRecording; } }

        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            TSCBXInputDevice.SelectedIndex = 0;
            this.IsRecording = false;
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

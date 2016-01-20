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
using InputDevices;

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
        private IInputDevice DrawingDevice;
        private bool allowDraw = false;
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
            if (allowDraw)
            {
                DZEditor.AddPointDrawing(DrawingDevice.CurrentNormalizedPosition);
            }
            Refresh();
            
        }

        void DrawingDevice_StartDrawing(object sender, EventArgs e)
        {
            allowDraw = true;
        }
        void DrawingDevice_StopDrawing(object sender, EventArgs e)
        {
            allowDraw = false;
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

        private void TSBPencil_Click(object sender, EventArgs e)
        {
            
        }

        private void TSCBXInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TSCBXInputDevice.SelectedIndex)
            {
                case 0:
                    InputDevices.Mouse mouse = new Mouse(DZEditor);
                    DrawingDevice = mouse;
                    break;

                case 1:
                    DrawingDevice = new NovintFalcon();
                    break;
                case 2:
                    InputDevices.LeapMotion leap = new LeapMotion();
                    if (leap.IsConnected)
                    {
                        DrawingDevice = leap;                       
                    }
                    else
                    {
                        MessageBox.Show("Leap motion disconected");
                    }
                    break;
                     
            }
            DrawingDevice.StartDrawing += DrawingDevice_StartDrawing;
            DrawingDevice.StopDrawing += DrawingDevice_StopDrawing;
            
        }
    }
}

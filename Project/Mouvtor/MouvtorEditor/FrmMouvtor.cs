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
        private bool _isRecording;
        #endregion

        #region Properties
        public Timer RefreshTimer { get; set; }
        private bool IsRecording 
        { 
            set 
            {
                this._isRecording = value;
                TSBRecordAndStop.Image = IsRecording ? Properties.Resources.shape_square : Properties.Resources.bullet_red;
                TSBRecordAndStop.Text = IsRecording ? "Stop record" : "Record";
                TSSLRecordInfo.Text = IsRecording ? "Recording" : "Not record";

                if (IsRecording)
                {
                    DZEditor.Clear();
                }
            } 

            get { return _isRecording; } 
        }

        private IInputDevice DrawingDevice { get; set; }
        private bool AllowDraw { get; set; }
        private string SavePath { get; set; }
        #endregion

        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            TSCBXInputDevice.SelectedIndex = 0;
            this.DoubleBuffered = true;
            this.IsRecording = false;

            // Initialize timer
            this.RefreshTimer = new Timer();
            this.RefreshTimer.Interval = 1;
            this.RefreshTimer.Tick += RefreshTimer_Tick;
            this.RefreshTimer.Enabled = true;
        }

        void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (AllowDraw && IsRecording)
            {
                if (!DZEditor.IsDrawing)
                    DZEditor.StartDrawing();
                
                DZEditor.AddPointDrawing(DrawingDevice.CurrentNormalizedPosition);
            }
            else
            {
                if (DZEditor.IsDrawing)
                    DZEditor.StopDrawing();
            }
            DZEditor.CursorPosition = DrawingDevice.CurrentNormalizedPosition;
            Refresh();
        }

        void DrawingDevice_StartDrawing(object sender, EventArgs e)
        {
            AllowDraw = true;
        }
        void DrawingDevice_StopDrawing(object sender, EventArgs e)
        {
            AllowDraw = false;
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
                    if (DrawingDevice is LeapMotion)
                    {
                        (DrawingDevice as LeapMotion).Disconect();
                    }
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

        private void DZEditor_SizeChanged(object sender, EventArgs e)
        {
            if (DrawingDevice is InputDevices.Mouse)
            {
                InputDevices.Mouse mouse = new Mouse(DZEditor);
                DrawingDevice = mouse;
            }
        }

        private void TSBSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void TSMISave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void TSMISaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void Save()
        {
            if (SavePath == null)
            {
                SaveAs();
                return;
            }

            if (IsRecording)
            {
                IsRecording = false;
            }

            var writer = new MouvmlWriter(SavePath);

            foreach (var line in DZEditor.Lines)
            {
                writer.AddPath(line.Path);
            }

            writer.Save();
        }

        private void SaveAs()
        {
            var sfd = new SaveFileDialog()
            {
                DefaultExt = "mouvml"
            };

            var result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                SavePath = sfd.FileName;
                Save();
            }
        }

        

        
    }
}

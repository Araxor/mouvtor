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

namespace MouvtorPlayer
{
    public partial class FrmMouvtorPlayer : Form
    {
        #region Fields
        private bool isPlaying;
        private bool isRecording;
        #endregion

        #region Properties
        private bool IsPlaying { set { ChangePlayState(value); } get { return isPlaying; } }
        private bool IsRecording { set { ChangeRecordState(value); } get { return isRecording; } }
        private List<Path> Drawing { get; set; }
        private DrawingPlayer DrawingPlayer { get; set; }
        #endregion

        public FrmMouvtorPlayer()
        {
            InitializeComponent();
        }

        private void TSMIQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Change the play state and show the good picture on the tools bar
        /// </summary>
        /// <param name="val">Boolean value</param>
        private void ChangePlayState(bool val)
        {
            TSBPlayPause.Image = (val) ? Properties.Resources.control_pause_blue : Properties.Resources.control_play_blue;
            TSBPlayPause.Text = (val) ? "Pause" : "Play";
            TSSLPlayInfo.Text = (val) ? "Playing" : "Not play";

            this.isPlaying = val;

            if (isPlaying)
            {
                PlayDrawing();
            }
        }

        /// <summary>
        /// Change the record state and show the good picture on the tools bar
        /// </summary>
        /// <param name="val">Boolean value</param>
        private void ChangeRecordState(bool val)
        {
            TSBRecordAndStop.Image = (val) ? Properties.Resources.shape_square : Properties.Resources.bullet_red;
            TSBRecordAndStop.Text = (val) ? "Stop record" : "Record";
            TSSLRecordInfo.Text = (val) ? "Recording" : "Not record";

            this.isRecording = val;
        }

        private void FrmMouvtorPlayer_Load(object sender, EventArgs e)
        {
            this.IsPlaying = false;
            this.IsRecording = false;
        }

        private void TSBPlayPause_Click(object sender, EventArgs e)
        {
            this.IsPlaying = !this.IsPlaying;
        }

        private void TSBRecordAndStop_Click(object sender, EventArgs e)
        {
            this.IsRecording = !this.IsRecording;
        }

        private void TSMIPlay_Click(object sender, EventArgs e)
        {
            this.IsPlaying = true;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsPlaying = false;
        }

        private void TSMIRecord_Click(object sender, EventArgs e)
        {
            this.IsRecording = true;
        }

        private void TSMIStopRecord_Click(object sender, EventArgs e)
        {
            this.IsRecording = false;
        }

        private void TSBOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            var result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                var reader = new MouvmlReader(ofd.FileName);
                Drawing = reader.ToList();
            }
        }

        private void PlayDrawing()
        {
            if (Drawing != null)
            {
                DrawingPlayer = new DrawingPlayer(Drawing, dzPlayer);

                DrawingPlayer.DrawingEnded += () =>
                {
                    IsPlaying = false;
                    DrawingPlayer = null;
                };

                DrawingPlayer.Play();
            }
            else
            {
                IsPlaying = false;
            }
        }
    }
}

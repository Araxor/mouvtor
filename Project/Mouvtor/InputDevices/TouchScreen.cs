using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouvtorCommon;
using System.Windows.Forms;
using System.Diagnostics;

namespace InputDevices
{
    public class TouchScreen : IInputDevice
    {

        #region fields
        int X, Y;
        int oldx, oldy;
        int controlWidth, controlHeight;
        System.Timers.Timer tmr;
        Stopwatch watch = new Stopwatch();
        const int WAITITME = 1000;
        #endregion

        #region properties
        public Point3DNormalized CurrentNormalizedPosition
        {
            get;
            set;
        }
        #endregion

        #region events
        public event EventHandler StartDrawing;
        public event EventHandler StopDrawing;
        #endregion

        #region constructor
        public TouchScreen(Control control)
        {
            control.MouseMove += control_MouseMove;
            control.MouseDown += control_MouseDown;
            control.MouseUp += control_MouseUp;
            tmr = new System.Timers.Timer();
            tmr.Elapsed += tmr_Elapsed;
            tmr.Interval = 1;
            tmr.AutoReset = true;
            tmr.Enabled = true;
            controlWidth = control.Bounds.Width;
            controlHeight = control.Bounds.Height;
            this.StartDrawing += OnStartDrawing;
            this.StopDrawing += OnStopDrawing;
        }


        #endregion

        #region methods
        void OnStartDrawing(object sender, EventArgs e) { }
        void OnStopDrawing(object sender, EventArgs e) { }

        void control_MouseUp(object sender, MouseEventArgs e)
        {
            StopDrawing(this, EventArgs.Empty);
        }

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            StartDrawing(this, EventArgs.Empty);
        }

        void control_MouseMove(object sender, MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }
        void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            float normalizedX = this.X / (float)controlWidth;
            float normalizedY = this.Y / (float)controlHeight;
            if (oldx == X && oldy == Y)
            {
                if (watch.IsRunning)
                {
                    if (watch.ElapsedMilliseconds == WAITITME)
                    {
                        StopDrawing(this, EventArgs.Empty);
                        watch.Stop();
                        watch.Reset();
                    }

                }
                else
                {
                    watch.Start();
                }
            }
            else
            {
                if (watch.IsRunning)
                {
                    watch.Stop();
                    watch.Reset();
                }
            }

            oldx = X;
            oldy = Y;
            CurrentNormalizedPosition = new Point3DNormalized(normalizedX, normalizedY, 0);
        }
        #endregion


    }
}

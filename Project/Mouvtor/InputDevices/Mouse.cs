using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouvtorCommon;
using System.Windows.Forms;

namespace InputDevices
{
    public class Mouse : IInputDevice
    {
       
        #region fields
        int X, Y;
        int controlWidth, controlHeight;
        System.Timers.Timer tmr;
        #endregion

        #region properties
        public Point3DNormalized CurrentNormalizedPosition
        {
            get; set;
        }
        #endregion 

        #region events
        public event EventHandler StartDrawing;
        public event EventHandler StopDrawing;
        #endregion

        #region constructor
        public Mouse(Control control)
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

            CurrentNormalizedPosition = new Point3DNormalized(normalizedX,normalizedY,0);
        }
        #endregion


    }
}

using System;
using Leap;
using MouvtorCommon;
using System.Timers;
using System.Windows.Forms;


namespace InputDevices
{
    public class LeapMotion : IInputDevice
    {
        #region fields
        const int FINGER_ID = 1; //0=thumb / 1=index / 2=major / 3=annular / 4=auricular
      
        Controller controller;//leap motion controller        
        System.Timers.Timer tmr;
        #endregion

        #region Events
        public event EventHandler StartDrawing;
        public event EventHandler StopDrawing;
        #endregion

        #region properties
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        
        public Point3DNormalized CurrentNormalizedPosition
        {
            get;
            set;
        }
        public bool IsConnected
        {
            get { return controller.IsConnected; }            
        }
        #endregion

        #region constructor
        public LeapMotion()
        {
            this.StartDrawing += OnStartDrawing;
            this.StopDrawing += OnStopDrawing;
            this.Controller = new Controller();
            tmr = new System.Timers.Timer();
            tmr.AutoReset = true;
            tmr.Interval = 1;
            tmr.Elapsed+= tmr_Tick;
            tmr.Start();
        }

        #endregion

        #region methods

        void OnStartDrawing(object sender, EventArgs e) { }
        void OnStopDrawing(object sender, EventArgs e) { }

        void tmr_Tick(object sender, EventArgs e)
        {
            Frame frame = Controller.Frame();

          

            if (controller == null || !controller.IsConnected)
            {
                StopDrawing(this, EventArgs.Empty);               
            }
            else
            {
                var hands = frame.Hands;
                var hand = hands[0];
                var fingers = hand.Fingers;
                
                if ((fingers[FINGER_ID] != Finger.Invalid) && (fingers[FINGER_ID].IsExtended))
                {
                    var normailizedPos = frame.InteractionBox.NormalizePoint(fingers[FINGER_ID].StabilizedTipPosition, false);
                    CurrentNormalizedPosition = new Point3DNormalized(normailizedPos.x, 1 - normailizedPos.y, 1 - normailizedPos.z);
                   /* try{*/
                    StartDrawing(this, EventArgs.Empty);
                   /* }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }*/
                }
                if (!this.controller.HasFocus)
                {                   
                    try
                    {
                        StopDrawing(this, EventArgs.Empty);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }


        }
        #endregion
    }
}

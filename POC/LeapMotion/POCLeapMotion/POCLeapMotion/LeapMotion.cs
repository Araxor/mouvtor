using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap;
using System.Drawing;
using System.Windows.Forms;

namespace POCLeapMotion
{
    class LeapMotion : InputDevice
    {
        #region fields
        const int FINGER_ID = 1; //0=thumb / 1=index / 2=major / 3=annular / 4=auricular
        //leap motion controller
        Controller controller;
        Frame frame;
        Timer tmr;

        #endregion


        #region properties
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        #endregion
        #region constructor
        public LeapMotion(Rectangle drawingSurfaceSize)
            : base(drawingSurfaceSize)
        {
            this.Controller = new Controller();
            tmr = new Timer();
            tmr.Interval = 1;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            frame = Controller.Frame();

            var hands = frame.Hands;
            var hand = hands[0];
            var fingers = hand.Fingers;

            if (controller == null || !controller.IsConnected)
            {
                OnStopDrawing();
            }
            else
            {
             
                if ((hands[0].IsRight) && (fingers[FINGER_ID] != Finger.Invalid) && (fingers[FINGER_ID].IsExtended))
                {
                    var normailizedPos = frame.InteractionBox.NormalizePoint(fingers[FINGER_ID].StabilizedTipPosition, false);
                    CurrentNormalizedPosition = new PointF(normailizedPos.x,normailizedPos.y);
                    CurrentNormalizedPressure = normailizedPos.z;
                }
                if (this.controller.HasFocus)
                {
                    OnStartDrawing();
                }
                else
                {
                    OnStopDrawing();
                }
            }


        }
        #endregion

        #region methods

        #endregion

    }
}

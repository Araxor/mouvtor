﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap;
using System.Drawing;
using System.Windows.Forms;
using MouvtorCommon;

namespace POCLeapMotion
{
    class LeapMotion : IInputDevice
    {
        #region fields
        const int FINGER_ID = 1; //0=thumb / 1=index / 2=major / 3=annular / 4=auricular
        Controller controller;//leap motion controller        
        Timer tmr;
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
        #endregion

        #region constructor
        public LeapMotion()
        {
            this.Controller = new Controller();
            tmr = new Timer();
            tmr.Interval = 1;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
        #endregion

        #region methods
        void tmr_Tick(object sender, EventArgs e)
        {
            Frame frame = Controller.Frame();

            var hands = frame.Hands;
            var hand = hands[0];
            var fingers = hand.Fingers;

            if (controller == null || !controller.IsConnected)
            {
                StopDrawing(this, EventArgs.Empty);
            }
            else
            {

                if ((hands[0].IsRight) && (fingers[FINGER_ID] != Finger.Invalid) && (fingers[FINGER_ID].IsExtended))
                {
                    var normailizedPos = frame.InteractionBox.NormalizePoint(fingers[FINGER_ID].StabilizedTipPosition, false);
                    CurrentNormalizedPosition = new Point3DNormalized(normailizedPos.x, 1 - normailizedPos.y, 1 - normailizedPos.z);

                    StartDrawing(this, EventArgs.Empty);
                }
                if (!this.controller.HasFocus)
                {
                    StopDrawing(this, EventArgs.Empty);
                }
            }


        }
        #endregion



    }
}

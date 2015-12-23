using MouvtorCommon;
using NovintFalcon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace InputDevices
{
    public class NovintFalcon : IInputDevice
    {
        #region Constants
        const int DEFAULT_UPDATE_INTERVAL = 1;
        //const double
        #endregion

        #region Properties
        public Point3DNormalized CurrentNormalizedPosition { get; protected set; }
        protected Timer UpdateTimer { get; set; }
        #endregion

        #region Events
        public event EventHandler StartDrawing;
        public event EventHandler StopDrawing;
        #endregion

        public NovintFalcon() 
        {
            FalconWrapper.StartHaptics();

            UpdateTimer = new Timer();
            UpdateTimer.Interval = DEFAULT_UPDATE_INTERVAL;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Start();
        }

        ~NovintFalcon()
        {
            FalconWrapper.StopHaptics();
        }

        void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (FalconWrapper.IsDeviceCalibrated())
            {
                if (FalconWrapper.IsDeviceReady())
                {
                    CurrentNormalizedPosition = new Point3DNormalized(
                        FalconWrapper.GetXPos()/4.0,
                        FalconWrapper.GetYPos()/4.0,
                        FalconWrapper.GetZPos()/4.0
                    );
                }
                else
                {
                    Debug.WriteLine("Falcon wrapper not ready.");  
                }
                
            }
            else
            {
                Debug.WriteLine("Falcon wrapper not calibrated.");
            }
 
        }
    }
}

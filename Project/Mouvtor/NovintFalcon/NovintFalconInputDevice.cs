using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace NovintFalcon
{
    public class NovintFalconInputDevice : InputDevice
    {
        #region Constants
        const int DEFAULT_UPDATE_INTERVAL = 1;
        #endregion


        #region Properties
        Timer UpdateTimer { get; set; }
        #endregion

        public NovintFalconInputDevice(Rectangle drawingSurfaceSize) 
            : base(drawingSurfaceSize)
        {
            UpdateTimer = new Timer();
            UpdateTimer.Interval = DEFAULT_UPDATE_INTERVAL;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Start();
        }

        void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentNormalizedPosition = new PointF(
                (float)FalconWrapper.GetXPos(), 
                (float)FalconWrapper.GetYPos()
            );
            CurrentNormalizedPressure = (float)FalconWrapper.GetZPos();
        }
    }
}

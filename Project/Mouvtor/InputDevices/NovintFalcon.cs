using MouvtorCommon;
using SharpFalcon.HDL;
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
        const double MIN_X = -0.08;
        const double MIN_Y = 0.08;
        const double MIN_Z = -0.08;

        const double MAX_X = 0.08;
        const double MAX_Y = -0.08;
        const double MAX_Z = 0.08;
        #endregion

        #region Properties
        public Point3DNormalized CurrentNormalizedPosition { get; protected set; }
        protected Timer UpdateTimer { get; set; }
        protected bool WasDrawing { get; set; }
        protected DeviceManager Manager {get; set;}
        protected HapticDevice Device { get; set; }
        protected DeviceLoopOperation LoopOperation { get; set; }
        #endregion

        #region Events
        public event EventHandler StartDrawing;
        public event EventHandler StopDrawing;
        #endregion

        public NovintFalcon() 
        {

            Manager = DeviceManager.Instance;
            Manager.Start();

            if (Manager.Count == 0)
            {
                throw new Exception("Cannot connect to Novint Falcon.");
            }

            Device = Manager[0];
            LoopOperation = Device.RegisterDeviceLoopOperation(DeviceOperation, false);

            UpdateTimer = new Timer();
            UpdateTimer.Interval = DEFAULT_UPDATE_INTERVAL;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Start();
        }

        ~NovintFalcon()
        {
            //Manager.Dispose();
        }

        void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Vector3d pos = Device.Position;

            CurrentNormalizedPosition = new Point3DNormalized(
                (pos.X - MIN_X) / (MAX_X - MIN_X),
                (pos.Y - MIN_Y) / (MAX_Y - MIN_Y),
                (pos.Z - MIN_Z) / (MAX_Z - MIN_Z)
            );

            Debug.WriteLine("X {0}  Y {1}   Z  {2}", pos.X, pos.Y, pos.Z);
            

            var buttonIsPressed = Device.IsButtonPressed;

            if (!WasDrawing && buttonIsPressed)
            {
                StartDrawing(this, EventArgs.Empty);
            }
            if (WasDrawing && !buttonIsPressed)
            {
                StopDrawing(this, EventArgs.Empty);
            }

            WasDrawing = buttonIsPressed;
        }

        private bool DeviceOperation(HapticDevice device)
        {
            device.Force.Update();
            return true;
        }
    }
}

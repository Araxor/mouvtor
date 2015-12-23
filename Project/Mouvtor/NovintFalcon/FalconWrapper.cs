using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NovintFalcon
{
    public static class FalconWrapper
    {
        const string falcon = "Falcon Wrapper";

        [DllImport(falcon)]
        public static extern void StartHaptics();
        [DllImport(falcon)]
        public static extern void StopHaptics();
        [DllImport(falcon)]
        public static extern bool IsDeviceCalibrated();
        [DllImport(falcon)]
        public static extern bool IsDeviceReady();
        [DllImport(falcon)]
        public static extern double GetXPos();
        [DllImport(falcon)]
        public static extern double GetYPos();
        [DllImport(falcon)]
        public static extern double GetZPos();
        [DllImport(falcon)]
        public static extern void SetServo(double[] speed);
        [DllImport(falcon)]
        public static extern void SetServoPos(double[] pos, double strength);
        [DllImport(falcon)]
        public static extern bool IsHapticButtonDepressed();
    }
}

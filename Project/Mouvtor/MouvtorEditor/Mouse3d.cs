using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorEditor
{

    public class Mouse3d
    {
        [DllImport("3dmouse.dll", CallingConvention = CallingConvention.StdCall)]
        static public extern IntPtr CreateHapticsClass();

        [DllImport("3dmouse.dll", CallingConvention = CallingConvention.StdCall)]
        static public extern void DisposeHapticsClass(IntPtr obj);

        [DllImport("3dmouse.dll", CallingConvention = CallingConvention.StdCall)]
        static public extern void CallHapticsClassInit(IntPtr obj, double a_cubeSize, double a_stiffness);

        [DllImport("3dmouse.dll", CallingConvention = CallingConvention.StdCall)]
        static public extern IntPtr CallHapticsClassGetPosition(IntPtr obj);
        
    }
}

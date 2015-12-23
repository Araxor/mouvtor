using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    public interface IInputDevice
    {
        #region Properties
        Point3DNormalized CurrentNormalizedPosition { get; }
        #endregion

        #region Events
        event EventHandler StartDrawing;
        event EventHandler StopDrawing;
        #endregion
    }
}

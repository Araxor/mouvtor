using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    public class InputDevice
    {
        #region Properties
        public PointF CurrentNormalizedPosition { get; internal set; }
        public float CurrentNormalizedPressure { get; internal set; }

        public Rectangle DrawingZoneSize { get; internal set; }
        public int DrawingZoneDepth { get; internal set; }

        public Point CurrentAbsolutePosition
        {
            get
            {
                return new Point(
                    x: (int)(CurrentNormalizedPosition.X * DrawingZoneSize.X),
                    y: (int)(CurrentNormalizedPosition.Y * DrawingZoneSize.Y)
                );
            }
        }
        public int CurrentAbsolutePressure
        {
            get
            {
                return (int)(CurrentNormalizedPressure * DrawingZoneDepth);
            }
        }
        #endregion

        #region Events
        public event EventHandler onStartDrawing;
        public event EventHandler onStopDrawing;
        #endregion

        #region Constructors
        public InputDevice(Rectangle drawingSurfaceSize)
        {
            DrawingZoneSize = drawingSurfaceSize;
            CurrentNormalizedPosition = new PointF(0, 0);
        }
        #endregion
    }
}

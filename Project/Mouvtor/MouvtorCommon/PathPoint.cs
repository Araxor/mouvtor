using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    class PathPoint
    {
        public PointF NormalizedPosition { get; internal set; }
        public float Pressure { get; internal set; }
        public long Timestamp { get; internal set; }

        public PathPoint(PointF normalizedPosition, float presssure, long timestamp)
        {
            NormalizedPosition = normalizedPosition;
            Pressure = presssure;
            Timestamp = timestamp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    public class PathStep
    {
        public Point3DNormalized NormalizedPosition { get; protected set; }
        public long Timestamp { get; internal set; }

        public PathStep(Point3DNormalized fromPoint, long timestamp) {
            NormalizedPosition = fromPoint;
            Timestamp = timestamp;
        }

        public PathStep(double x, double y, double z, long timestamp)
            : this(new Point3DNormalized(), timestamp)
        { }
    }
}

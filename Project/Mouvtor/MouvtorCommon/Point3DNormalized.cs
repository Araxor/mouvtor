using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    [Serializable]
    public struct Point3DNormalized
    {
        private double _x;
        private double _y;
        private double _z;

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public
            Point3DNormalized(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public PointF ToPointF()
        {
            return new PointF((float)this.X, (float)this.Y);
        }

    }
}

using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouvtorCommon
{
    public class Line
    {
        #region Fields
        private List<Point3DNormalized> _pointAverage;
        private Size _size;
        private Pen _penDrawing;
        #endregion

        #region Const
        private const int DEPTH = 5;
        #endregion

        #region Properties
        public List<Point3DNormalized> PointAverage
        {
            get { return _pointAverage; }
            set { _pointAverage = value; }
        }

        /// <summary>
        /// Get or set the pen
        /// </summary>
        public Pen PenDrawing
        {
            get { return _penDrawing; }
            set { _penDrawing = value; }
        }

        /// <summary>
        /// Get or set the reference size for the unnormalized point
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Get or set the list of normalized point
        /// </summary>        
        //[System.ComponentModel.Browsable(false)]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        //public List<Point3DNormalized> Points
        //{
        //    get { return _pointNormalized; }
        //    private set { _pointNormalized = value; }
        //}

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Path Path
        {
            get;
            private set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a line with the size for the normalization
        /// </summary>
        /// <param name="width">Width size</param>
        /// <param name="height">Height size</param>
        public Line(int width, int height, long timestamp)
            : this(new Size(width, height), new Pen(Color.Blue, DEPTH), timestamp)
        {

        }

        /// <summary>
        /// Create a line with the size for the normalization
        /// </summary>
        /// <param name="s">Size</param>
        public Line(Size s, long timestamp)
            : this(s, new Pen(Color.Blue, DEPTH), timestamp)
        {

        }

        /// <summary>
        /// Create a line with a size and a pen
        /// </summary>
        /// <param name="s">Size</param>
        /// <param name="p">Pen</param>
        public Line(Size s, Pen p, long timestamp)
        {
            this.Size = s;
            this.Path = new Path(timestamp);
            this.PointAverage = new List<Point3DNormalized>();

            this.PenDrawing = p;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="p3n">The new point 3D normalized</param>
        public void AddNormalizedPoint(Point3DNormalized p3n, long timestamp)
        {
            this.Path.Add(new PathStep(p3n, timestamp - Path.Timestamp));
            //CleanPointList();
        }

        /// <summary>
        /// Normalize a point
        /// </summary>
        private Point UnnormalizePoint(Point3DNormalized p3n)
        {
            return new Point((int)(p3n.X * this.Size.Width), (int)(p3n.Y * this.Size.Height));
        }

        /// <summary>
        /// Modify the window size
        /// </summary>
        /// <param name="s"></param>
        public void ChangeSize(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Draw all point
        /// </summary>
        /// <param name="pe"></param>
        public void Draw(PaintEventArgs pe)
        {
            for (int i = 0; i < this.Path.Count - 1; ++i)
            {
                this.PenDrawing.Width = (float)(this.Path[i].NormalizedPosition.Z * DEPTH + DEPTH);
                pe.Graphics.DrawLine(
                    this.PenDrawing, 
                    UnnormalizePoint(this.Path[i].NormalizedPosition), 
                    UnnormalizePoint(this.Path[i + 1].NormalizedPosition)
                );
            }

            /*for (int i = 0; i < this.PointAverage.Count - 1; ++i)
            {
                this.PenDrawing.Width = (float)(this.PointAverage[i].Z * DEPTH + DEPTH);
                pe.Graphics.DrawLine(this.PenDrawing, UnnormalizePoint(this.PointAverage[i]), UnnormalizePoint(this.PointAverage[i + 1]));
            }*/
        }
        /*
        private void CleanPointList()
        {
            List<Point3DNormalized> tmpPoints = this.PointNormalized;
            double xAverage = 0.0d;
            double yAverage = 0.0d;
            double zAverage = 0.0d;

            for (int i = 0; i < 10; ++i)
            {
                xAverage += tmpPoints[i].X;
                yAverage += tmpPoints[i].Y;
                zAverage += tmpPoints[i].Z;
            }

            this.PointAverage.Add(new Point3DNormalized(xAverage / 10, yAverage / 10, zAverage / 10));



            //this.PointAverage = tmpPoints;
            /*if (this.PointNormalized.Count == 60)
            {
                List<Point3DNormalized> tmpPoints = this.PointNormalized;
                //this.PointAverage.Add(tmpPoints[0]);

                for (int i = 0; i < tmpPoints.Count; ++i)
                {
                    this.PointAverage.Add(tmpPoints[i]);
                }
                //this.PointNormalized.Clear();
            }


        }*/
        #endregion
    }
}

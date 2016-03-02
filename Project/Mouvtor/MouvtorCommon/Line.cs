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
        private Size _size;
        private Pen _penDrawing;
        #endregion

        #region Const
        private const int DEPTH = 5;
        #endregion

        #region Properties
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

            this.PenDrawing = p;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="p3n">The new point 3D normalized</param>
        public void AddNormalizedPoint(Point3DNormalized p3n, long timestamp, TypeDrawZone t)
        {
            this.Path.Add(new PathStep(p3n, timestamp - Path.Timestamp));
            
            if (this.Path.Count % 10 == 0 && t != TypeDrawZone.Player)
                this.Path.DeleteUselessPoint();
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
        }
        #endregion
    }
}

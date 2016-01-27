using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouvtorEditor
{
    class Line
    {
        #region Fields
        private List<Point3DNormalized> _pointNormalized;
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
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        private List<Point3DNormalized> PointNormalized
        {
            get { return _pointNormalized; }
            set { _pointNormalized = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a line with the size for the normalization
        /// </summary>
        /// <param name="width">Width size</param>
        /// <param name="height">Height size</param>
        public Line(int width, int height)
            : this(new Size(width, height), new Pen(Color.Blue, DEPTH))
        {

        }

        /// <summary>
        /// Create a line with the size for the normalization
        /// </summary>
        /// <param name="s">Size</param>
        public Line(Size s)
            : this(s, new Pen(Color.Blue, DEPTH))
        {

        }

        /// <summary>
        /// Create a line with a size and a pen
        /// </summary>
        /// <param name="s">Size</param>
        /// <param name="p">Pen</param>
        public Line(Size s, Pen p)
        {
            this.Size = s;
            this.PointNormalized = new List<Point3DNormalized>();

            this.PenDrawing = p;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="p3n">The new point 3D normalized</param>
        public void AddNormalizedPoint(Point3DNormalized p3n)
        {
            this.PointNormalized.Add(p3n);
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
            for (int i = 0; i < this.PointNormalized.Count - 1; ++i)
            {
                this.PenDrawing.Width = (float)(this.PointNormalized[i].Z * DEPTH + DEPTH);
                pe.Graphics.DrawLine(this.PenDrawing, UnnormalizePoint(this.PointNormalized[i]), UnnormalizePoint(this.PointNormalized[i + 1]));
            }
        }
        #endregion
    }
}

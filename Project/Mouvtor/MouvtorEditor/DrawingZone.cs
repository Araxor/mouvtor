using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouvtorEditor
{
    class DrawingZone : Panel
    {
        #region Fields
        private Pen _penDrawing;
        private float _penWidth;
        private Color _penColor;
        private List<Point> _pointDrawingList;
        private List<Point3DNormalized> _pointNormalized;
        #endregion

        #region Const
        private const int MIN_POINTS = 2;
        private const int DEFAULT_PEN_WIDTH = 12;
        private const Color DEFAULT_PEN_COLOR = Color.Blue;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the pen propeties
        /// </summary>
        public Pen PenDrawing
        {
            get { return _penDrawing; }
            set { _penDrawing = value; }
        }

        /// <summary>
        /// Get or set the pen width
        /// </summary>
        public float PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }

        /// <summary>
        /// Get or set the pen color
        /// </summary>
        public Color PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }

        /// <summary>
        /// Get or set the list of point which must be draw
        /// </summary>
        public List<Point> PointDrawingList
        {
            get { return _pointDrawingList; }
            set { _pointDrawingList = value; }
        }

        /// <summary>
        /// Get or set the list of normalized point
        /// </summary>
        public List<Point3DNormalized> PointNormalized
        {
            get { return _pointNormalized; }
            set { _pointNormalized = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create and initialize a new DrawingZone
        /// </summary>
        public DrawingZone() : this(DEFAULT_PEN_COLOR, DEFAULT_PEN_WIDTH)
        {

        }

        /// <summary>
        /// Create and initialize a new DrawingZone with color
        /// </summary>
        /// <param name="color"></param>
        public DrawingZone(Color color) : this(color, DEFAULT_PEN_WIDTH)
        {
        }

        /// <summary>
        /// Create and initialize a new DrawingZone with color and width
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        public DrawingZone(Color color, float width)
        {
            this.InitProperties(color, width);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize all properties with a color and a width which defined in parameters
        /// </summary>
        /// <param name="color">Pen color</param>
        /// <param name="width">Pen width</param>
        public void InitProperties(Color color, float width)
        {
            // Pen initialize
            this.PenColor = color;
            this.PenWidth = width;
            this.PenDrawing = new Pen(this.PenColor, this.PenWidth);

            //List initialize
            this.PointDrawingList = new List<Point>();
            this.PointNormalized = new List<Point3DNormalized>();
        }

        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="normalizedPoint">Point3DNormalized</param>
        public void AddPointDrawing(Point3DNormalized normalizedPoint)
        {
            this.PointNormalized.Add(normalizedPoint); // Save the normalized point
            this.PointDrawingList.Add(new Point((int)(normalizedPoint.X * this.Width), (int)(normalizedPoint.Y * this.Height))); // Add the point which prepare for the draw
        }

        /// <summary>
        /// Draw all points
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.PointDrawingList.Count >= MIN_POINTS)
                e.Graphics.DrawLines(this.PenDrawing, this.PointDrawingList.ToArray());
        }
        #endregion
    }
}

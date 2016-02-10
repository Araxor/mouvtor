using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MouvtorCommon
{
    public class DrawingZone : Panel
    {
        #region Fields
        private bool _isDrawing;
        private List<Line> _lines;
        private Line _currentLine;
        private Stopwatch _stopWatch;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the current line which is drawing
        /// </summary>
        private Line CurrentLine
        {
            get { return _currentLine; }
            set { _currentLine = value; }
        }

        /// <summary>
        /// Get or set the lines list
        /// </summary>
        public List<Line> Lines
        {
            get { return _lines; }
            private set { _lines = value; }
        }

        /// <summary>
        /// Get or set if the line is drawing
        /// </summary>
        public bool IsDrawing
        {
            get { return _isDrawing; }
            set { _isDrawing = value; }
        }

        private Stopwatch Stopwatch
        {
            get 
            {
                if (_stopWatch == null)
                {
                    _stopWatch = new Stopwatch();
                    _stopWatch.Start();
                }
                return _stopWatch; 
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create and initialize a new DrawingZone with color and width
        /// </summary>
        public DrawingZone()
        {
            this.DoubleBuffered = true;
            this.Lines = new List<Line>();
            this.Resize += OnSizeChanged;
        }
        #endregion

        #region Methods
        /// <summary>
        /// When the size is changed. Each lines is adapted for the new window size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (this.Lines.Count >= 1)
            {
                foreach (Line l in this.Lines)
                    l.ChangeSize(this.Size);
            }
        }

        /// <summary>
        /// Start the new draw
        /// </summary>
        public void StartDrawing()
        {
            this.IsDrawing = true;

            this.CurrentLine = new Line(this.Size, Stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Stop the draw
        /// </summary>
        public void StopDrawing()
        {
            this.IsDrawing = false;
            this.Lines.Add(this.CurrentLine);
            this.CurrentLine = null;
        }

        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="normalizedPoint">Point3DNormalized</param>
        public void AddPointDrawing(Point3DNormalized normalizedPoint)
        {
            this.CurrentLine.AddNormalizedPoint(normalizedPoint, Stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Draw all points
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (Line l in this.Lines)
                l.Draw(e);

            if (this.IsDrawing)
                this.CurrentLine.Draw(e);
        }
        #endregion
    }
}

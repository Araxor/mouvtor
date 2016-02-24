using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace MouvtorCommon
{
    public class DrawingZone : Panel
    {
        #region Fields
        private Stopwatch _stopWatch;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the current line which is drawing
        /// </summary>
        private Line CurrentLine { get; set; }

        /// <summary>
        /// Get or set the lines list
        /// </summary>
        public List<Line> Lines { get; private set; }

        /// <summary>
        /// Get or set if the line is drawing
        /// </summary>
        public bool IsDrawing { get; set; }

        /// <summary>
        /// Get the stopwatch that calculates the points timestamp
        /// </summary>
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
            set
            {
                _stopWatch = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create and initialize a new DrawingZone with color and width
        /// </summary>
        public DrawingZone()
        {
            DoubleBuffered = true;
            Lines = new List<Line>();
            Resize += OnSizeChanged;
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
            if (Lines.Count >= 1)
            {
                foreach (Line l in Lines)
                    l.ChangeSize(Size);
            }
        }

        /// <summary>
        /// Start the new draw
        /// </summary>
        public void StartDrawing()
        {
            IsDrawing = true;
            CurrentLine = new Line(Size, Stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Stop the draw
        /// </summary>
        public void StopDrawing()
        {
            IsDrawing = false;
            Lines.Add(CurrentLine);
            CurrentLine = null;
        }

        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="normalizedPoint">Point3DNormalized</param>
        public void AddPointDrawing(Point3DNormalized normalizedPoint)
        {
            CurrentLine.AddNormalizedPoint(normalizedPoint, Stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Resets the drawing zone to its initial state
        /// </summary>
        public void Clear()
        {
            StopDrawing();
            Lines = new List<Line>();
            Stopwatch = null;
        }

        /// <summary>
        /// Draw all points
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (Line l in Lines)
                l.Draw(e);

            if (IsDrawing)
                CurrentLine.Draw(e);
        }
        #endregion
    }
}

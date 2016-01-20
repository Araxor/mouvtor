﻿using MouvtorCommon;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MouvtorEditor
{
    class DrawingZone : Panel
    {
        #region Fields
        private bool _isDrawing;
        private List<Line> _lines;
        private Line _currentLine;
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
        private List<Line> Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }

        /// <summary>
        /// Get or set if the line is drawing
        /// </summary>
        public bool IsDrawing
        {
            get { return _isDrawing; }
            set { _isDrawing = value; }
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
        }
        #endregion

        #region Methods
        /// <summary>
        /// Start the new draw
        /// </summary>
        public void StartDrawing()
        {
            this.IsDrawing = true;
            this.CurrentLine = new Line(this.Size);
        }

        /// <summary>
        /// Stop the draw
        /// </summary>
        public void StopDrawing()
        {
            this.IsDrawing = false;
            this.Lines.Add(this.CurrentLine);
        }

        /// <summary>
        /// Add a normalized point
        /// </summary>
        /// <param name="normalizedPoint">Point3DNormalized</param>
        public void AddPointDrawing(Point3DNormalized normalizedPoint)
        {
            this.CurrentLine.AddNormalizedPoint(normalizedPoint);
        }

        /// <summary>
        /// Draw all points
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Lines.Count >= 1)
            {
                foreach (Line l in this.Lines)
                    l.Draw(e);
            }
            

            if (this.IsDrawing)
                this.CurrentLine.Draw(e);
        }
        #endregion
    }
}

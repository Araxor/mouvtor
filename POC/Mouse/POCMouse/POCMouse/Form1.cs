using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCMouse
{
    public partial class Form1 : Form
    {
        #region fields
        PointF oldpos;
        Graphics graphique;
        Mouse mymouse;
        bool canDraw = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
            mymouse = new Mouse(this);
            graphique = this.CreateGraphics();
            mymouse.StartDrawing += mymouse_StartDrawing;
            mymouse.StopDrawing += mymouse_StopDrawing;

        }

        void mymouse_StopDrawing(object sender, EventArgs e)
        {
            canDraw = false;
        }

        void mymouse_StartDrawing(object sender, EventArgs e)
        {
            canDraw = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
          // draw = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
         //   draw = false;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            var pen = new Pen(Color.Red);
            PointF newpos =mymouse.CurrentNormalizedPosition.ToPointF();
            newpos.X = newpos.X * this.Bounds.Height;
            newpos.Y = newpos.Y * this.Bounds.Width;

            label1.Text = "X : " + newpos.X;
            label2.Text = "Y : " + newpos.Y;
            label3.Text = "FALSE";
            
            if (canDraw) {
                label3.Text = "TRUE";
                graphique.DrawLine(pen, oldpos,newpos);
            }
            oldpos = newpos;
        }
    }
}

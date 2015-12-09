using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;


namespace POCLeapMotion
{
    public partial class Form1 : Form
    {
        Controller controller;
        bool first = true;
        bool Start = false;
        Point OldPos;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (Start)
            {
                tmr.Enabled = false;
                Start = false;
                BtnStartStop.Text = "Start";

            }
            else
            {
                try
                {
                    controller = new Controller();
                    Start = true;
                    BtnStartStop.Text = "Stop";
                    tmr.Enabled = true;
                    first = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (controller == null || !controller.IsConnected) return;
            MoveButton(BtnStartStop, controller.Frame());

        }

        private void MoveButton(Button btn, Frame frame)
        {

            var fingers = frame.Fingers;
            var graphics = this.CreateGraphics();
            var pen = new Pen(Color.Red);

            //graphics.Clear(this.BackColor);

         /*   foreach (var finger in fingers)
            {*/

                var normailizedPos = frame.InteractionBox.NormalizePoint(fingers[2].StabilizedTipPosition, false);

                var rect = new RectangleF(
                    normailizedPos.x * this.Width,
                    (1 - normailizedPos.y) * this.Height,
                    // normailizedPos.z * 10, normailizedPos.z * 10
                   10, 10

                    );
               // graphics.DrawEllipse(pen, rect);
                if (first)
                {
                   OldPos = new System.Drawing.Point( (int)(normailizedPos.x * this.Width),
                    (int)((1 - normailizedPos.y)  * this.Height));
                    first = false;                                        
                }
                else
                {
                    Point newPos = new System.Drawing.Point((int)(normailizedPos.x * this.Width),
                    (int)((1 - normailizedPos.y) * this.Height));
                    graphics.DrawLine(pen, OldPos, newPos);
                    OldPos = newPos;
                }
           /* }*/


        }
    }
}

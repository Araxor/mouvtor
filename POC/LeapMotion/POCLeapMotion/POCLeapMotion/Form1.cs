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
        /* const int FINGER_ID = 1; //0=thumb / 1=index / 2=major / 3=annular / 4=auricular
         //leap motion controller
         Controller controller;*/
        LeapMotion monleap;
        bool first = true;
        bool Start = false;
        bool canDraw = false;
        Graphics graphics;
        PointF OldPos;

        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }


        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

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
                    first = true;
                    /*controller = new Controller();*/
                    monleap = new LeapMotion();
                    monleap.StartDrawing += monleap_StartDrawing;
                    monleap.StopDrawing += monleap_StopDrawing;
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

        void monleap_StopDrawing(object sender, EventArgs e)
        {
            canDraw = false;
        }

        void monleap_StartDrawing(object sender, EventArgs e)
        {
            canDraw = true;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            /*if (controller == null || !controller.IsConnected) return;
            Draw(BtnStartStop, controller.Frame());*/
            Draw();

        }

        private void Draw(/*Button btn, Frame frame*/)
        {
            var pen = new Pen(Color.Red);

            if (canDraw)
            {
                label1.Text = "X : " + monleap.CurrentNormalizedPosition.X.ToString();
                label2.Text = "Y : " + monleap.CurrentNormalizedPosition.Y.ToString();
                label3.Text = "Z : " + monleap.CurrentNormalizedPosition.Z.ToString();

                if (first)
                {
                    OldPos = monleap.CurrentNormalizedPosition.ToPointF();
                    OldPos.X = OldPos.X * this.Height;
                    OldPos.Y = OldPos.Y * this.Width;
                    first = false;
                }
                else
                {
                    PointF newPos = monleap.CurrentNormalizedPosition.ToPointF();
                    newPos.X = newPos.X * this.Height;
                    newPos.Y = newPos.Y * this.Width;
                    pen.Width = (float)monleap.CurrentNormalizedPosition.Z * 10;
                    graphics.DrawLine(pen, OldPos, newPos);
                    OldPos = newPos;
                }

            }

            /*var hands = frame.Hands;
            var hand = hands[0];
            var fingers = hand.Fingers;
             
             if ((hands[0].IsRight) && (fingers[FINGER_ID] != Finger.Invalid) && (fingers[FINGER_ID].IsExtended))
            {
                var normailizedPos = frame.InteractionBox.NormalizePoint(fingers[FINGER_ID].StabilizedTipPosition, false);


               var rect = new RectangleF(
                    normailizedPos.x * this.Width,
                    (1 - normailizedPos.y) * this.Height,
                   10, 10
                
                    );
                //Define the presure
                pen.Width = (1 - normailizedPos.z) * 10;

                if (first)
                {
                    OldPos = new System.Drawing.Point((int)(normailizedPos.x * this.Width),
                     (int)((1 - normailizedPos.y) * this.Height));
                    first = false;
                }
                else
                {
                    Point newPos = new System.Drawing.Point((int)(normailizedPos.x * this.Width),
                    (int)((1 - normailizedPos.y) * this.Height));
                    graphics.DrawLine(pen, OldPos, newPos);
                    OldPos = newPos;
                }
            }*/



        }
    }
}

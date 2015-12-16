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
        const int FINGER_ID = 1; //0=thumb / 1=index / 2=major / 3=annular / 4=auricular
        //leap motion controller
        Controller controller;
        bool first = true;
        bool Start = false;
        Graphics graphics;
        Point OldPos;

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
            Draw(BtnStartStop, controller.Frame());

        }

        private void Draw(Button btn, Frame frame)
        {

            var hands = frame.Hands;
            var hand = hands[0];
            var fingers = hand.Fingers;
            var pen = new Pen(Color.Red);

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
            }
        }
    }
}

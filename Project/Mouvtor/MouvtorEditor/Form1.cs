using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouvtorEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr mouse = Mouse3d.CreateHapticsClass();
            Mouse3d.CallHapticsClassInit(mouse, 10d, 10d);
            
            double x;
            double y;
            double z;

            unsafe
            {
                double *pos = (double*)Mouse3d.CallHapticsClassGetPosition(mouse);

                x = pos[0];
                y = pos[1];
                z = pos[2];
            }

            MessageBox.Show(string.Format("X: {0} Y: {1} Z: {2}", x, y, z), "Current position");
        }
    }
}

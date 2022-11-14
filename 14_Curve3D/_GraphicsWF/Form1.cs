using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _GraphicsDLL;

namespace _GraphicsWF
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color c1 = Color.Blue;
        Color c2 = Color.Red;
        Vector4 center;
        Vector4 v = new Vector4(1.2, 0.7, -3.2);
        PointF origin;
        bool mouseLeft = false;
        bool mouseRight = false;

        Matrix4 rotX = Matrix4.RotX(0.0);
        Matrix4 rotY = Matrix4.RotY(0.0);
        Matrix4 rotZ = Matrix4.RotZ(0.0);

        public Form1()
        {
            InitializeComponent();
            center = new Vector4(canvas.Width / 2, canvas.Height / 2, 0.0);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            
            Matrix4 proj = Matrix4.Parallel(v);

            double r = 40;
            double m = 20;

            double r1 = c1.R;
            double r2 = c2.R;
            double g1 = c1.G;
            double g2 = c2.G;
            double b1 = c1.B;
            double b2 = c2.B;

            double incR = (r2 - r1) / 500;
            double incG = (g2 - g1) / 500;
            double incB = (b2 - b1) / 500;
            double cR = c1.R;
            double cG = c1.G;
            double cB = c1.B;

            double k = 2.0;
            double a = -k * 2 *Math.PI;
            double b = k * 2 * Math.PI;
            double t = a;
            double h = (b - a) / 500.0;
            Vector4 v0 = new Vector4(r * Math.Cos(t),
                                     r * Math.Sin(t),
                                     m * t / (2 * Math.PI));
            while (t < b)
            {
                t += h;
                Pen pen = new Pen(Color.FromArgb((int)cR, (int)cG, (int)cB), 2f);
                Vector4 v1 = new Vector4(r * Math.Cos(t),
                                     r * Math.Sin(t),
                                     m * t / (2 * Math.PI));
                Vector4 pv0 = proj * (rotX * rotY * rotZ * v0) + center;
                Vector4 pv1 = proj * (rotX * rotY * rotZ * v1) + center;
                g.DrawLine(pen, (float)pv0.x, (float)pv0.y, (float)pv1.x, (float)pv1.y);
                v0 = v1;
                cR += incR;
                cB += incB;
                cG += incG;
            }
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    origin = e.Location;
                    mouseLeft = true;
                    break;
                case MouseButtons.Right:
                    origin = e.Location;
                    mouseRight = true;
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    mouseLeft = false;
                    rotX = Matrix4.RotX(0);
                    rotY = Matrix4.RotY(0);
                    v = new Vector4(1.2, 0.7, -3.2);

                    canvas.Invalidate();
                    break;
                case MouseButtons.Right:
                    mouseRight = false;

                    rotZ = Matrix4.RotZ(0.0);
                    v = new Vector4(1.2, 0.7, -3.2);

                    canvas.Invalidate();
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseLeft && checkBox1.Checked)
            {
                
                rotX = Matrix4.RotX((origin.X - (double)e.X) / 180);
                rotY = Matrix4.RotY((origin.Y - (double)e.Y) / 180);

                canvas.Invalidate();
            }
            if(mouseRight && checkBox1.Checked)
            {
                rotZ = Matrix4.RotZ((origin.X - (double)e.X) / 180);
                canvas.Invalidate();
            }

            if (mouseLeft && !checkBox1.Checked)
            {
                v = new Vector4((origin.X - (double)e.X) / 10, v.y, v.z);

                v = new Vector4(v.x, (origin.Y - (double)e.Y) / 10, v.z);
                canvas.Invalidate();
            }
            if (mouseRight && !checkBox1.Checked)
            {
                v = new Vector4(v.x, v.y, (origin.X - (double)e.X)/180);
                canvas.Invalidate();
            }
        }
    }
}

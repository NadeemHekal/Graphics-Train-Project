using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Train_Project
{
    public class DDA
    {
        public float Xst, Yst;
        public float Xend, Yend;
        float dy, dx, m;
        public float cx, cy;
        int speed = 10;
        public bool travel;
        public void calc()
        {
            dy = Yend - this.Yst;
            dx = Xend - Xst;
            m = dy / dx;
            cx = Xst;
            cy = Yst;
            travel = true;
        }
        public void CalcNextPoint()
        {
            if (travel)
            {
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (Xst < Xend)
                    {
                        cx += speed;
                        cy += m * speed;
                        if (cx >= Xend)
                        {
                            travel = false;
                        }

                    }
                    else
                    {
                        cx -= speed;
                        cy -= m * speed;
                        if (cx <= Xend)
                        {
                            travel = false;
                        }
                    }
                }
                else
                {
                    if (Yst < Yend)
                    {
                        cy += speed;
                        cx += 1 / m * speed;
                        if (cy >= Yend)
                        {
                            travel = false;
                        }
                    }
                    else
                    {
                        cy -= speed;
                        cx -= 1 / m * speed;
                        if (cy <= Yend)
                        {
                            travel = false;
                        }
                    }

                }
            }
        }

    }
    public class Circle
    {
        public int Rad;
        public int XC;
        public int YC;
        public float thRadian, st, end;
        public void Drawcircle(Graphics g)
        {
            for (float i = st; i <= end; i += 1.0f)
            {
                thRadian = (float)((i * Math.PI) / 180);
                float x = (float)(Rad * Math.Cos(thRadian));
                float y = (float)(Rad * Math.Sin(thRadian));

                x += XC;
                y += YC;

                g.FillEllipse(Brushes.Black, x, y, 5, 5);
            }
            PointF tempst = Getnextpoint((int)st);
            PointF tempend = Getnextpoint((int)end);


            g.DrawLine(Pens.Black, XC, YC, tempst.X, tempst.Y);
            g.DrawLine(Pens.Black, XC, YC, tempst.X, tempst.Y);

        }
        public PointF Getnextpoint(int theta)
        {

            PointF p = new PointF();

            thRadian = (float)(theta * Math.PI / 180);

            p.X = (float)(Rad * Math.Cos(thRadian)) + XC;
            p.Y = (float)(Rad * Math.Sin(thRadian)) + YC;
            return p;
        }
    }
    public class BezierCurve
    {

        public List<Point> ControlPoints;

        public float t_inc = 0.001f;

        public Color cl = Color.Red;
        public Color clr1 = Color.Blue;
        public Color ftColor = Color.Black;

        public BezierCurve()
        {
            ControlPoints = new List<Point>();
        }


        private float Factorial(int n)
        {
            float res = 1.0f;

            for (int i = 2; i <= n; i++)
                res *= i;

            return res;
        }

        private float C(int n, int i)
        {
            float res = Factorial(n) / (Factorial(i) * Factorial(n - i));
            return res;
        }

        private double Calc_B(float t, int i)
        {
            int n = ControlPoints.Count - 1;
            double res = C(n, i) *
                            Math.Pow((1 - t), (n - i)) *
                            Math.Pow(t, i);
            return res;
        }

        public Point GetPoint(int i)
        {
            return ControlPoints[i];
        }

        public PointF CalcCurvePointAtTime(float t)
        {
            PointF pt = new PointF();
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                float B = (float)Calc_B(t, i);
                pt.X += B * ControlPoints[i].X;
                pt.Y += B * ControlPoints[i].Y;
            }

            return pt;
        }

        private void DrawControlPoints(Graphics g)
        {
            Font Ft = new Font("System", 10);
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                g.FillEllipse(new SolidBrush(clr1),
                                ControlPoints[i].X - 5,
                                ControlPoints[i].Y - 5, 10, 10);

                g.DrawString("P# " + i, Ft, new SolidBrush(ftColor), ControlPoints[i].X - 15, ControlPoints[i].Y - 15);
            }
        }

        public int isCtrlPoint(int XMouse, int YMouse)
        {
            Rectangle rc;
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                rc = new Rectangle(ControlPoints[i].X - 5, ControlPoints[i].Y - 5, 10, 10);
                if (XMouse >= rc.Left && XMouse <= rc.Right && YMouse >= rc.Top && YMouse <= rc.Bottom)
                {
                    return i;
                }
            }
            return -1;
        }

        public void ModifyCtrlPoint(int i, int XMouse, int YMouse)
        {
            Point p = ControlPoints[i];

            p.X = XMouse;
            p.Y = YMouse;
            ControlPoints[i] = p;
        }

        public void SetControlPoint(Point pt)
        {
            ControlPoints.Add(pt);
        }

        private void DrawCurvePoints(Graphics g)
        {
            if (ControlPoints.Count <= 0)
                return;

            PointF curvePoint;
            for (float t = 0.0f; t <= 1.0; t += t_inc)
            {
                curvePoint = CalcCurvePointAtTime(t);
                g.FillEllipse(new SolidBrush(cl),
                                curvePoint.X - 2, curvePoint.Y - 2,
                                4, 4);
            }
        }

        public void DrawCurve(Graphics g)
        {
            DrawControlPoints(g);
            DrawCurvePoints(g);
        }


    }
    public class Transformation
    {

        public LineSegment Rotate(LineSegment L, float xRef, float yRef)
        {
            ///////////////////
            //// translate
            //////////////////
            L.ptS.X -= xRef;
            L.ptS.Y -= yRef;
            L.ptE.X -= xRef;
            L.ptE.Y -= yRef;

            ///////////////////
            //// Rotate around origin
            //////////////////
            double xn = L.ptS.X * Math.Cos(0.5f) - L.ptS.Y * Math.Sin(0.5f);
            double Yn = L.ptS.X * Math.Sin(0.5f) + L.ptS.Y * Math.Cos(0.5f);

            L.ptS.X = (float)xn;
            L.ptS.Y = (float)Yn;

            xn = L.ptE.X * Math.Cos(0.5f) - L.ptE.Y * Math.Sin(0.5f);
            Yn = L.ptE.X * Math.Sin(0.5f) + L.ptE.Y * Math.Cos(0.5f);

            L.ptE.X = (float)xn;
            L.ptE.Y = (float)Yn;

            ///////////////////
            //// undo the translation
            //////////////////
            L.ptS.X += xRef;
            L.ptS.Y += yRef;
            L.ptE.X += xRef;
            L.ptE.Y += yRef;

            return L;
        }
    }
    public class LineSegment
    {
        public PointF ptS, ptE;

        public void DrawYourSelf(Graphics g)
        {
            g.DrawLine(Pens.Black, ptS.X, ptS.Y, ptE.X, ptE.Y);
            g.FillEllipse(Brushes.Red, ptS.X - 5, ptS.Y - 5, 10, 10);
            g.FillEllipse(Brushes.Red, ptE.X - 5, ptE.Y - 5, 10, 10);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

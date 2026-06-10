using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            return Rotate(L, xRef, yRef, 0.5f);
        }

        public LineSegment Rotate(LineSegment L, float xRef, float yRef, float angleRadians)
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
            double xn = L.ptS.X * Math.Cos(angleRadians) - L.ptS.Y * Math.Sin(angleRadians);
            double Yn = L.ptS.X * Math.Sin(angleRadians) + L.ptS.Y * Math.Cos(angleRadians);

            L.ptS.X = (float)xn;
            L.ptS.Y = (float)Yn;

            xn = L.ptE.X * Math.Cos(angleRadians) - L.ptE.Y * Math.Sin(angleRadians);
            Yn = L.ptE.X * Math.Sin(angleRadians) + L.ptE.Y * Math.Cos(angleRadians);

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
    public class PathPart
    {
        public int type;
        public PointF start;
        public PointF end;
        public int length = 180;
        public int rad = 90;
        public int height = 100;
        public float angle = 0;
    }

    public partial class Form1 : Form
    {
        Bitmap off;
        Bitmap background_img;
        Bitmap car_img;
        Timer tt = new Timer();

        List<PathPart> paths = new List<PathPart>();
        List<PointF> ride_points = new List<PointF>();

        int selected = -1;
        int ride_index = 0;
        float xball = 0;
        float yball = 0;
        bool ride_running = false;

        PointF path_start = new PointF(120, 850);

        Panel side_bar;
        Panel scroll_panel;
        PictureBox pic;
        ListBox path_list;
        TrackBar speed_bar;
        Label status_label;
        Button pause_button;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Custom Rollercoaster Path Simulator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1250, 780);
            this.MinimumSize = new Size(1050, 700);
            this.BackColor = Color.FromArgb(17, 27, 46);

            BuildControls();

            pic.Paint += pic_Paint;

            tt.Interval = 30;
            tt.Tick += tt_Tick;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(pic.Width, pic.Height);

            string image_folder = Path.Combine(Application.StartupPath, "Assets");
            background_img = new Bitmap(Path.Combine(image_folder, "background.jpg"));
            car_img = new Bitmap(Path.Combine(image_folder, "car.jpg"));

            AddFirstPaths();

            DrawDubb(pic.CreateGraphics());
        }

        void BuildControls()
        {
            side_bar = new Panel();
            side_bar.Dock = DockStyle.Left;
            side_bar.Width = 265;
            side_bar.AutoScroll = true;
            side_bar.BackColor = Color.Gainsboro;

            Label title = MakeLabel("ROLLERCOASTER SIMULATOR", 20, 18, 225, 28);
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            side_bar.Controls.Add(title);

            side_bar.Controls.Add(MakeLabel("Choose a segment and edit it.", 20, 50, 225, 25));

            AddSection("ADD TRACK", 88);
            AddButton("+ DDA Straight", 20, 116, 225, btnLine_Click);
            AddButton("+ Polar Circle Arc", 20, 156, 225, btnCircle_Click);
            AddButton("+ Bresenham Curve", 20, 196, 225, btnCurve_Click);

            AddSection("SELECT A SEGMENT", 246);

            path_list = new ListBox();
            path_list.Location = new Point(20, 274);
            path_list.Size = new Size(225, 112);
            path_list.BackColor = Color.White;
            path_list.ForeColor = Color.Black;
            path_list.Font = new Font("Arial", 9);
            path_list.SelectedIndexChanged += path_list_SelectedIndexChanged;
            side_bar.Controls.Add(path_list);

            AddSection("CUSTOMIZE SELECTED", 404);
            AddButton("Length -", 20, 432, 108, btnLengthMinus_Click);
            AddButton("Length +", 137, 432, 108, btnLengthPlus_Click);
            AddButton("Radius -", 20, 472, 108, btnRadiusMinus_Click);
            AddButton("Radius +", 137, 472, 108, btnRadiusPlus_Click);
            AddButton("Height -", 20, 512, 108, btnHeightMinus_Click);
            AddButton("Height +", 137, 512, 108, btnHeightPlus_Click);
            AddButton("Rotate -15", 20, 552, 108, btnRotateLeft_Click);
            AddButton("Rotate +15", 137, 552, 108, btnRotateRight_Click);

            AddSection("SIMULATION", 604);

            Label speed_text = MakeLabel("Speed", 20, 632, 60, 25);
            speed_text.Font = new Font("Arial", 9, FontStyle.Bold);
            side_bar.Controls.Add(speed_text);

            speed_bar = new TrackBar();
            speed_bar.Location = new Point(78, 624);
            speed_bar.Size = new Size(167, 42);
            speed_bar.Minimum = 1;
            speed_bar.Maximum = 20;
            speed_bar.Value = 7;
            speed_bar.TickFrequency = 3;
            side_bar.Controls.Add(speed_bar);

            AddButton("START / RESTART", 20, 672, 225, btnStart_Click);

            pause_button = AddButton("PAUSE", 20, 712, 108, btnPause_Click);
            AddButton("CLEAR PATH", 137, 712, 108, btnClear_Click);

            status_label = MakeLabel("Ready. Select a segment to edit it.", 20, 760, 225, 55);
            status_label.ForeColor = Color.Black;
            side_bar.Controls.Add(status_label);

            scroll_panel = new Panel();
            scroll_panel.Dock = DockStyle.Fill;
            scroll_panel.AutoScroll = true;
            scroll_panel.BackColor = Color.LightBlue;

            pic = new PictureBox();
            pic.Location = new Point(0, 0);
            pic.Size = new Size(6000, 1200);
            pic.BackColor = Color.White;
            scroll_panel.Controls.Add(pic);

            this.Controls.Add(scroll_panel);
            this.Controls.Add(side_bar);
        }

        Label MakeLabel(string text, int x, int y, int w, int h)
        {
            Label L = new Label();

            L.Text = text;
            L.Location = new Point(x, y);
            L.Size = new Size(w, h);
            L.ForeColor = Color.Black;
            L.Font = new Font("Arial", 9);

            return L;
        }

        Button AddButton(string text, int x, int y, int w, EventHandler event_method)
        {
            Button b = new Button();

            b.Text = text;
            b.Location = new Point(x, y);
            b.Size = new Size(w, 32);
            b.BackColor = SystemColors.Control;
            b.ForeColor = Color.Black;
            b.FlatStyle = FlatStyle.Standard;
            b.Font = new Font("Arial", 9);
            b.UseVisualStyleBackColor = true;
            b.Click += event_method;

            side_bar.Controls.Add(b);

            return b;
        }

        void AddSection(string text, int y)
        {
            Label L = MakeLabel(text, 20, y, 225, 22);
            L.ForeColor = Color.Black;
            L.Font = new Font("Arial", 9, FontStyle.Bold);
            side_bar.Controls.Add(L);
        }

        void AddFirstPaths()
        {
            PathPart p = new PathPart();
            p.type = 0;
            paths.Add(p);

            p = new PathPart();
            p.type = 1;
            paths.Add(p);

            p = new PathPart();
            p.type = 2;
            paths.Add(p);

            ReArrangePath();
            RefreshList(0);
        }

        void btnLine_Click(object sender, EventArgs e)
        {
            PathPart p = new PathPart();
            p.type = 0;
            paths.Add(p);

            AfterAdd(p, "DDA straight segment added.");
        }

        void btnCircle_Click(object sender, EventArgs e)
        {
            PathPart p = new PathPart();
            p.type = 1;
            paths.Add(p);

            AfterAdd(p, "Polar circle segment added.");
        }

        void btnCurve_Click(object sender, EventArgs e)
        {
            PathPart p = new PathPart();
            p.type = 2;
            paths.Add(p);

            AfterAdd(p, "Bresenham curve segment added.");
        }

        void AfterAdd(PathPart p, string message)
        {
            ReArrangePath();
            RefreshList(paths.Count - 1);
            ScrollToPoint(p.end);

            status_label.Text = message;
            DrawDubb(pic.CreateGraphics());
        }

        void path_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = path_list.SelectedIndex;
            DrawDubb(pic.CreateGraphics());
        }

        void btnLengthMinus_Click(object sender, EventArgs e)
        {
            ChangeLength(-30);
        }

        void btnLengthPlus_Click(object sender, EventArgs e)
        {
            ChangeLength(30);
        }

        void ChangeLength(int value)
        {
            if (selected < 0 || selected >= paths.Count || paths[selected].type != 0)
            {
                status_label.Text = "Select a DDA straight segment.";
                return;
            }

            paths[selected].length += value;

            if (paths[selected].length < 60)
                paths[selected].length = 60;

            if (paths[selected].length > 500)
                paths[selected].length = 500;

            FinishChange("Straight length updated.");
        }

        void btnRadiusMinus_Click(object sender, EventArgs e)
        {
            ChangeRadius(-15);
        }

        void btnRadiusPlus_Click(object sender, EventArgs e)
        {
            ChangeRadius(15);
        }

        void ChangeRadius(int value)
        {
            if (selected < 0 || selected >= paths.Count || paths[selected].type != 1)
            {
                status_label.Text = "Select a polar circle segment.";
                return;
            }

            paths[selected].rad += value;

            if (paths[selected].rad < 40)
                paths[selected].rad = 40;

            if (paths[selected].rad > 220)
                paths[selected].rad = 220;

            FinishChange("Circle radius updated.");
        }

        void btnHeightMinus_Click(object sender, EventArgs e)
        {
            ChangeHeight(-20);
        }

        void btnHeightPlus_Click(object sender, EventArgs e)
        {
            ChangeHeight(20);
        }

        void ChangeHeight(int value)
        {
            if (selected < 0 || selected >= paths.Count || paths[selected].type != 2)
            {
                status_label.Text = "Select a curve segment.";
                return;
            }

            paths[selected].height += value;

            if (paths[selected].height < 20)
                paths[selected].height = 20;

            if (paths[selected].height > 260)
                paths[selected].height = 260;

            FinishChange("Curve height updated.");
        }

        void btnRotateLeft_Click(object sender, EventArgs e)
        {
            RotatePath(-15);
        }

        void btnRotateRight_Click(object sender, EventArgs e)
        {
            RotatePath(15);
        }

        void RotatePath(float value)
        {
            if (selected < 0 || selected >= paths.Count)
            {
                status_label.Text = "Select a segment first.";
                return;
            }

            if (paths[selected].type == 1)
            {
                status_label.Text = "Rotate is for the DDA line and curve.";
                return;
            }

            paths[selected].angle += value;

            FinishChange("Segment rotated by " + value + " degrees.");
        }

        void FinishChange(string message)
        {
            ReArrangePath();
            RefreshList(selected);
            ScrollToPoint(paths[selected].end);

            status_label.Text = message;
            DrawDubb(pic.CreateGraphics());
        }

        void ReArrangePath()
        {
            PointF next = path_start;

            for (int i = 0; i < paths.Count; i++)
            {
                paths[i].start = next;

                if (paths[i].type == 0)
                {
                    PointF dir = GetDirection(paths[i]);
                    paths[i].end.X = paths[i].start.X + dir.X * paths[i].length;
                    paths[i].end.Y = paths[i].start.Y + dir.Y * paths[i].length;
                }
                else if (paths[i].type == 1)
                {
                    paths[i].end.X = paths[i].start.X + paths[i].rad * 2;
                    paths[i].end.Y = paths[i].start.Y;
                }
                else
                {
                    PointF dir = GetDirection(paths[i]);
                    paths[i].end.X = paths[i].start.X + dir.X * 230;
                    paths[i].end.Y = paths[i].start.Y + dir.Y * 230;
                }

                next = paths[i].end;
            }
        }

        PointF GetDirection(PathPart p)
        {
            LineSegment L = new LineSegment();

            L.ptS = new PointF(0, 0);
            L.ptE = new PointF(1, 0);

            Transformation tr = new Transformation();
            tr.Rotate(L, 0, 0, (float)(p.angle * Math.PI / 180.0));

            return L.ptE;
        }

        void RefreshList(int index)
        {
            path_list.Items.Clear();

            for (int i = 0; i < paths.Count; i++)
            {
                string name;

                if (paths[i].type == 0)
                    name = "DDA Straight (" + paths[i].length + " px)";
                else if (paths[i].type == 1)
                    name = "Polar Circle (R=" + paths[i].rad + ")";
                else
                    name = "Bresenham Curve (H=" + paths[i].height + ")";

                path_list.Items.Add((i + 1) + ". " + name);
            }

            if (index >= 0 && index < path_list.Items.Count)
            {
                path_list.SelectedIndex = index;
                selected = index;
            }
            else
            {
                selected = -1;
            }
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            if (paths.Count == 0)
            {
                status_label.Text = "Add at least one segment first.";
                return;
            }

            BuildRidePoints();

            ride_index = 0;
            xball = ride_points[0].X;
            yball = ride_points[0].Y;

            ride_running = true;
            pause_button.Text = "PAUSE";
            tt.Start();

            status_label.Text = "Simulation running.";
            DrawDubb(pic.CreateGraphics());
        }

        void btnPause_Click(object sender, EventArgs e)
        {
            if (ride_running)
            {
                tt.Stop();
                ride_running = false;
                pause_button.Text = "RESUME";
                status_label.Text = "Simulation paused.";
            }
            else if (ride_points.Count > 0 && ride_index < ride_points.Count - 1)
            {
                tt.Start();
                ride_running = true;
                pause_button.Text = "PAUSE";
                status_label.Text = "Simulation resumed.";
            }
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            tt.Stop();

            paths.Clear();
            ride_points.Clear();

            ride_index = 0;
            ride_running = false;
            selected = -1;
            xball = 0;
            yball = 0;

            pause_button.Text = "PAUSE";
            RefreshList(-1);
            scroll_panel.AutoScrollPosition = new Point(0, 0);

            status_label.Text = "Path cleared.";
            DrawDubb(pic.CreateGraphics());
        }

        void BuildRidePoints()
        {
            ride_points.Clear();

            for (int i = 0; i < paths.Count; i++)
            {
                if (paths[i].type == 0)
                    AddLinePoints(paths[i]);
                else if (paths[i].type == 1)
                    AddCirclePoints(paths[i]);
                else
                    AddCurvePoints(paths[i]);
            }
        }

        void AddLinePoints(PathPart p)
        {
            DDA line = new DDA();

            line.Xst = p.start.X;
            line.Yst = p.start.Y;
            line.Xend = p.end.X;
            line.Yend = p.end.Y;
            line.calc();

            int safety = 0;

            while (line.travel && safety < 2000)
            {
                ride_points.Add(new PointF(line.cx, line.cy));
                line.CalcNextPoint();
                safety++;
            }

            ride_points.Add(p.end);
        }

        void AddCirclePoints(PathPart p)
        {
            Circle c = new Circle();

            c.Rad = p.rad;
            c.XC = (int)(p.start.X + p.rad);
            c.YC = (int)p.start.Y;

            for (int th = 180; th <= 360; th += 3)
            {
                ride_points.Add(c.Getnextpoint(th));
            }
        }

        void AddCurvePoints(PathPart p)
        {
            BezierCurve curve = MakeCurve(p);

            for (float t = 0; t <= 1.001f; t += 0.02f)
            {
                ride_points.Add(curve.CalcCurvePointAtTime(Math.Min(1, t)));
            }
        }

        void tt_Tick(object sender, EventArgs e)
        {
            if (ride_points.Count == 0)
                return;

            ride_index += speed_bar.Value;

            if (ride_index >= ride_points.Count)
            {
                ride_index = ride_points.Count - 1;
                tt.Stop();
                ride_running = false;
                pause_button.Text = "PAUSE";
                status_label.Text = "Ride complete.";
            }

            xball = ride_points[ride_index].X;
            yball = ride_points[ride_index].Y;

            DrawDubb(pic.CreateGraphics());
            ScrollToPoint(new PointF(xball, yball));
        }

        void ScrollToPoint(PointF p)
        {
            int x = (int)p.X - scroll_panel.ClientSize.Width / 2;
            int y = (int)p.Y - scroll_panel.ClientSize.Height / 2;

            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            scroll_panel.AutoScrollPosition = new Point(x, y);
        }

        void pic_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void DrawDubb(Graphics g)
        {
            if (off == null)
                return;

            Graphics g2 = Graphics.FromImage(off);

            DrawScene(g2);

            g.DrawImage(off, 0, 0);

            g2.Dispose();
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.LightSkyBlue);

            if (background_img != null)
            {
                int bg_height = pic.Height;
                int bg_width = background_img.Width * bg_height / background_img.Height;

                for (int x = 0; x < pic.Width; x += bg_width)
                {
                    g.DrawImage(background_img, x, 0, bg_width, bg_height);
                }
            }

            g.DrawString(
                "ROLLERCOASTER BUILD ZONE",
                new Font("Arial", 18, FontStyle.Bold),
                Brushes.DarkSlateGray,
                35,
                30);

            DrawStartFlag(g);

            for (int i = 0; i < paths.Count; i++)
            {
                bool is_selected = i == selected;

                if (paths[i].type == 0)
                    DrawLinePath(g, paths[i], is_selected);
                else if (paths[i].type == 1)
                    DrawCirclePath(g, paths[i], is_selected);
                else
                    DrawCurvePath(g, paths[i], is_selected);

                PointF mid = GetPathPoint(paths[i], 0.5f);

                g.DrawString(
                    (i + 1).ToString(),
                    new Font("Arial", 9, FontStyle.Bold),
                    Brushes.DarkSlateGray,
                    mid.X,
                    mid.Y + 10);
            }

            if (paths.Count == 0)
            {
                g.DrawString(
                    "Use the buttons on the left to build a path.",
                    new Font("Arial", 16, FontStyle.Bold),
                    Brushes.SteelBlue,
                    120,
                    560);
            }

            if (ride_points.Count > 0)
            {
                DrawCar(g);
            }
        }

        void DrawCar(Graphics g)
        {
            if (car_img == null)
                return;

            Rectangle source = new Rectangle(50, 130, 1100, 520);
            Rectangle destination = new Rectangle((int)xball - 45, (int)yball - 45, 90, 45);

            ImageAttributes car_color = new ImageAttributes();
            car_color.SetColorKey(Color.FromArgb(235, 235, 235), Color.White);

            g.DrawImage(
                car_img,
                destination,
                source.X,
                source.Y,
                source.Width,
                source.Height,
                GraphicsUnit.Pixel,
                car_color);

            car_color.Dispose();
        }

        void DrawStartFlag(Graphics g)
        {
            g.DrawLine(new Pen(Color.DarkSlateGray, 4),
                path_start.X, path_start.Y,
                path_start.X, path_start.Y - 75);

            PointF[] flag =
            {
                new PointF(path_start.X, path_start.Y - 75),
                new PointF(path_start.X + 48, path_start.Y - 61),
                new PointF(path_start.X, path_start.Y - 47)
            };

            g.FillPolygon(Brushes.OrangeRed, flag);
        }

        void DrawLinePath(Graphics g, PathPart p, bool is_selected)
        {
            if (is_selected)
            {
                g.DrawLine(new Pen(Color.Orange, 9), p.start, p.end);
            }

            DDA line = new DDA();

            line.Xst = p.start.X;
            line.Yst = p.start.Y;
            line.Xend = p.end.X;
            line.Yend = p.end.Y;
            line.calc();

            int safety = 0;

            while (line.travel && safety < 2000)
            {
                g.FillEllipse(Brushes.Navy, line.cx - 3, line.cy - 3, 6, 6);
                line.CalcNextPoint();
                safety++;
            }

            g.FillEllipse(Brushes.Navy, p.end.X - 3, p.end.Y - 3, 6, 6);
        }

        void DrawCirclePath(Graphics g, PathPart p, bool is_selected)
        {
            Rectangle rc = new Rectangle(
                (int)p.start.X,
                (int)(p.start.Y - p.rad),
                p.rad * 2,
                p.rad * 2);

            if (is_selected)
            {
                g.DrawArc(new Pen(Color.Orange, 9), rc, 180, 180);
            }

            Circle c = new Circle();

            c.Rad = p.rad;
            c.XC = (int)(p.start.X + p.rad);
            c.YC = (int)p.start.Y;
            c.st = 180;
            c.end = 360;
            c.Drawcircle(g);
        }

        void DrawCurvePath(Graphics g, PathPart p, bool is_selected)
        {
            BezierCurve curve = MakeCurve(p);

            PointF old_point = curve.CalcCurvePointAtTime(0);

            for (float t = 0.01f; t <= 1.001f; t += 0.01f)
            {
                PointF new_point = curve.CalcCurvePointAtTime(Math.Min(1, t));

                if (is_selected)
                {
                    g.DrawLine(new Pen(Color.Orange, 9), old_point, new_point);
                }

                DrawBresenham(g, Point.Round(old_point), Point.Round(new_point));

                old_point = new_point;
            }

            if (is_selected)
            {
                for (int i = 0; i < curve.ControlPoints.Count; i++)
                {
                    Point cp = curve.ControlPoints[i];
                    g.FillEllipse(Brushes.Red, cp.X - 5, cp.Y - 5, 10, 10);
                }
            }
        }

        BezierCurve MakeCurve(PathPart p)
        {
            BezierCurve curve = new BezierCurve();

            PointF dir = GetDirection(p);
            PointF normal = new PointF(dir.Y, -dir.X);

            Point p0 = Point.Round(p.start);

            Point p1 = Point.Round(new PointF(
                p.start.X + dir.X * 70 + normal.X * p.height,
                p.start.Y + dir.Y * 70 + normal.Y * p.height));

            Point p2 = Point.Round(new PointF(
                p.start.X + dir.X * 160 + normal.X * p.height,
                p.start.Y + dir.Y * 160 + normal.Y * p.height));

            Point p3 = Point.Round(p.end);

            curve.SetControlPoint(p0);
            curve.SetControlPoint(p1);
            curve.SetControlPoint(p2);
            curve.SetControlPoint(p3);

            return curve;
        }

        void DrawBresenham(Graphics g, Point p1, Point p2)
        {
            int x = p1.X;
            int y = p1.Y;
            int dx = Math.Abs(p2.X - p1.X);
            int dy = -Math.Abs(p2.Y - p1.Y);

            int sx;
            int sy;

            if (p1.X < p2.X)
                sx = 1;
            else
                sx = -1;

            if (p1.Y < p2.Y)
                sy = 1;
            else
                sy = -1;

            int err = dx + dy;

            while (true)
            {
                g.FillRectangle(Brushes.Navy, x - 2, y - 2, 5, 5);

                if (x == p2.X && y == p2.Y)
                    break;

                int e2 = 2 * err;

                if (e2 >= dy)
                {
                    err += dy;
                    x += sx;
                }

                if (e2 <= dx)
                {
                    err += dx;
                    y += sy;
                }
            }
        }

        PointF GetPathPoint(PathPart p, float t)
        {
            if (p.type == 0)
            {
                PointF result = new PointF();

                result.X = p.start.X + (p.end.X - p.start.X) * t;
                result.Y = p.start.Y + (p.end.Y - p.start.Y) * t;

                return result;
            }

            if (p.type == 1)
            {
                Circle c = new Circle();

                c.Rad = p.rad;
                c.XC = (int)(p.start.X + p.rad);
                c.YC = (int)p.start.Y;

                return c.Getnextpoint((int)(180 + 180 * t));
            }

            BezierCurve curve = MakeCurve(p);
            return curve.CalcCurvePointAtTime(t);
        }
    }
}

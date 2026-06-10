using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graphics_Train_Project
{
    public abstract class TrackSegment
    {
        public PointF Start { get; protected set; }
        public int Number { get; set; }
        public bool Selected { get; set; }

        public abstract PointF End { get; }
        public abstract float EstimatedLength { get; }
        public abstract string DisplayName { get; }

        public virtual void SetStart(PointF point)
        {
            Start = point;
        }

        public abstract void Draw(Graphics g);
        public abstract PointF GetPoint(float t);

        public override string ToString()
        {
            return Number + ". " + DisplayName;
        }
    }

    public class StraightTrackSegment : TrackSegment
    {
        private PointF direction = new PointF(1, 0);

        public float Length { get; private set; }

        public StraightTrackSegment(PointF start)
        {
            Start = start;
            Length = 180;
        }

        public override PointF End
        {
            get
            {
                return new PointF(Start.X + direction.X * Length, Start.Y + direction.Y * Length);
            }
        }

        public override float EstimatedLength { get { return Length; } }
        public override string DisplayName { get { return "DDA Straight (" + (int)Length + " px)"; } }

        public void ChangeLength(float amount)
        {
            Length = Math.Max(60, Math.Min(500, Length + amount));
        }

        public void RotateBy(float degrees)
        {
            LineSegment line = new LineSegment();
            line.ptS = new PointF(0, 0);
            line.ptE = direction;

            Transformation transformation = new Transformation();
            transformation.Rotate(line, 0, 0, (float)(degrees * Math.PI / 180.0));

            float size = (float)Math.Sqrt(line.ptE.X * line.ptE.X + line.ptE.Y * line.ptE.Y);
            if (size > 0)
            {
                direction = new PointF(line.ptE.X / size, line.ptE.Y / size);
            }
        }

        public override void Draw(Graphics g)
        {
            if (Selected)
            {
                using (Pen highlight = new Pen(Color.FromArgb(255, 164, 46), 9))
                {
                    highlight.StartCap = LineCap.Round;
                    highlight.EndCap = LineCap.Round;
                    g.DrawLine(highlight, Start, End);
                }
            }

            // The starter DDA class supplies every plotted point of the straight track.
            DDA dda = new DDA();
            dda.Xst = Start.X;
            dda.Yst = Start.Y;
            dda.Xend = End.X;
            dda.Yend = End.Y;
            dda.calc();

            int safety = 0;
            while (dda.travel && safety < 2000)
            {
                g.FillEllipse(Brushes.Navy, dda.cx - 3, dda.cy - 3, 6, 6);
                dda.CalcNextPoint();
                safety++;
            }
            g.FillEllipse(Brushes.Navy, End.X - 3, End.Y - 3, 6, 6);
        }

        public override PointF GetPoint(float t)
        {
            PointF end = End;
            return new PointF(Start.X + (end.X - Start.X) * t, Start.Y + (end.Y - Start.Y) * t);
        }
    }

    public class CircularTrackSegment : TrackSegment
    {
        public float Radius { get; private set; }

        public CircularTrackSegment(PointF start)
        {
            Start = start;
            Radius = 90;
        }

        public override PointF End { get { return new PointF(Start.X + Radius * 2, Start.Y); } }
        public override float EstimatedLength { get { return (float)Math.PI * Radius; } }
        public override string DisplayName { get { return "Polar Circle Arc (R=" + (int)Radius + ")"; } }

        public void ChangeRadius(float amount)
        {
            Radius = Math.Max(40, Math.Min(220, Radius + amount));
        }

        public override void Draw(Graphics g)
        {
            RectangleF bounds = new RectangleF(Start.X, Start.Y - Radius, Radius * 2, Radius * 2);
            if (Selected)
            {
                using (Pen highlight = new Pen(Color.FromArgb(255, 164, 46), 9))
                {
                    g.DrawArc(highlight, bounds, 180, 180);
                }
            }

            // The starter polar-circle class plots the circular section degree by degree.
            Circle circle = new Circle();
            circle.Rad = (int)Radius;
            circle.XC = (int)(Start.X + Radius);
            circle.YC = (int)Start.Y;
            circle.st = 180;
            circle.end = 360;
            circle.Drawcircle(g);
        }

        public override PointF GetPoint(float t)
        {
            double angle = (180 + 180 * t) * Math.PI / 180.0;
            return new PointF(
                Start.X + Radius + (float)(Radius * Math.Cos(angle)),
                Start.Y + (float)(Radius * Math.Sin(angle)));
        }
    }

    public class CurvedTrackSegment : TrackSegment
    {
        private PointF direction = new PointF(1, 0);

        public float Length { get; private set; }
        public float Height { get; private set; }

        public CurvedTrackSegment(PointF start)
        {
            Start = start;
            Length = 230;
            Height = 100;
        }

        public override PointF End { get { return BuildPoints()[3]; } }
        public override float EstimatedLength { get { return Length + Height * 1.5f; } }
        public override string DisplayName { get { return "Bresenham Curve (H=" + (int)Height + ")"; } }

        public void ChangeHeight(float amount)
        {
            Height = Math.Max(20, Math.Min(260, Height + amount));
        }

        public void RotateBy(float degrees)
        {
            LineSegment line = new LineSegment();
            line.ptS = new PointF(0, 0);
            line.ptE = direction;

            Transformation transformation = new Transformation();
            transformation.Rotate(line, 0, 0, (float)(degrees * Math.PI / 180.0));

            float size = (float)Math.Sqrt(line.ptE.X * line.ptE.X + line.ptE.Y * line.ptE.Y);
            if (size > 0)
            {
                direction = new PointF(line.ptE.X / size, line.ptE.Y / size);
            }
        }

        private Point[] BuildPoints()
        {
            PointF perpendicular = new PointF(direction.Y, -direction.X);
            Point[] points = new Point[4];
            points[0] = Point.Round(Start);
            points[1] = Point.Round(new PointF(
                Start.X + direction.X * Length * 0.30f + perpendicular.X * Height,
                Start.Y + direction.Y * Length * 0.30f + perpendicular.Y * Height));
            points[2] = Point.Round(new PointF(
                Start.X + direction.X * Length * 0.70f + perpendicular.X * Height,
                Start.Y + direction.Y * Length * 0.70f + perpendicular.Y * Height));
            points[3] = Point.Round(new PointF(
                Start.X + direction.X * Length,
                Start.Y + direction.Y * Length));
            return points;
        }

        private BezierCurve CreateCurve()
        {
            BezierCurve curve = new BezierCurve();
            curve.t_inc = 0.01f;
            Point[] points = BuildPoints();
            for (int i = 0; i < points.Length; i++)
            {
                curve.SetControlPoint(points[i]);
            }
            return curve;
        }

        private void DrawBresenhamLine(Graphics g, Point start, Point end)
        {
            int x = start.X;
            int y = start.Y;
            int dx = Math.Abs(end.X - start.X);
            int sx = start.X < end.X ? 1 : -1;
            int dy = -Math.Abs(end.Y - start.Y);
            int sy = start.Y < end.Y ? 1 : -1;
            int error = dx + dy;

            while (true)
            {
                g.FillRectangle(Brushes.Navy, x - 2, y - 2, 5, 5);
                if (x == end.X && y == end.Y)
                {
                    break;
                }

                int twiceError = 2 * error;
                if (twiceError >= dy)
                {
                    error += dy;
                    x += sx;
                }
                if (twiceError <= dx)
                {
                    error += dx;
                    y += sy;
                }
            }
        }

        public override void Draw(Graphics g)
        {
            BezierCurve curve = CreateCurve();

            if (Selected)
            {
                Point[] controls = BuildPoints();
                using (Pen helper = new Pen(Color.FromArgb(130, 255, 164, 46), 2))
                {
                    helper.DashStyle = DashStyle.Dash;
                    g.DrawLines(helper, controls);
                }

                for (int i = 0; i < controls.Length; i++)
                {
                    g.FillEllipse(Brushes.Orange, controls[i].X - 5, controls[i].Y - 5, 10, 10);
                }
            }

            // The starter Bezier class calculates the curve; Bresenham rasterizes it.
            PointF previous = curve.CalcCurvePointAtTime(0);
            for (float t = 0.01f; t <= 1.001f; t += 0.01f)
            {
                PointF current = curve.CalcCurvePointAtTime(Math.Min(1, t));
                if (Selected)
                {
                    using (Pen highlight = new Pen(Color.FromArgb(255, 164, 46), 9))
                    {
                        g.DrawLine(highlight, previous, current);
                    }
                }
                DrawBresenhamLine(g, Point.Round(previous), Point.Round(current));
                previous = current;
            }
        }

        public override PointF GetPoint(float t)
        {
            return CreateCurve().CalcCurvePointAtTime(t);
        }
    }

    public class TrackCanvas : Control
    {
        public Action<Graphics> Renderer { get; set; }

        public TrackCanvas()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Renderer != null)
            {
                Renderer(e.Graphics);
            }
        }
    }

    public partial class Form1
    {
        private readonly List<TrackSegment> trackSegments = new List<TrackSegment>();
        private readonly List<PointF> simulationPoints = new List<PointF>();
        private readonly PointF pathStart = new PointF(120, 650);

        private Panel scrollHost;
        private TrackCanvas drawingCanvas;
        private ListBox segmentList;
        private TrackBar speedBar;
        private Label statusLabel;
        private Button pauseButton;
        private Timer simulationTimer;
        private float simulationPosition;
        private PointF? cartPosition;

        private void BuildInterface()
        {
            Text = "Custom Rollercoaster Path Simulator";
            MinimumSize = new Size(1050, 700);
            Size = new Size(1250, 780);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(17, 27, 46);

            Panel sideBar = new Panel();
            sideBar.Dock = DockStyle.Left;
            sideBar.Width = 265;
            sideBar.AutoScroll = true;
            sideBar.BackColor = Color.FromArgb(17, 27, 46);

            Label title = NewLabel("ROLLERCOASTER LAB", 20, 18, 225, 28, 14, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(255, 184, 77);
            sideBar.Controls.Add(title);
            sideBar.Controls.Add(NewLabel("Build, customize, then ride.", 20, 50, 225, 22, 9, FontStyle.Regular));

            AddSectionLabel(sideBar, "ADD TRACK", 88);
            sideBar.Controls.Add(NewButton("+ DDA Straight", 20, 116, 225, AddStraightClick));
            sideBar.Controls.Add(NewButton("+ Polar Circle Arc", 20, 156, 225, AddCircleClick));
            sideBar.Controls.Add(NewButton("+ Bresenham Curve", 20, 196, 225, AddCurveClick));

            AddSectionLabel(sideBar, "SELECT A SEGMENT", 246);
            segmentList = new ListBox();
            segmentList.Location = new Point(20, 274);
            segmentList.Size = new Size(225, 112);
            segmentList.BackColor = Color.FromArgb(32, 47, 72);
            segmentList.ForeColor = Color.White;
            segmentList.BorderStyle = BorderStyle.FixedSingle;
            segmentList.Font = new Font("Segoe UI", 9);
            segmentList.SelectedIndexChanged += SegmentListSelectedIndexChanged;
            sideBar.Controls.Add(segmentList);

            AddSectionLabel(sideBar, "CUSTOMIZE SELECTED", 404);
            sideBar.Controls.Add(NewButton("Length -", 20, 432, 108, DecreaseLengthClick));
            sideBar.Controls.Add(NewButton("Length +", 137, 432, 108, IncreaseLengthClick));
            sideBar.Controls.Add(NewButton("Radius -", 20, 472, 108, DecreaseRadiusClick));
            sideBar.Controls.Add(NewButton("Radius +", 137, 472, 108, IncreaseRadiusClick));
            sideBar.Controls.Add(NewButton("Height -", 20, 512, 108, DecreaseHeightClick));
            sideBar.Controls.Add(NewButton("Height +", 137, 512, 108, IncreaseHeightClick));
            sideBar.Controls.Add(NewButton("Rotate -15", 20, 552, 108, RotateLeftClick));
            sideBar.Controls.Add(NewButton("Rotate +15", 137, 552, 108, RotateRightClick));

            AddSectionLabel(sideBar, "SIMULATION", 604);
            sideBar.Controls.Add(NewLabel("Speed", 20, 632, 70, 24, 9, FontStyle.Bold));
            speedBar = new TrackBar();
            speedBar.Location = new Point(78, 624);
            speedBar.Size = new Size(167, 42);
            speedBar.Minimum = 1;
            speedBar.Maximum = 20;
            speedBar.Value = 7;
            speedBar.TickFrequency = 3;
            sideBar.Controls.Add(speedBar);

            Button startButton = NewButton("START / RESTART", 20, 672, 225, StartSimulationClick);
            startButton.BackColor = Color.FromArgb(226, 105, 38);
            sideBar.Controls.Add(startButton);
            pauseButton = NewButton("PAUSE", 20, 712, 108, PauseSimulationClick);
            sideBar.Controls.Add(pauseButton);
            sideBar.Controls.Add(NewButton("CLEAR PATH", 137, 712, 108, ClearPathClick));

            statusLabel = NewLabel("Ready. Select a segment to edit it.", 20, 760, 225, 54, 9, FontStyle.Regular);
            statusLabel.ForeColor = Color.FromArgb(180, 200, 220);
            sideBar.Controls.Add(statusLabel);

            scrollHost = new Panel();
            scrollHost.Dock = DockStyle.Fill;
            scrollHost.AutoScroll = true;
            scrollHost.BackColor = Color.FromArgb(222, 241, 250);

            drawingCanvas = new TrackCanvas();
            drawingCanvas.Location = new Point(0, 0);
            drawingCanvas.Size = new Size(6000, 1200);
            drawingCanvas.Renderer = RenderScene;
            scrollHost.Controls.Add(drawingCanvas);

            Controls.Add(scrollHost);
            Controls.Add(sideBar);

            simulationTimer = new Timer();
            simulationTimer.Interval = 25;
            simulationTimer.Tick += SimulationTimerTick;

            AddStarterTrack();
        }

        private Label NewLabel(string text, int x, int y, int width, int height, int size, FontStyle style)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(width, height);
            label.ForeColor = Color.White;
            label.Font = new Font("Segoe UI", size, style);
            return label;
        }

        private void AddSectionLabel(Control parent, string text, int y)
        {
            Label label = NewLabel(text, 20, y, 225, 22, 9, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(113, 170, 210);
            parent.Controls.Add(label);
        }

        private Button NewButton(string text, int x, int y, int width, EventHandler click)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, 32);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.FromArgb(80, 110, 145);
            button.BackColor = Color.FromArgb(39, 59, 88);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Click += click;
            return button;
        }

        private void AddStarterTrack()
        {
            AddSegment(new StraightTrackSegment(pathStart), false);
            AddSegment(new CircularTrackSegment(GetPathEnd()), false);
            AddSegment(new CurvedTrackSegment(GetPathEnd()), false);
            RefreshSegmentList(0);
            drawingCanvas.Invalidate();
        }

        private PointF GetPathEnd()
        {
            if (trackSegments.Count == 0)
            {
                return pathStart;
            }
            return trackSegments[trackSegments.Count - 1].End;
        }

        private void AddSegment(TrackSegment segment, bool select)
        {
            segment.Number = trackSegments.Count + 1;
            segment.SetStart(GetPathEnd());
            trackSegments.Add(segment);
            int selectedIndex = select ? trackSegments.Count - 1 : segmentList == null ? -1 : segmentList.SelectedIndex;
            RefreshSegmentList(selectedIndex);
            drawingCanvas.Invalidate();
            EnsureVisible(segment.End);
        }

        private void AddStraightClick(object sender, EventArgs e)
        {
            AddSegment(new StraightTrackSegment(GetPathEnd()), true);
            SetStatus("DDA straight segment added.");
        }

        private void AddCircleClick(object sender, EventArgs e)
        {
            AddSegment(new CircularTrackSegment(GetPathEnd()), true);
            SetStatus("Polar circular segment added.");
        }

        private void AddCurveClick(object sender, EventArgs e)
        {
            AddSegment(new CurvedTrackSegment(GetPathEnd()), true);
            SetStatus("Bresenham curve segment added.");
        }

        private void SegmentListSelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < trackSegments.Count; i++)
            {
                trackSegments[i].Selected = i == segmentList.SelectedIndex;
            }
            drawingCanvas.Invalidate();
        }

        private TrackSegment SelectedSegment()
        {
            if (segmentList.SelectedIndex < 0 || segmentList.SelectedIndex >= trackSegments.Count)
            {
                SetStatus("Select a segment from the list first.");
                return null;
            }
            return trackSegments[segmentList.SelectedIndex];
        }

        private void DecreaseLengthClick(object sender, EventArgs e) { ChangeStraightLength(-30); }
        private void IncreaseLengthClick(object sender, EventArgs e) { ChangeStraightLength(30); }
        private void DecreaseRadiusClick(object sender, EventArgs e) { ChangeCircleRadius(-15); }
        private void IncreaseRadiusClick(object sender, EventArgs e) { ChangeCircleRadius(15); }
        private void DecreaseHeightClick(object sender, EventArgs e) { ChangeCurveHeight(-20); }
        private void IncreaseHeightClick(object sender, EventArgs e) { ChangeCurveHeight(20); }
        private void RotateLeftClick(object sender, EventArgs e) { RotateSelected(-15); }
        private void RotateRightClick(object sender, EventArgs e) { RotateSelected(15); }

        private void ChangeStraightLength(float amount)
        {
            StraightTrackSegment segment = SelectedSegment() as StraightTrackSegment;
            if (segment == null)
            {
                SetStatus("Length controls are for a DDA straight segment.");
                return;
            }
            segment.ChangeLength(amount);
            FinishCustomization("Straight length updated.");
        }

        private void ChangeCircleRadius(float amount)
        {
            CircularTrackSegment segment = SelectedSegment() as CircularTrackSegment;
            if (segment == null)
            {
                SetStatus("Radius controls are for a polar circle segment.");
                return;
            }
            segment.ChangeRadius(amount);
            FinishCustomization("Circle radius updated.");
        }

        private void ChangeCurveHeight(float amount)
        {
            CurvedTrackSegment segment = SelectedSegment() as CurvedTrackSegment;
            if (segment == null)
            {
                SetStatus("Height controls are for a curve segment.");
                return;
            }
            segment.ChangeHeight(amount);
            FinishCustomization("Curve height updated.");
        }

        private void RotateSelected(float degrees)
        {
            TrackSegment selected = SelectedSegment();
            StraightTrackSegment straight = selected as StraightTrackSegment;
            CurvedTrackSegment curve = selected as CurvedTrackSegment;

            if (straight != null)
            {
                straight.RotateBy(degrees);
            }
            else if (curve != null)
            {
                curve.RotateBy(degrees);
            }
            else
            {
                SetStatus("Rotation is available for straight and curve segments.");
                return;
            }
            FinishCustomization("Segment rotated by " + degrees + " degrees.");
        }

        private void FinishCustomization(string message)
        {
            int selectedIndex = segmentList.SelectedIndex;
            ReflowPath();
            RefreshSegmentList(selectedIndex);
            drawingCanvas.Invalidate();
            EnsureVisible(trackSegments[selectedIndex].End);
            SetStatus(message);
        }

        private void ReflowPath()
        {
            PointF nextStart = pathStart;
            for (int i = 0; i < trackSegments.Count; i++)
            {
                trackSegments[i].Number = i + 1;
                trackSegments[i].SetStart(nextStart);
                nextStart = trackSegments[i].End;
            }
        }

        private void RefreshSegmentList(int selectedIndex)
        {
            segmentList.BeginUpdate();
            segmentList.Items.Clear();
            for (int i = 0; i < trackSegments.Count; i++)
            {
                segmentList.Items.Add(trackSegments[i]);
            }
            segmentList.EndUpdate();

            if (selectedIndex >= 0 && selectedIndex < segmentList.Items.Count)
            {
                segmentList.SelectedIndex = selectedIndex;
            }
            else
            {
                for (int i = 0; i < trackSegments.Count; i++)
                {
                    trackSegments[i].Selected = false;
                }
            }
        }

        private void StartSimulationClick(object sender, EventArgs e)
        {
            if (trackSegments.Count == 0)
            {
                SetStatus("Add at least one track segment first.");
                return;
            }

            BuildSimulationPoints();
            simulationPosition = 0;
            cartPosition = simulationPoints[0];
            pauseButton.Text = "PAUSE";
            simulationTimer.Start();
            SetStatus("Simulation running. Change the speed at any time.");
        }

        private void PauseSimulationClick(object sender, EventArgs e)
        {
            if (simulationTimer.Enabled)
            {
                simulationTimer.Stop();
                pauseButton.Text = "RESUME";
                SetStatus("Simulation paused.");
            }
            else if (simulationPoints.Count > 0 && cartPosition.HasValue)
            {
                simulationTimer.Start();
                pauseButton.Text = "PAUSE";
                SetStatus("Simulation resumed.");
            }
        }

        private void BuildSimulationPoints()
        {
            simulationPoints.Clear();
            for (int segmentIndex = 0; segmentIndex < trackSegments.Count; segmentIndex++)
            {
                TrackSegment segment = trackSegments[segmentIndex];
                int samples = Math.Max(12, (int)(segment.EstimatedLength / 4));
                int startSample = segmentIndex == 0 ? 0 : 1;
                for (int i = startSample; i <= samples; i++)
                {
                    simulationPoints.Add(segment.GetPoint((float)i / samples));
                }
            }
        }

        private void SimulationTimerTick(object sender, EventArgs e)
        {
            if (simulationPoints.Count < 2)
            {
                simulationTimer.Stop();
                return;
            }

            simulationPosition += speedBar.Value * 0.28f;
            if (simulationPosition >= simulationPoints.Count - 1)
            {
                simulationPosition = simulationPoints.Count - 1;
                cartPosition = simulationPoints[simulationPoints.Count - 1];
                simulationTimer.Stop();
                pauseButton.Text = "PAUSE";
                SetStatus("Ride complete. Press Start to run it again.");
            }
            else
            {
                int index = (int)simulationPosition;
                float fraction = simulationPosition - index;
                PointF first = simulationPoints[index];
                PointF second = simulationPoints[index + 1];
                cartPosition = new PointF(
                    first.X + (second.X - first.X) * fraction,
                    first.Y + (second.Y - first.Y) * fraction);
            }

            drawingCanvas.Invalidate();
            EnsureVisible(cartPosition.Value);
        }

        private void ClearPathClick(object sender, EventArgs e)
        {
            simulationTimer.Stop();
            trackSegments.Clear();
            simulationPoints.Clear();
            cartPosition = null;
            simulationPosition = 0;
            RefreshSegmentList(-1);
            drawingCanvas.Invalidate();
            scrollHost.AutoScrollPosition = new Point(0, 0);
            SetStatus("Path cleared. Add any segment as many times as needed.");
        }

        private void EnsureVisible(PointF point)
        {
            if (scrollHost == null)
            {
                return;
            }

            int x = Math.Max(0, (int)point.X - scrollHost.ClientSize.Width / 2);
            int y = Math.Max(0, (int)point.Y - scrollHost.ClientSize.Height / 2);
            scrollHost.AutoScrollPosition = new Point(x, y);
        }

        private void SetStatus(string message)
        {
            if (statusLabel != null)
            {
                statusLabel.Text = message;
            }
        }

        private void RenderScene(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle area = drawingCanvas.ClientRectangle;

            using (LinearGradientBrush sky = new LinearGradientBrush(
                area, Color.FromArgb(218, 242, 252), Color.FromArgb(248, 252, 255), LinearGradientMode.Vertical))
            {
                g.FillRectangle(sky, area);
            }

            using (Pen grid = new Pen(Color.FromArgb(28, 95, 135, 170), 1))
            {
                for (int x = 0; x < area.Width; x += 100)
                {
                    g.DrawLine(grid, x, 0, x, area.Height);
                }
                for (int y = 0; y < area.Height; y += 100)
                {
                    g.DrawLine(grid, 0, y, area.Width, y);
                }
            }

            using (SolidBrush ground = new SolidBrush(Color.FromArgb(174, 214, 151)))
            {
                g.FillRectangle(ground, 0, 900, area.Width, area.Height - 900);
            }
            using (Pen groundLine = new Pen(Color.FromArgb(91, 145, 83), 4))
            {
                g.DrawLine(groundLine, 0, 900, area.Width, 900);
            }

            using (Font zoneFont = new Font("Segoe UI", 18, FontStyle.Bold))
            using (SolidBrush zoneBrush = new SolidBrush(Color.FromArgb(55, 77, 105)))
            {
                g.DrawString("ROLLERCOASTER BUILD ZONE", zoneFont, zoneBrush, 35, 30);
            }

            DrawStartFlag(g);

            for (int i = 0; i < trackSegments.Count; i++)
            {
                trackSegments[i].Draw(g);
                PointF labelPoint = trackSegments[i].GetPoint(0.5f);
                using (Font numberFont = new Font("Segoe UI", 9, FontStyle.Bold))
                using (SolidBrush numberBrush = new SolidBrush(Color.FromArgb(35, 54, 79)))
                {
                    g.DrawString((i + 1).ToString(), numberFont, numberBrush, labelPoint.X - 5, labelPoint.Y + 12);
                }
            }

            if (trackSegments.Count == 0)
            {
                using (Font emptyFont = new Font("Segoe UI", 16, FontStyle.Bold))
                using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(90, 120, 145)))
                {
                    g.DrawString("Use the buttons on the left to build a new path.", emptyFont, emptyBrush, 120, 560);
                }
            }

            if (cartPosition.HasValue)
            {
                DrawCart(g, cartPosition.Value);
            }
        }

        private void DrawStartFlag(Graphics g)
        {
            using (Pen pole = new Pen(Color.FromArgb(55, 65, 75), 4))
            using (SolidBrush flag = new SolidBrush(Color.FromArgb(226, 105, 38)))
            {
                g.DrawLine(pole, pathStart.X, pathStart.Y, pathStart.X, pathStart.Y - 75);
                PointF[] flagShape =
                {
                    new PointF(pathStart.X, pathStart.Y - 75),
                    new PointF(pathStart.X + 48, pathStart.Y - 61),
                    new PointF(pathStart.X, pathStart.Y - 47)
                };
                g.FillPolygon(flag, flagShape);
            }
        }

        private void DrawCart(Graphics g, PointF point)
        {
            float angle = 0;
            int index = Math.Min(simulationPoints.Count - 2, Math.Max(0, (int)simulationPosition));
            if (simulationPoints.Count >= 2)
            {
                PointF first = simulationPoints[index];
                PointF second = simulationPoints[index + 1];
                angle = (float)(Math.Atan2(second.Y - first.Y, second.X - first.X) * 180 / Math.PI);
            }

            GraphicsState state = g.Save();
            g.TranslateTransform(point.X, point.Y);
            g.RotateTransform(angle);
            using (SolidBrush body = new SolidBrush(Color.FromArgb(226, 69, 46)))
            using (Pen outline = new Pen(Color.FromArgb(90, 35, 35), 2))
            {
                g.FillRectangle(body, -20, -22, 40, 18);
                g.DrawRectangle(outline, -20, -22, 40, 18);
                g.FillEllipse(Brushes.Gold, -15, -7, 10, 10);
                g.FillEllipse(Brushes.Gold, 5, -7, 10, 10);
            }
            g.Restore(state);
        }
    }
}

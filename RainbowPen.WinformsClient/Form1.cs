using RainbowDrawingTools.Core;

namespace RainbowDrawingTools.WinformsClient
{
    public partial class Form1 : Form
    {
        private RainbowPen _pen;
        private Point _lastDrawPoint = new Point(0, 0);
        private bool _drawingMode = false;

        private List<Color> _customColors;
        private RainbowColorsEditForm _editForm;

        public Form1()
        {
            InitializeComponent();

            _pen = new RainbowPen(1);

            _customColors = new List<Color>();
            _editForm = new RainbowColorsEditForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drawPanel.BackColor = Color.White;

            PopulatePenSizesCombo();
            PopulateColorStepsCombo();
            PopulateOrientationsCombo();
            PopulateFillsCombo();
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _drawingMode = true;
            _lastDrawPoint = new Point(e.X, e.Y);
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _drawingMode = false;
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drawingMode)
            {
                using (var graphics = drawPanel.CreateGraphics())
                {
                    var currentPoint = new Point(e.X, e.Y);
                    graphics.DrawLine(_pen, _lastDrawPoint, currentPoint);
                }

                Invalidate();

                _lastDrawPoint.X = e.X;
                _lastDrawPoint.Y = e.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pen = new RainbowPen(GetPenSize());
            using (var g = drawPanel.CreateGraphics())
            {
                g.DrawLine(pen, new Point(0, 0), new Point(drawPanel.Width - 1, drawPanel.Height - 1));
                g.DrawLine(pen, new Point(0, drawPanel.Height - 1), new Point(drawPanel.Width - 1, 0));
                g.DrawLine(pen, new Point(0, drawPanel.Height / 2), new Point(drawPanel.Width - 1, drawPanel.Height / 2));
                g.DrawLine(pen, new Point(drawPanel.Width / 2, 0), new Point(drawPanel.Width / 2, drawPanel.Height - 1));
            }

            Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pen = new RainbowPen(GetPenSize());
            var rect = new Rectangle(337, 100, 600, 600);

            using (var g = drawPanel.CreateGraphics())
            {
                g.DrawRectangle(pen, rect);
            }

            Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pen = new RainbowPen(GetPenSize());
            var rect = new Rectangle(337, 100, 600, 600);

            using (var g = drawPanel.CreateGraphics())
            {
                g.DrawEllipse(pen, rect);
            }

            Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var colors = GetColors(true);
            var brush = new RainbowBrush(colors);
            var rect = new Rectangle(337, 100, 600, 600);
            using (var g = drawPanel.CreateGraphics())
            {
                g.FillRectangle(brush, rect, GetBrushOrientation(), GetFillMode());
            }

            Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var colors = ColorHelper.GetRainbowColors(GetColorStep());
            var brush = new RainbowBrush(colors);
            var rect = new Rectangle(337, 100, 600, 600);
            using (var g = drawPanel.CreateGraphics())
            {
                g.FillEllipse(brush, rect, GetBrushOrientation(), GetFillMode());
            }

            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c2 = Color.Aqua;
            var c3 = Color.GreenYellow;
            var c4 = Color.Lime;
            var c1 = Color.Turquoise;
            //var colors = ColorHelper.GetTransitionColors(new List<Color> { c1, c2, c3, c4 }, 2);

            var colors = ColorHelper.GetRainbowColors(GetColorStep());
            var brush = new RainbowBrush(colors);
            var rect = new Rectangle(0, 0, drawPanel.Width, drawPanel.Height);
            using (var g = drawPanel.CreateGraphics())
            {
                g.FillRectangle(brush, rect, GetBrushOrientation(), GetFillMode());
            }

            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var g = drawPanel.CreateGraphics())
            {
                g.Clear(drawPanel.BackColor);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void PopulatePenSizesCombo()
        {
            penSizesComboBox.Items.Clear();
            for (var x = 1; x <= 5; x++)
            {
                penSizesComboBox.Items.Add(x);
            }
            penSizesComboBox.SelectedIndex = 0;
        }

        private int GetPenSize()
        {
            return int.Parse(penSizesComboBox.SelectedItem.ToString());
        }

        private void PopulateColorStepsCombo()
        {
            stepsComboBox.Items.Clear();
            stepsComboBox.Items.Add(1);
            stepsComboBox.Items.Add(2);
            stepsComboBox.Items.Add(3);
            stepsComboBox.Items.Add(5);
            stepsComboBox.Items.Add(10);
            stepsComboBox.Items.Add(20);

            stepsComboBox.SelectedIndex = 0;
        }

        private int GetColorStep()
        {
            return int.Parse(stepsComboBox.SelectedItem.ToString());
        }

        private void PopulateOrientationsCombo()
        {
            orientationsComboBox.Items.Clear();
            orientationsComboBox.Items.Add("Vertical");
            orientationsComboBox.Items.Add("Horizontal");

            orientationsComboBox.SelectedIndex = 0;
        }
        private BrushOrientation GetBrushOrientation()
        {
            if (orientationsComboBox.SelectedIndex == 0)
                return BrushOrientation.Vertical;
            else
                return BrushOrientation.Horizontal;
        }

        private void PopulateFillsCombo()
        {
            fillsComboBox.Items.Clear();
            fillsComboBox.Items.Add("Repeat");
            fillsComboBox.Items.Add("Bounce");
            fillsComboBox.Items.Add("Stretch");

            fillsComboBox.SelectedIndex = fillsComboBox.Items.Count - 1;
        }

        private FillMode GetFillMode()
        {
            if (fillsComboBox.SelectedIndex == 0)
            {
                return FillMode.Repeat;
            }
            else if (fillsComboBox.SelectedIndex == 1)
                return FillMode.Bounce;
            else
                return FillMode.Stretch;
        }

        private List<Color> GetColors(bool useCustom = false)
        {
            if (useCustom && _customColors.Count > 2)
                return ColorHelper.GetTransitionColors(_customColors, GetColorStep());

            return ColorHelper.GetRainbowColors(GetColorStep());
        }

        private void penSizesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pen.Width = GetPenSize();
        }

        private void editColorsButton_Click(object sender, EventArgs e)
        {
            if (_editForm.ShowDialog() == DialogResult.OK)
            {
                _customColors = _editForm.Colors;
            }
        }

        private void drawPolygonButton_Click(object sender, EventArgs e)
        {
            var pen = new RainbowPen(GetPenSize());
            var points = new List<Point> { new Point(50, 50), new Point(70, 250), new Point(150, 250), new Point(250, 150), new Point(150, 70) };
            using (var g = drawPanel.CreateGraphics())
            {
                g.DrawPolygon(pen, points.ToArray());
            }

            Invalidate();
        }
    }
}
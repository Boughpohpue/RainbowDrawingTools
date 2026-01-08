using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public static class GraphicsExtensions
    {
        public static void DrawLine(this Graphics graphics, RainbowPen pen, Point start, Point end, int stepSize = 1)
        {
            graphics.DrawPointLines(pen, new LineSegment(start, end).GetSegmentPointsAtDistance(stepSize));
        }

        public static void DrawRectangle(this Graphics graphics, RainbowPen pen, Rectangle rect, int stepSize = 1)
        {
            var rectanglePoints = GeometryHelper.GetRectanglePoints(rect);
            rectanglePoints.Add(rectanglePoints.Last());
            graphics.DrawPointLines(pen, rectanglePoints);
        }

        public static void DrawArc(this Graphics graphics, RainbowPen pen, Rectangle rect, float startAngle, float sweepAngle, int stepSize = 1)
        {
            var rectanglePoints = GeometryHelper.GetRectanglePoints(rect);
            rectanglePoints.Add(rectanglePoints.Last());
            graphics.DrawPointLines(pen, rectanglePoints);
        }

        public static void DrawBezier(this Graphics graphics, RainbowPen pen, Point p1, Point p2, Point p3, Point p4, int stepSize = 1)
        {
            var rectanglePoints = new List<Point> { p1, p2, p3, p4 };
            //var rectanglePoints = GeometryHelper.GetRectanglePoints(rect);
            rectanglePoints.Add(rectanglePoints.Last());
            graphics.DrawPointLines(pen, rectanglePoints);
        }

        public static void DrawPolygon(this Graphics graphics, RainbowPen pen, Point[] points, int stepSize = 1)
        {
            var rectanglePoints = new List<Point>();
            for (var x = 0; x < points.Length; x++)
            {
                if (x == points.Length - 1)
                {
                    rectanglePoints.AddRange(new LineSegment(points[x], points[0]).GetSegmentPointsAtDistance(stepSize));
                }
                else
                {
                    rectanglePoints.AddRange(new LineSegment(points[x], points[x + 1]).GetSegmentPointsAtDistance(stepSize));
                }    
            }

            graphics.DrawPointLines(pen, rectanglePoints);
        }

        public static void DrawEllipse(this Graphics graphics, RainbowPen pen, Rectangle rect, int stepSize = 1)
        {
            var ellipsePoints = GeometryHelper.GetEllipsePoints(rect);
            ellipsePoints.Add(ellipsePoints.Last());
            graphics.DrawPointLines(pen, ellipsePoints);
        }

        public static void FillRectangle(this Graphics graphics, RainbowBrush brush, Rectangle rect, BrushOrientation orientation, FillMode fillMode = FillMode.Repeat, int stepSize = 1)
        {
            using (var pen = new Pen(Color.Black, 1))
            {
                var color = brush.Color.Current;
                var iterations = orientation == BrushOrientation.Horizontal 
                    ? rect.Height 
                    : orientation == BrushOrientation.Vertical 
                        ? rect.Width 
                        : 0;

                var colors = fillMode != FillMode.Stretch
                    ? brush.Color.Colors
                    : ListHelper.FitListToSize(brush.Color.Colors, iterations);

                var bounce = false;
                for (var i = 0; i < iterations; i++)
                {
                    pen.Color = color;

                    if (orientation == BrushOrientation.Horizontal)
                    {
                        graphics.DrawLine(pen, new Point(rect.X, rect.Y + i), new Point(rect.X + rect.Width, rect.Y + i));
                    }
                    else if (orientation == BrushOrientation.Vertical)
                    {
                        graphics.DrawLine(pen, new Point(rect.X + i, rect.Y), new Point(rect.X + i, rect.Y + rect.Height));
                    }

                    if (fillMode == FillMode.Repeat)
                    {
                        color = brush.Color.Next;
                    }
                    else if (fillMode == FillMode.Bounce)
                    {
                        if (bounce)
                        {
                            if (brush.Color.Index == 0)
                            {
                                color = brush.Color.Next;
                                bounce = false;
                            }
                            else
                            {
                                color = brush.Color.Prev;
                            }
                        }
                        else
                        {
                            if (brush.Color.Index == brush.Color.Colors.Count - 1)
                            {
                                color = brush.Color.Prev;
                                bounce = true;
                            }
                            else
                            {
                                color = brush.Color.Next;
                            }
                        }
                    }
                    else if (fillMode == FillMode.Stretch)
                    {
                        if (i < colors.Count - 1)
                            color = colors[i + 1];
                    }
                }
            }
        }

        public static void FillEllipse(this Graphics graphics, RainbowBrush brush, Rectangle rect, BrushOrientation orientation, FillMode fillMode = FillMode.Repeat, int stepSize = 1)
        {
            var segments = GeometryHelper.GetEllipseSegments(rect, orientation);

            using (var pen = new Pen(Color.Black, 1))
            {
                var color = brush.Color.Current;

                var iterations = orientation == BrushOrientation.Horizontal
                    ? rect.Height
                    : orientation == BrushOrientation.Vertical
                        ? rect.Width
                        : 0;

                var colors = fillMode != FillMode.Stretch
                    ? brush.Color.Colors
                    : ListHelper.FitListToSize(brush.Color.Colors, iterations);

                var bounce = false;
                var counter = 0;

                foreach (var segment in segments)
                {
                    pen.Color = color;
                    graphics.DrawLine(pen, segment.P1, segment.P2);

                    if (fillMode == FillMode.Repeat)
                    {
                        color = brush.Color.Next;
                    }
                    else if (fillMode == FillMode.Bounce)
                    {
                        if (bounce)
                        {
                            if (brush.Color.Index == 0)
                            {
                                color = brush.Color.Next;
                                bounce = false;
                            }
                            else
                            {
                                color = brush.Color.Prev;
                            }
                        }
                        else
                        {
                            if (brush.Color.Index == brush.Color.Colors.Count - 1)
                            {
                                color = brush.Color.Prev;
                                bounce = true;
                            }
                            else
                            {
                                color = brush.Color.Next;
                            }
                        }
                    }
                    else if (fillMode == FillMode.Stretch)
                    {
                        if (++counter < colors.Count)
                            color = colors[counter];
                    }
                }
            }
        }

        private static void DrawPointLines(this Graphics graphics, RainbowPen pen, List<Point> points)
        {
            for (var x = 0; x < points.Count - 1; x++)
            {
                graphics.DrawLine(pen.Pen, points[x], points[x + 1]);
            }
        }
    }

    public enum FillMode
    {
        Repeat,
        Bounce,
        Stretch
    }
}

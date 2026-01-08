using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDrawingTools.Core
{
    public static class GeometryHelper
    {
        public static List<Point> GetRectanglePoints(Rectangle rect)
        {
            var sides = new List<List<Point>> { new List<Point>(), new List<Point>(), new List<Point>(), new List<Point>() };

            for (var x = rect.X; x < rect.X + rect.Width; x++)
            {
                sides[0].Add(new Point(x, rect.Y));
                sides[2].Insert(0, new Point(x, rect.Y + rect.Height));
            }
            for (var y = rect.Y; y < rect.Y + rect.Height; y++)
            {
                sides[1].Add(new Point(rect.X + rect.Width, y));
                sides[3].Insert(0, new Point(rect.X, y));
            }

            return sides[0].Concat(sides[1].Concat(sides[2].Concat(sides[3]))).Distinct().ToList();
        }

        public static List<Point> GetEllipsePoints(Rectangle rect, double angleStep = 1)
        {
            var halfWidth = rect.Width / 2;
            var halfHeight = rect.Height / 2;
            var centerPoint = new Point(rect.X + halfWidth, rect.Y + halfHeight);
            var quarters = new List<List<Point>> { new List<Point>(), new List<Point>(), new List<Point>(), new List<Point>() };

            for (var angle = 0.0; angle <= 90.0; angle += angleStep)
            {
                var sin = Math.Sin(angle * Math.PI / 180);
                var cos = Math.Cos(angle * Math.PI / 180);

                quarters[0].Add(new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
                quarters[1].Insert(0, new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[2].Add(new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[3].Insert(0, new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
            }

            return quarters[0].Concat(quarters[1].Concat(quarters[2].Concat(quarters[3]))).Distinct().ToList();
        }

        public static List<LineSegment> GetEllipseSegments(Rectangle rect, BrushOrientation orientation, double angleStep = 0.25)
        {
            var retval = new List<LineSegment>();

            var halfWidth = rect.Width / 2;
            var halfHeight = rect.Height / 2;
            var centerPoint = new Point(rect.X + halfWidth, rect.Y + halfHeight);
            var quarters = new List<List<Point>> { new List<Point>(), new List<Point>(), new List<Point>(), new List<Point>() };

            for (var angle = 0.0; angle <= 90.0; angle += angleStep)
            {
                var sin = Math.Sin(angle * Math.PI / 180);
                var cos = Math.Cos(angle * Math.PI / 180);

                quarters[0].Add(new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
                quarters[1].Add(new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[2].Add(new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[3].Add(new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
            }

            if (orientation == BrushOrientation.Horizontal)
            {
                for (var x = 0; x < quarters[0].Count; x++)
                {
                    retval.Add(new LineSegment(quarters[0][x], quarters[3][x]));

                    if (x < quarters[0].Count - 1)
                    {
                        if (quarters[0][x].Y + 1 < quarters[0][x + 1].Y)
                        {
                            var extraSegment = new LineSegment(
                                new Point(quarters[0][x].X, quarters[0][x].Y + 1),
                                new Point(quarters[3][x].X, quarters[3][x].Y + 1));

                            retval.Add(extraSegment);
                        }
                    }
                }
                for (var x = quarters[1].Count - 1; x > 0; x--)
                {
                    retval.Add(new LineSegment(quarters[1][x], quarters[2][x]));

                    if (x < quarters[1].Count - 1)
                    {
                        if (quarters[1][x].Y + 1 > quarters[1][x + 1].Y)
                        {
                            var extraSegment = new LineSegment(
                                new Point(quarters[1][x].X, quarters[1][x].Y - 1),
                                new Point(quarters[2][x].X, quarters[2][x].Y - 1));

                            retval.Add(extraSegment);
                        }
                    }
                }
            }
            else
            {
                quarters[2].Reverse();
                quarters[3].Reverse();

                for (var x = 0; x < quarters[3].Count; x++)
                {
                    retval.Add(new LineSegment(quarters[3][x], quarters[2][x]));

                    if (x < quarters[3].Count - 1)
                    {
                        if (quarters[3][x].X + 1 < quarters[3][x + 1].X)
                        {
                            var extraSegment = new LineSegment(
                                new Point(quarters[3][x].X + 1, quarters[3][x].Y),
                                new Point(quarters[2][x].X + 1, quarters[2][x].Y));

                            retval.Add(extraSegment);
                        }
                    }
                }
                for (var x = 0; x < quarters[0].Count; x++)
                {
                    retval.Add(new LineSegment(quarters[0][x], quarters[1][x]));

                    if (x < quarters[0].Count - 1)
                    {
                        if (quarters[0][x].X + 1 < quarters[0][x + 1].X)
                        {
                            var extraSegment = new LineSegment(
                                new Point(quarters[0][x].X + 1, quarters[0][x].Y),
                                new Point(quarters[1][x].X + 1, quarters[1][x].Y));

                            retval.Add(extraSegment);
                        }
                    }
                }
            }

            return retval;
        }

        public static List<LineSegment> GetEllipseSegmentsFunny(Rectangle rect, double angleStep = 0.25)
        {
            var retval = new List<LineSegment>();

            var halfWidth = rect.Width / 2;
            var halfHeight = rect.Height / 2;
            var centerPoint = new Point(rect.X + halfWidth, rect.Y + halfHeight);
            var quarters = new List<List<Point>> { new List<Point>(), new List<Point>(), new List<Point>(), new List<Point>() };

            for (var angle = 0.0; angle <= 90.0; angle += angleStep)
            {
                var sin = Math.Sin(angle * Math.PI / 180);
                var cos = Math.Cos(angle * Math.PI / 180);

                quarters[0].Add(new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
                quarters[1].Add(new Point(centerPoint.X + (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[2].Add(new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y + (int)(halfHeight * cos)));
                quarters[3].Add(new Point(centerPoint.X - (int)(halfWidth * sin), centerPoint.Y - (int)(halfHeight * cos)));
            }

            for (var x = 0; x < quarters[0].Count; x++)
            {
                retval.Add(new LineSegment(quarters[0][x], quarters[1][quarters[1].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[0][x], quarters[2][quarters[2].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[0][x], quarters[3][quarters[3].Count - 1 - x]));
            }
            for (var x = 0; x < quarters[1].Count; x++)
            {
                retval.Add(new LineSegment(quarters[1][x], quarters[0][quarters[0].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[1][x], quarters[2][quarters[2].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[1][x], quarters[3][quarters[3].Count - 1 - x]));
            }
            for (var x = 0; x < quarters[2].Count; x++)
            {
                retval.Add(new LineSegment(quarters[2][x], quarters[0][quarters[0].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[2][x], quarters[1][quarters[1].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[2][x], quarters[3][quarters[3].Count - 1 - x]));
            }
            for (var x = 0; x < quarters[3].Count; x++)
            {
                retval.Add(new LineSegment(quarters[3][x], quarters[0][quarters[0].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[3][x], quarters[1][quarters[1].Count - 1 - x]));
                retval.Add(new LineSegment(quarters[3][x], quarters[2][quarters[2].Count - 1 - x]));
            }

            return retval;
        }

        public static List<LineSegment> GetEllipseSegments2(Rectangle rect, BrushOrientation orientation, double angleStep = 0.25)
        {
            var retval = new List<LineSegment>();

            var points = GetEllipsePoints(rect, angleStep);

            if (orientation == BrushOrientation.Horizontal)
            {

            }
            else if (orientation == BrushOrientation.Vertical)
            {

            }


            return retval;
        }
    }
}

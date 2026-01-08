using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public class LineSegment
    {
        #region Private members

        private Point _p1;
        private Point _p2;
        private double _length;

        #endregion

        #region Public properties

        public Point P1
        {
            get => _p1;
            set
            {
                if (_p1 != value)
                {
                    _p1 = value;
                    _length = GetSegmentLength();
                }
            }
        }
        public Point P2
        {
            get => _p2;
            set
            {
                if (_p2 != value)
                {
                    _p2 = value;
                    _length = GetSegmentLength();
                }
            }
        }
        public double Length => _length;

        #endregion

        #region Constructors

        public LineSegment()
        {
            _p1 = new Point(0, 0);
            _p2 = new Point(0, 0);
            _length = 0.0;
        }
        public LineSegment(Point p1, Point p2)
        {
            _p1 = p1;
            _p2 = p2;
            _length = GetSegmentLength();
        }
        public LineSegment(int x1, int y1, int x2, int y2)
        {
            _p1 = new Point(x1, y1);
            _p2 = new Point(x2, y2);
            _length = GetSegmentLength();
        }

        #endregion

        #region Public methods

        public Point GetSegmentPointAtDistance(double distance)
        {
            return new Point(
                (int)(P1.X + (distance * (P2.X - P1.X) / Length)),
                (int)(P1.Y + (distance * (P2.Y - P1.Y) / Length))
            );
        }

        public List<Point> GetSegmentPointsAtDistance(double distance)
        {
            var points = new List<Point>();
            points.Add(P1);

            if (distance > Length)
            {
                return points;
            }

            var count = (int)(Length / distance);
            for (var i = 1; i <= count; i++)
            {
                points.Add(GetSegmentPointAtDistance(distance * i));
            }

            return points;
        }

        #endregion

        #region Private methods

        private double GetSegmentLength()
        {
            return Math.Sqrt(Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2));
        }

        #endregion
    }
}
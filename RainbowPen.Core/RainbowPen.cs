using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public class RainbowPen
    {
        #region Private members

        private Pen _pen;
        private RainbowColor _color;

        #endregion

        #region Public properties

        public Pen Pen
        {
            get
            {
                _pen.Color = GetNextColor();
                return _pen;
            }
        }

        public float Width
        {
            get => _pen.Width;
            set => _pen.Width = value;
        }

        #endregion

        #region Constructors

        public RainbowPen()
        {
            _color = new RainbowColor(true);
            _pen = new Pen(_color.Current, 1);
        }
        public RainbowPen(int width, int colorStepSize = 1)
        {
            _color = new RainbowColor(colorStepSize, true);
            _pen = new Pen(_color.First, width);
        }
        public RainbowPen(int width, List<Color> colors)
        {
            _color = new RainbowColor(colors);
            _pen = new Pen(_color.Current, width);
        }
        public RainbowPen(int width, List<Color> colors, int colorStepSize)
        {
            _color = new RainbowColor(colors, colorStepSize, true);
            _pen = new Pen(_color.Current, width);
        }

        #endregion

        #region Public methods

        #endregion

        #region Private methods

        private Color GetNextColor()
        {
            return _color.Next;
        }

        #endregion
    }
}

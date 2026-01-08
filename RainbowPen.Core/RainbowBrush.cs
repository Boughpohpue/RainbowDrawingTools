using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public class RainbowBrush
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

        public RainbowColor Color => _color;

        #endregion

        #region Constructors

        public RainbowBrush(int colorStepSize = 1)
        {
            _color = new RainbowColor(colorStepSize, true);
            _pen = new Pen(_color.First, 1);
        }
        public RainbowBrush(List<Color> colors)
        {
            _color = new RainbowColor(colors);
            _pen = new Pen(_color.Current, 1);
        }
        public RainbowBrush(List<Color> colors, int colorStepSize)
        {
            _color = new RainbowColor(colors, colorStepSize, true);
            _pen = new Pen(_color.Current, 1);
        }

        #endregion

        #region Private methods

        private Color GetNextColor()
        {
            return _color.Next;
        }

        #endregion
    }

    public enum BrushOrientation
    {
        Diagonal,
        Vertical,
        Horizontal,        
    }
}

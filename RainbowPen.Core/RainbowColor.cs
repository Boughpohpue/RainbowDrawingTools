using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public class RainbowColor
    {
        #region Private members

        private int _index = 0;
        private List<Color> _colors;

        #endregion

        #region Public properties

        public int Index => _index;
        public List<Color> Colors => _colors;
        public Color Current => _colors[_index];
        public Color First => _colors.First();
        public Color Last => _colors.Last();
        public Color Next
        {
            get
            {
                _index++;
                if (_index == _colors.Count)
                {
                    _index = 0;
                }

                return Current;
            }
        }
        public Color Prev
        {
            get
            {
                _index--;
                if (_index == -1)
                {
                    _index = _colors.Count - 1;
                }

                return Current;
            }
        }

        #endregion

        #region Constructors

        public RainbowColor(bool withEndToStartTransition = false)
        {
            _colors = ColorHelper.GetRainbowColors(1, withEndToStartTransition);
        }
        public RainbowColor(int step, bool withEndToStartTransition = false)
        {
            _colors = ColorHelper.GetRainbowColors(step, withEndToStartTransition);
        }
        public RainbowColor(List<Color> colors, int step, bool withEndToStartTransition = false)
        {
            _colors = ColorHelper.GetTransitionColors(colors, step, withEndToStartTransition);
        }
        public RainbowColor(List<Color> colors)
        {
            _colors = colors;
        }

        #endregion

        #region Public methods

        public void Reset()
        {
            SetToFirst();
        }
        public void SetToFirst()
        {
            _index = 0;
        }
        public void SetToLast()
        {
            _index = _colors.Count - 1;
        }
        public void SetCurrentIndex(int index)
        {
            if (index < 0 || index >= _colors.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _index = index;
        }
        public void SetCurrentColor(Color c)
        {
            var index = _colors.IndexOf(c);

            if (index == -1)
            {
                var mostSimilar = ColorHelper.GetMostSimilarColor(_colors, c);

                index = _colors.IndexOf(mostSimilar);
            }

            SetCurrentIndex(index);
        }
        public void SetCurrentColor(int r, int g, int b)
        {
            SetCurrentColor(Color.FromArgb(r, g, b));
        }

        #endregion
    }
}

using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public static class ColorHelper
    {
        public const int MinStepSize = 1;
        public const int MaxStepSize = 25;
        public const double MinOpacity = 0.0;
        public const double MaxOpacity = 1.0;

        public static List<Color> GetRainbowColors(int stepSize = 1, bool includeEndToStart = false, double opacity = 1.0)
        {
            if (stepSize < MinStepSize || stepSize > MaxStepSize)
            {
                throw new ArgumentOutOfRangeException(nameof(stepSize));
            }
            if (opacity < MinOpacity || opacity > MaxOpacity)
            {
                throw new ArgumentOutOfRangeException(nameof(opacity));
            }

            var retval = new List<Color>();

            var min = 0;
            var max = 255;
            var r = max;
            var g = min;
            var b = min;
            var alpha = (int)(max * opacity);


            for (var x = min; x < max; x += stepSize)
            {
                g = x;
                if (g > max)
                    g = max;

                retval.Add(Color.FromArgb(alpha, r, g, b));
            }
            for (var x = max; x > min; x -= stepSize)
            {
                r = x;
                if (r < min)
                    r = min;

                retval.Add(Color.FromArgb(alpha, r, g, b));
            }
            for (var x = min; x < max; x += stepSize)
            {
                b = x;
                if (b > max)
                    b = max;

                retval.Add(Color.FromArgb(alpha, r, g, b));
            }
            for (var x = max; x > min; x -= stepSize)
            {
                g = x;
                if (g < min)
                    g = min;

                retval.Add(Color.FromArgb(alpha, r, g, b));
            }
            for (var x = min; x < max; x += stepSize)
            {
                r = x;
                if (r > max)
                    r = max;

                retval.Add(Color.FromArgb(alpha, r, g, b));
            }

            if (includeEndToStart)
            {
                for (var x = b; x > min; x -= stepSize)
                {
                    b = x;
                    if (b < min)
                        b = min;

                    retval.Add(Color.FromArgb(alpha, r, g, b));
                }
            }

            return retval;
        }

        public static List<Color> GetTransitionColors(Color c1, Color c2, int stepSize = 1, double opacity = 1.0)
        {
            if (c1 == c2)
            {
                return new List<Color> { c1 };
            }
            if (stepSize < MinStepSize || stepSize > MaxStepSize)
            {
                throw new ArgumentOutOfRangeException(nameof(stepSize));
            }
            if (opacity < MinOpacity || opacity > MaxOpacity)
            {
                throw new ArgumentOutOfRangeException(nameof(opacity));
            }

            var redValues = ListHelper.GenerateList(c1.R, c2.R, stepSize).Where(r => r >= 0 && r <= 255).ToList();
            var greenValues = ListHelper.GenerateList(c1.G, c2.G, stepSize).Where(g => g >= 0 && g <= 255).ToList();
            var blueValues = ListHelper.GenerateList(c1.B, c2.B, stepSize).Where(b => b >= 0 && b <= 255).ToList();
            var max = new List<int> { redValues.Count, greenValues.Count, blueValues.Count }.Max();

            var retval = new List<Color>();

            var redIndex = 0;
            var greenIndex = 0;
            var blueIndex = 0;
            for (var i = 0; i < max; i++)
            {
                retval.Add(Color.FromArgb(255, redValues[redIndex], greenValues[greenIndex], blueValues[blueIndex]));

                if (redIndex < redValues.Count - 1)
                {
                    redIndex++;
                    retval.Add(Color.FromArgb(255, redValues[redIndex], greenValues[greenIndex], blueValues[blueIndex]));
                }

                if (greenIndex < greenValues.Count - 1)
                {
                    greenIndex++;
                    retval.Add(Color.FromArgb(255, redValues[redIndex], greenValues[greenIndex], blueValues[blueIndex]));
                }

                if (blueIndex < blueValues.Count - 1)
                {
                    blueIndex++;
                    retval.Add(Color.FromArgb(255, redValues[redIndex], greenValues[greenIndex], blueValues[blueIndex]));
                }
            }

            return retval;
        }

        public static List<Color> GetTransitionColors(List<Color> colors, int stepSize, bool withEndToStartTransition = false, double opacity = 1.0)
        {
            if (colors == null)
            {
                throw new ArgumentNullException(nameof(colors));
            }
            if (colors.Count < 2)
            {
                throw new ArgumentException($"Argument {nameof(colors)} must contain at least two elements!");
            }

            var retval = new List<Color>();

            for (var x = 0; x < colors.Count - 1; x++)
            {
                retval.AddRange(GetTransitionColors(colors[x], colors[x + 1], stepSize, opacity));
            }

            if (withEndToStartTransition && colors.Last() != colors.First())
            {
                retval.AddRange(GetTransitionColors(colors.Last(), colors.First(), stepSize, opacity));
            }

            return retval;
        }

        public static Color GetMostSimilarColor(List<Color> colors, Color color)
        {
            if (colors == null)
            {
                throw new ArgumentNullException(nameof(colors));
            }
            if (colors.Count < 2)
            {
                throw new ArgumentException($"{nameof(colors)} must contain at least two element!");
            }

            var retval = colors.First();
            if (retval == color)
            {
                return retval;
            }

            foreach (var c in colors.Skip(1))
            {
                if (c == color)
                {
                    retval = color;
                    break;
                }

                if (Math.Abs(GetColorTotal(c) - GetColorTotal(color)) < Math.Abs(GetColorTotal(retval) - GetColorTotal(color))
                    && Math.Abs(c.R - color.R) <= Math.Abs(retval.R - color.R) 
                    && Math.Abs(c.G - color.G) <= Math.Abs(retval.G - color.G) 
                    && Math.Abs(c.B - color.B) <= Math.Abs(retval.B - color.B))
                {
                    retval = c;
                }
            }

            return retval;
        }

        private static int GetColorTotal(Color c)
        {
            return c.R + c.G + c.B;
        }
    }
}

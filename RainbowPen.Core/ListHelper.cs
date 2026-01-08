using System.Drawing;

namespace RainbowDrawingTools.Core
{
    public static class ListHelper
    {
        public static List<int> GenerateList(int startValue, int stopValue, int stepSize = 1)
        {
            if (startValue == stopValue)
            {
                return new List<int> { startValue };
            }

            var retval = new List<int>();

            if (startValue < stopValue)
            {
                for (var x = startValue; x <= stopValue; x += stepSize)
                {
                    retval.Add(x);
                }
            }
            else
            {
                for (var x = startValue; x >= stopValue; x -= stepSize)
                {
                    retval.Add(x);
                }
            }

            if (retval.Last() != stopValue)
            {
                retval.Add(stopValue);
            }

            return retval;
        }

        public static List<Color> FitListToSize(List<Color> list, int size)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (list.Count == 0)
            {
                throw new ArgumentException($"{nameof(list)} must contain items!");
            }
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than 0!");
            }
            if (list.Count == size)
            {
                return list;
            }

            var diff = list.Count - size;

            var retval = new List<Color>();
            retval.AddRange(list);

            var ratio = 0.5;
            var startRatio = 0.5;
            var endRatio = 1.0;
            while (retval.Count != size)
            {
                for (var r = startRatio; r < endRatio; r += ratio)
                {
                    var index = (int)(retval.Count * r);
                    if (index >= retval.Count)
                        index = retval.Count - 1;

                    if (diff > 0)
                    {
                        retval.RemoveAt(index);
                    }
                    else
                    {
                        var item = retval[index];
                        retval.Insert(index, item);
                    }

                    if (retval.Count == size)
                    {
                        break;
                    }

                    index = (int)(retval.Count - (retval.Count * r));
                    if (index >= retval.Count)
                        index = retval.Count - 1;

                    if (diff > 0)
                    {
                        retval.RemoveAt(index);
                    }
                    else
                    {
                        var item = retval[index];
                        retval.Insert(index, item);
                    }

                    if (retval.Count == size)
                    {
                        break;
                    }
                }

                ratio /= 2;

                startRatio = startRatio == 0.0
                    ? ratio
                    : 0.0;

                endRatio = endRatio == 1.0
                    ? 1.0 - ratio
                    : 1.0;
            }

            return retval;
        }
    }
}

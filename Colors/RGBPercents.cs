using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Colors
{
    internal class RGBPercents
    {
        public RGBPercents(Color color)
        {
            R = color.R/255F;
            G = color.G/255F;
            B = color.B/255F;

            _Percents = new List<float>();
            _Percents.Add(R);
            _Percents.Add(G);
            _Percents.Add(B);
        }

        readonly List<float> _Percents;
        public float B;
        public float G;
        public float R;

        public float GetMin()
        {
            return _Percents.Min();
        }

        public float GetMax()
        {
            return _Percents.Max();
        }
    }
}
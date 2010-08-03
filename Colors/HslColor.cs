using System.Windows.Media;

namespace Colors
{
    public class HslColor
    {
        public HslColor(float h, float s, float l)
        {
            H = h;
            S = s;
            L = l;
        }

        public float H { get; private set; }
        public float S { get; private set; }
        public float L { get; private set; }

        public static HslColor RGBtoHSL(Color color)
        {
            var originalPercents = new RGBPercents(color);

            float minPct = originalPercents.GetMin();
            float maxPct = originalPercents.GetMax();

            float maxMinDiff = maxPct - minPct;

            float h = 0.0F;
            float s = 0.0F;
            float l = (minPct + maxPct) / 2.0F;

            if (maxMinDiff == 0.0F)
            {
                return new HslColor(0.0F, 0.0F, l);
            }

            s = (l < 0.5F)
                    ? maxMinDiff / (minPct + maxPct)
                    : maxMinDiff / (2.0F - minPct - maxPct);

            float deltaR = GetDeltaPercent(originalPercents.R, maxPct, maxMinDiff);
            float deltaG = GetDeltaPercent(originalPercents.G, maxPct, maxMinDiff);
            float deltaB = GetDeltaPercent(originalPercents.B, maxPct, maxMinDiff);

            if (originalPercents.R == maxPct)
            {
                h = deltaB - deltaG;
            }
            else if (originalPercents.G == maxPct)
            {
                h = (1.0F / 3.0F) + deltaR - deltaB;
            }
            else if (originalPercents.B == maxPct)
            {
                h = (2.0F / 3.0F) + deltaG - deltaR;
            }

            if (h < 0.0F)
            {
                h += 1.0F;
            }

            if (h > 1.0F)
            {
                h -= 1.0F;
            }

            return new HslColor(h, s, l);
        }

        static float GetDeltaPercent(float originalPercent, float maxPct, float maxMinDiff)
        {
            return (((maxPct - originalPercent) / 6.0F) + (maxMinDiff / 2.0F)) / maxPct;
        }

        public HslColor GetOppositeHue()
        {
            var h = H + 0.5F;

            if (h > 1.0F)
                h -= 1.0F;

            return new HslColor(h, S, L);
        }

        public Color ToRGB()
        {
            if (S == 0.0F)
                return Color.FromRgb((byte)(L * 255F), 0, 0);

            float var2 = (L < 0.5F)
                             ? L * (1.0F + S)
                             : (L + S) - (S * L);

            float var1 = (2.0F * L) - var2;

            var r = (byte)(255.0F * GetColorComponent(var1, var2, H + (1.0F / 3.0F)));
            var g = (byte)(255.0F * GetColorComponent(var1, var2, H));
            var b = (byte)(255.0F * GetColorComponent(var1, var2, H - (1.0F / 3.0F)));
            var a = (byte)0xFF;

            return Color.FromArgb(a, r, g, b);
        }

        static float GetColorComponent(float var1, float var2, float newHue)
        {
            if (newHue < 0.0F)
            {
                newHue += 1.0F;
            }

            if (newHue > 1.0F)
            {
                newHue -= 1.0F;
            }

            if ((6.0F * newHue) < 1.0F)
                return var1 + ((var2 - var1) * 6.0F) * newHue;

            if ((2.0F * newHue) < 1.0F)
                return var2;

            if ((3.0F * newHue) < 2.0F)
                return var1 + (var2 - var1) * ((2.0F / 3.0F - newHue) * 6.0F);

            return var1;
        }
    }
}

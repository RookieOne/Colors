using System.Windows.Media;

namespace Colors
{
    public static class ComplementaryColorExtension
    {
        public static Color GetComplementary(this Color color)
        {
            return HslColor.RGBtoHSL(color)
                .GetOppositeHue()
                .ToRGB();
        }
    }
}
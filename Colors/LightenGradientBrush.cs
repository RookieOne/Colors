using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Colors
{
    public class LightenGradientBrush : MarkupExtension
    {
        public Color Color { get; set; }

        public float LightFactor { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.5, 0),
                                EndPoint = new Point(0.5, 1)
                            };
            var stop1 = new GradientStop(Color, 0);

            var lightenColor = Color.Lighten(LightFactor);
            var stop2 = new GradientStop(lightenColor, 1);

            brush.GradientStops.Add(stop1);
            brush.GradientStops.Add(stop2);

            return brush;
        }
    }
}
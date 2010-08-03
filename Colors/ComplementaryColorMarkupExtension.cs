using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace Colors
{
    public class ComplementaryColorMarkupExtension : MarkupExtension
    {
        public Color Of { get; set; }
        public string As { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var color = Of.GetComplementary();

            if (As == "Brush")
                return new SolidColorBrush(color);

            return color;
        }
    }
}
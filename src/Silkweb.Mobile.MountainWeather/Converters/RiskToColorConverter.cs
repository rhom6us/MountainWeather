using System;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.Models;

namespace Silkweb.Mobile.MountainWeather.Converters
{
    public class RiskToColorConverter : IValueConverter
    {
        public Color HighColor { get; set; }

        public Color MediumColor { get; set; }

        public Color LowColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Risk))
                return Color.Default;

            var risk = (Risk)value;

            switch (risk)
            {
                case Risk.High:
                    return HighColor;
                case Risk.Medium:
                    return MediumColor;
                case Risk.Low:
                    return LowColor;
                default:
                    return Color.Default;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}


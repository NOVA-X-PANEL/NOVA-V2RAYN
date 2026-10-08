using System.Windows.Media;

namespace v2rayN.Converters;

public class DelayColorConverter : IValueConverter
{
    private static readonly SolidColorBrush FastBrush = new(Color.FromRgb(0x00, 0xE6, 0x76));    // Neon Emerald
    private static readonly SolidColorBrush MediumBrush = new(Color.FromRgb(0x00, 0xF0, 0xFF));  // Neon Cyan
    private static readonly SolidColorBrush SlowBrush = new(Color.FromRgb(0xFF, 0xB8, 0x00));    // Neon Amber
    private static readonly SolidColorBrush TimeoutBrush = new(Color.FromRgb(0xFF, 0x17, 0x44)); // Neon Red

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var delay = value.ToString().ToInt();

        return delay switch
        {
            <= 0 => TimeoutBrush,
            <= 300 => FastBrush,
            <= 600 => MediumBrush,
            <= 1000 => SlowBrush,
            _ => TimeoutBrush
        };
    }

    public object? ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return null;
    }
}

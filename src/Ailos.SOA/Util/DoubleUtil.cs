namespace Ailos.SOA.Util
{
    public static class DoubleUtil
    {
        public static string Format(this double? value, string format)
        {
            return value.HasValue ? value.Value.Format(format) : null;
        }

        public static string Format(this double value, string format)
        {
            return value.ToString(format);
        }

        public static string FormatBRL(this double? value)
        {
            return value.HasValue ? value.Value.FormatBRL() : null;
        }

        public static string FormatBRL(this double value)
        {
            return string.Format("R$ {0}", value.ToString("N"));
        }

        public static string FormatPercent(this double? value)
        {
            return value.HasValue ? value.Value.FormatPercent() : null;
        }

        public static string FormatPercent(this double value)
        {
            return value.ToString("N") + "%";
        }
    }
}
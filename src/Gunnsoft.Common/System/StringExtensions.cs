namespace Gunnsoft.Common.System
{
    public static class StringExtensions
    {
        public static string AsNullIfEmpty(this string extended)
        {
            return string.IsNullOrEmpty(extended) ? null : extended;
        }

        public static string AsNullIfWhiteSpace(this string extended)
        {
            return string.IsNullOrWhiteSpace(extended) ? null : extended;
        }
    }
}

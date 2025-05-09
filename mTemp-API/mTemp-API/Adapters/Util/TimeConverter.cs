namespace mTemp_API.Adapters.Util
{
    public static class TimeConverter
    {
        /// <summary>
        /// Converts a DateTime to UNIX milliseconds.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <returns>The UNIX milliseconds representation of the DateTime.</returns>
        public static long ToUnixMilliseconds(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// converts UNIX milliseconds to a DateTime.
        /// </summary>
        /// <param name="unixMilliseconds"> The UNIX milliseconds to convert.</param>
        /// <returns>The DateTime representation of the UNIX milliseconds.</returns>
        public static DateTime FromUnixMilliseconds(long unixMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds).UtcDateTime;
        }
    }

}
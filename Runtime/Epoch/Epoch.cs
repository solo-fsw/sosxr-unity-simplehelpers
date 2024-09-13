using System;


namespace SOSXR.SimpleHelpers
{
    /// <summary>
    ///     This deals with all time variables. It allows the programmer to get / set all times to milliseconds, which is
    ///     stored as a 'long' variable. You can also get the time as a string, with any desired formatting rule applied.
    ///     Standard formatting is also a viable option. Will be set to local time!
    /// </summary>
    public static class Epoch
    {
        public static long GetCurrentLocalTimeInMS()
        {
            return DateTimeOffset.Now.ToLocalTime().ToUnixTimeMilliseconds();
        }


        public static string GetCurrentLocalTimeAsString(string formatting = "dd/MM/yyyy HH:mm:ss.fff")
        {
            var t = DateTimeOffset.FromUnixTimeMilliseconds(GetCurrentLocalTimeInMS()).DateTime.ToLocalTime().ToString(formatting);

            return t;
        }


        public static string GetAsString(long epoch, string formatting = "dd/MM/yyyy HH:mm:ss.fff")
        {
            var epochAsString = DateTimeOffset.FromUnixTimeMilliseconds(epoch).ToLocalTime().ToString(formatting);

            return epochAsString;
        }


        public static string GetAsString(double epoch, string formatting = "dd/MM/yyyy HH:mm:ss.fff")
        {
            var longEpoch = (long) epoch;

            return GetAsString(longEpoch, formatting);
        }
    }
}
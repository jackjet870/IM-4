using System.Text;

namespace HttpFramework
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Convert a byte array suitable for transmitting over the internet (UTF-8) into a string
        /// </summary>
        /// <param name="webBytes"></param>
        /// <returns></returns>
        public static string WebBytesToString(this byte[] webBytes) => Encoding.UTF8.GetString(webBytes);

        /// <summary>
        /// Convert a string into a byte array suitable for transmitting over the internet (UTF-8)
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <returns></returns>
        public static byte[] ToWebBytes(this string stringToConvert) => Encoding.UTF8.GetBytes(stringToConvert);
    }
}

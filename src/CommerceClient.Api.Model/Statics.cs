using System.Globalization;

namespace CommerceClient.Api.Model
{
    public static class Statics
    {
        public static readonly NumberStyles ConfigNumberStyles = NumberStyles.Any;

        /// <summary>
        /// Gets a number format info matching numbers stored in configuration files.
        /// </summary>
        public static readonly NumberFormatInfo ConfigNumberFormat =
            NumberFormatInfo.InvariantInfo;
    }
}
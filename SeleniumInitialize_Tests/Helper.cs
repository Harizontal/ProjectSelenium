using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Tests
{
    public static class Helper
    {
        /// <summary>
        /// Преобразует RGBA форммат в HEX
        /// </summary>
        /// <returns>Преобразованная строка в формате HEX</returns>
        public static string RgbaToHex(string rgbaColor)
        {
            rgbaColor = rgbaColor.Substring(5, rgbaColor.Length - 6);
            string[] parts = rgbaColor.Split(',');

            int red = int.Parse(parts[0].Trim());
            int green = int.Parse(parts[1].Trim());
            int blue = int.Parse(parts[2].Trim());

            return string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAutomation.Framework.Utils
{
    public class StringUtils
    {
        public static string RandomAlphaNumeric(int length = 10)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

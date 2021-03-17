using System;
using System.IO;
using TestAutomationAcceptance.Enums;

namespace TestAutomationAcceptance.Helpers
{
    public static class HelperExtenstions
    {
        public static Field ToField(this string property) => (Field) Enum.Parse(typeof(Field), property);

        public static string GetFilePath(this string fileName) => $"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}\\{fileName}";


    }
}

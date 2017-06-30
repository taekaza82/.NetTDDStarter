using System;

namespace MyLibrary
{
    public class Slip
    {
        public Slip()
        {
        }

        public string[] GetPrintedSlip(string printType, string formName)
        {
            var forms = formName.Split('|');
            return forms;
        }
    }

    public static class PrintType
    {
        public static string ClaimInsured = "10";
        public static string ClaimThirdParty = "20";
        public static string ClaimAsset = "30";
        public static string ClaimInjury = "40";
    }
}
using System;

namespace MyLibrary
{
    public class DayHelper
    {
        public DayHelper()
        {
        }

        public string ToFriendlyText(int[] input)
        {
            foreach(var day in input)
            {
                if (day < 1 || day > 31)
                    throw new InvalidDayException();
            }

            string result = "";
            if (input.Length > 1)
            {
                int? curentItem = null;
                result = input[0].ToString();
                for(int i = 0;i < input.Length; i++)
                {
                    if (curentItem == null)                       
                        curentItem = input[i];
                    else
                    {
                        if ((input[i] - curentItem) > 1)
                            result = result + "-" + curentItem;

                        curentItem = input[i];
                    }                    
                }
                result = result + " and " + input[input.Length - 1];
            }
            else if (input.Length == 1)
                result =  input[0].ToString();
            else
                result = "";

            return result;
        }
    }
}
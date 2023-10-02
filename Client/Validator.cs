using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public static class Validator
    {
        public static bool IsCorrectPrice(ref string price)
        {
            price = price.Replace('.', ',');
            try
            {
                float temp = float.Parse(price);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsCorrectString(string str)
        {
            return (str.Length > 0);
        }
        public static bool IsCorrectDate(ref string date)
        {
            date = date.Replace(',', '.');
            date = date.Replace(' ', '.');
            date = date.Replace('/', '.');
            date = date.Replace('-', '.');
            try
            {
                DateTime dummy = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
         }
        public static bool IsCorrectBool(ref string str)
        {
            str = str.ToLower();
            if (str == "да")
            {
                str = "true";
                return true;
            }
            else if (str == "нет")
            {
                str = "false";
                return true;
            }
            else return false;
        }

    }
}

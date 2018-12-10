using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Useful
    {
        public static bool IsNumeric(string varString)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(varString), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static int ConvertLetterRowToNumber(string varLetter)
        {
            int varNum = 0;
            switch (varLetter.ToLower())
            {
                case "a":
                    varNum = 1;
                    break;
                case "b":
                    varNum = 2;
                    break;
                case "c":
                    varNum = 3;
                    break;
                case "d":
                    varNum = 4;
                    break;
                case "e":
                    varNum = 5;
                    break;
                case "f":
                    varNum = 6;
                    break;
                case "g":
                    varNum = 7;
                    break;
                case "h":
                    varNum = 8;
                    break;

                default:
                    break;
            }

            return varNum;
        }

        public static List<T> MessUpList<T>(List<T> input)
        {
            List<T> arr = input;
            List<T> arrDes = new List<T>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;
        }

    }
}

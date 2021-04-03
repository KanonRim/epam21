
using System.Text;

namespace task1._2
{
    public  class ProgramBase
    {
        public static string VALIDATOR(string str)
        {
            StringBuilder newStr = new StringBuilder(str);
            newStr[0] = char.ToUpper(newStr[0]);
            for (int i = 0; i < newStr.Length - 2; i++)
            {

                if ((newStr[i] == '.' || newStr[i] == '?' || newStr[i] == '!') && newStr[i + 1] == ' ')
                {
                    newStr[i + 2] = char.ToUpper(newStr[i + 2]);
                }
            }
            return newStr.ToString();

        }
    }
}
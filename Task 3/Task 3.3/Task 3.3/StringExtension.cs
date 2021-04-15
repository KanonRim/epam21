using System;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    static class StringExtension
    {
        [Flags]
        enum Language
        {
            Null = 0,
            Rus = 1,
            Eng=  2,
            Mix=4,
            Num=8,

        }
        public static string GetLanguageStr(this string text)
        {

            Language language = Language.Null;

            Regex Rus = new Regex(@"[а-я|ё]", RegexOptions.IgnoreCase);
            Regex Eng = new Regex(@"[a-z]", RegexOptions.IgnoreCase);
            Regex Num = new Regex(@"[0-9]", RegexOptions.IgnoreCase);
          
            if (Rus.Match(text).Length > 0)            
                language ^=Language.Rus;
            if (Eng.Match(text).Length > 0)
                language ^= Language.Eng;
            if (Num.Match(text).Length > 0)
                language ^= Language.Num;   
                
            switch (language)
            {
                case Language.Null:
                        return null;
                case Language.Rus:
                    return "Russian";
                case Language.Eng:
                    return "English";
                case Language.Num:
                    return "Number";
                default:
                    return "Mix";
            }

        } 
    }    
}
    
        


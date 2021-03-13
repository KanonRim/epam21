using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class MegaString
    {
        private char[] _ch;
        
        MegaString(char[] mas)
        {
            Symbol = mas;
        }
        MegaString(string str)
        {
            Symbol = str.ToCharArray();
        }

        public char[] Symbol
        {
            get
            {
                return _ch;
            }
            set 
            {
                _ch = value;
            }
        }

        private int lenght;

        public int Lenght
        {
            get { return _ch.Length; }            
        }


        public static bool operator ==(MegaString str1, MegaString srt2)
        {
            if (str1.Lenght != srt2.Lenght)
            {
                return false;
            }
            else
            {
                return str1._ch == srt2._ch;
            }
        }
        public static bool operator !=(MegaString str1, MegaString srt2)
        {
            if (str1.Lenght == srt2.Lenght)
            {
                return false;
            }
            else
            {
                return str1._ch != srt2._ch;
            }
        }

        public static MegaString operator +(MegaString str1, MegaString str2)
        {
            return new MegaString(str1.Symbol.ToString() + str2.Symbol.ToString());
        }


        public int IndexOfMas(char ch)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_ch[i] == ch)
                    return i;
                
            }
            return -1;

        }
        public char[] ToCharArr()
        {
            return _ch;
        }
    }
}

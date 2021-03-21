using System;

namespace Task_2._1
{
    // task 1
    class MegaString
    {
        private char[] _ch;

        public MegaString(char[] mas)
        {
            Symbol = mas;
        }
        public MegaString(string str)
        {
            Symbol = str.ToCharArray();
        }

        public override string ToString()
        {
            return new String(_ch);
        }

        public char[] Symbol
        {
            get
            {
                return  (char[])_ch.Clone();
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
            return new MegaString(str1.ToString() + str2.ToString());
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

        //new
        public MegaString ToConsoleCenter(int Width = 125)
        {
            string leftSpace = new string(' ', (Width / 2) - (Lenght / 2));
            return new MegaString(leftSpace + ToString());
        }
    }

}

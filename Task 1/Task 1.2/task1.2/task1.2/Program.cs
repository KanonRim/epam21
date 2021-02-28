using System;

namespace task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Averages("Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате"));
        }

        static double Averages(string str)
        {
            
            int divider = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsPunctuation(str[i]) || str[i]==' ')
                {
                    divider++;
                }
            }
            return (str.Length-divider) / (divider-);
        }
    }
}

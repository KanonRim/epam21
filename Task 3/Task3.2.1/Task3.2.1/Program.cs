using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1;

namespace Task3._2._1_
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string[] wordArr, wordUnique;
            Input(out wordArr, out wordUnique);

            WordInText[] wordInTexts = new WordInText[wordUnique.Length];
            for (int i = 0; i < wordUnique.Length; i++)
            {
                wordInTexts[i].Word = wordUnique[i];
                wordInTexts[i].Count = CountWord(wordArr, wordInTexts[i].Word);
            }
            WordInTextSort(wordInTexts);

            for (int i = 0; i < wordInTexts.Length; i++)
            {            
                Console.WriteLine($"Количество использований  {wordInTexts[i].Count}  слова \"{wordInTexts[i].Word}\"");
                if (i == 10)
                {
                    if (!ConsoleHelper.YesOrNo("Показать остальные? "))
                    {
                        break;
                    }
                }
            }

        }

        private static void Input(out string[] wordArr, out string[] wordUnique)
        {
            
            string text = Console.ReadLine();
            char[] separators = { ' ', '/', '.', '_', '-', ',', ')', '(', ']', '[', '<', '>' };

            wordArr = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordArr.Length; i++)
            {
                wordArr[i] = wordArr[i].ToLower();
            }
            wordUnique = wordArr.Distinct().ToArray();
        }

        struct WordInText
        {
           public int Count;
           public  string Word;
        }

        static int CountWord(string[] wordArr, string word)
        {
            int Count = 0;
            foreach (var item in wordArr)
            {
                if (item.ToUpper() == word.ToUpper())
                {
                    Count++;
                }
            }
            return Count;
        }

        static void WordInTextSort(WordInText[] wordIns)
        {
            for (int i = 0; i < wordIns.Length; i++)
            {
                for (int j = 0; j < wordIns.Length - 1; j++)
                {
                    if (wordIns[j].Count < wordIns[j + 1].Count)
                    {
                        WordInText z = wordIns[j];
                        wordIns[j] = wordIns[j + 1];
                        wordIns[j + 1] = z;
                    }
                }
            }
        }

    }
}

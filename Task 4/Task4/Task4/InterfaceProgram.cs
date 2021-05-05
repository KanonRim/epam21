using System;
using System.Collections.Generic;

namespace Task4
{
    class InterfaceProgram
    {
        static public Mode mode = 0;
        static public void Preview(string[] args) 
        {
            Console.WriteLine("Какой из режимов вы хотите включить: [1] наблюдения или [2] отката изменений.");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    mode = Mode.Supervision;
                    break;
                }
                if (answer == "2")
                {
                    mode = Mode.RollbackChanges;
                    break;
                }
            }
        }

        public static ChangesFileInfo QuestionWhatСhange(LogerFolder loger )
        {
            for (int i = 0; i < loger.LogersFile.Count; i++)
            {
                Console.WriteLine($"{i}: {loger.LogersFile[i].PathFile}");
            }

            var  answer= loger.LogersFile[
                ConsoleHelper.IntReadParse("Какой файл Вы хотели бы откатить?",0, loger.LogersFile.Count)
                ].List;


            for (int i = 0; i < answer.Count; i++)
            {
                Console.WriteLine($"{i}: {answer[i].ToString()}");
            }
            return answer[
                ConsoleHelper.IntReadParse("на какое измениение вы хотели бы вернуться", 0, loger.LogersFile.Count)
                ];
        }



    }

}

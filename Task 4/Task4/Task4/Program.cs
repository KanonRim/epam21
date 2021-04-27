using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        static LogerFolder loger;
        static bool looup;
        static void Main(string[] args)
        {            
            string _workingFolder = @"G:\folder\";
            string _changesFileFolder = @"G:\folder\ChangesFileFolder\";
            loger = new LogerFolder(_workingFolder, _changesFileFolder);

            InterfaceProgram.Preview(args);
            loger.StartSupervision();
            loger.UpdateSupervision();
            if (InterfaceProgram.mode == Mode.Supervision)
            {                
                Thread myThread = new Thread(new ThreadStart(UpdateUpdateSupervision));
                myThread.Start();
                Console.WriteLine("Нажмите любую клавишу чтобы закончить");
                Console.ReadKey();
                looup = false;
                
                loger.StopSupervision();

            }
            
            if (InterfaceProgram.mode == Mode.RollbackChanges)
            {
                DateTime dateTime = ConsoleHelper.DateReadParse("Введите дату ГГГГ-ММ-ДД ЧЧ:ММ СС");
                foreach (var item in loger.LogersFile)
                {
                    item.RollingBackChanges(dateTime);
                }
            }
            if (InterfaceProgram.mode == Mode.RollbackChangesOneFile)
            {
                InterfaceProgram.QuestionWhatСhange(loger).RollingBackChanges();
            }
        }
        static public void UpdateUpdateSupervision()
        {
            while (looup)
            {
                loger.UpdateSupervision();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }       
        }
    }
}

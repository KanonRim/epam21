using EPAM.AWARDS.ConsolePl;
using EPAM.AWARDS.Dependencies;
using EPAM.AWARDS.Entities;
using Newtonsoft.Json;
using System;
using System.Linq;
//using System.Text.Json;

namespace EPAM.AWARDS.Pl
{
    class Program
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.Logic;

            Console.WriteLine("Тестовый интерфейс для программы НАГРАДЫ");

            do
            {
              int answer=   ConsoleHelper.IntReadParse(@"Введите действие
1-Показать список пользователей,
2-Добавить пользователя, 
3-Добавить награду,
4-Добавить пользователю награду,
5-Посмотеть награды пользоваптеля,
6-Посмотреть все награды ");

                switch (answer)
                {
                    case 1:
                        foreach (var item in bll.GetUsers())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Ведите имя");
                        string name =  Console.ReadLine();
                        DateTime date = ConsoleHelper.DateReadParse("ВВедите дату рождения");                        
                        bll.CreateUser(name, date);
                        break;
                    case 3:
                        Console.WriteLine("Ведите подпись награды");
                        string title = Console.ReadLine();

                        bll.CreateAward(title);
                        break;

                    case 4:
                        var users =bll.GetUsers().ToArray();
                        var awards = bll.GetAwards().ToArray();
                        Console.WriteLine();

                        bll.AddAwardToUser(ConsoleHelper.IntReadParse("Введите id пользователя", 1, users.Length),
                            ConsoleHelper.IntReadParse("Введите id награды", 0, awards.Length));                      
                        break;
                    case 5:                       
                        int a =  ConsoleHelper.IntReadParse("Введите id пользоваиеля");
                        User user = bll.GetUser(a);
                        if (user!=null)
                            Console.WriteLine(user);
                            Console.WriteLine(string.Join(Environment.NewLine, JsonConvert.SerializeObject( user.Awards)));
                        break;
                    case 6:
                        foreach (var item in bll.GetAwards())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;

                }

            } while (true);


        }
    }
}

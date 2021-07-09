using EPAM.AWARDS.DAL.Interfaces;
using EPAM.AWARDS.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
//using System.Text.Json;

namespace EPAM.AWARDS.DAL
{





    public class JsonDAO : IAwardsDAO
    {
        public const string JsonFilesPath = @"C:\MYAWARD\";

        private string GetFilePathByIdUser(int id) => JsonFilesPath + "User" + id + ".json";
        private string GetFilePathByIdAward(int id) => JsonFilesPath + "Award" + id + ".json";




        #region award 
        public Award CreateAward(string title)
        {
            int id = 0;
            do
            {
                id++;
            } while (GetAward(id) != null);
            Award award = new Award(id,title);
            using (StreamWriter sr = File.CreateText(GetFilePathByIdAward(id)))
            {
                sr.WriteLine(JsonConvert.SerializeObject(award));
            };
            

            return new Award(id, title);
        }

        public bool DeleteAward(int id)
        {
            File.Delete(GetFilePathByIdAward(id));
            return true;
        }

        public bool DeleteAward(Award Award)
        {
            File.Delete(GetFilePathByIdAward(Award.Id));
            return true;
        }

        public Award GetAward(int id)
        {
            string path = GetFilePathByIdAward(id);
            if (!File.Exists(path))
                return null;
            using (StreamReader sr = File.OpenText(path))
            {
                return JsonConvert.DeserializeObject<Award>(sr.ReadToEnd());
            }
        }

        public IEnumerable<Award> GetAwards(bool orderedById)
        {
            string[] patchs = Directory.GetFiles(JsonFilesPath, "Award*.json");
            Award[] awards = new Award[patchs.Length];

            for (int i = 0; i < patchs.Length; i++)
            {
                using (StreamReader sr = File.OpenText(patchs[i]))
                {
                    awards[i] = JsonConvert.DeserializeObject<Award>(sr.ReadToEnd());
                }
            }
            return awards;

        }

        #endregion


        #region user
        public bool DeleteUser(int id)
        {
            File.Delete(GetFilePathByIdUser(id));
            return true;
        }

        public bool DeleteUser(User User)
        {
            File.Delete(GetFilePathByIdUser(User.Id));
            return true;
        }

        public User GetUser(int id)
        {
            string path = GetFilePathByIdUser(id);
            if (!File.Exists(path))
                return null;
            using (StreamReader sr = File.OpenText(path))
                return JsonConvert.DeserializeObject<User>(sr.ReadToEnd());
        }

        public IEnumerable<User> GetUsers(bool orderedById)
        {
          
            string[] patchs = Directory.GetFiles(JsonFilesPath, "User*.json");
            
            User[] users = new User[patchs.Length];

            for (int i = 0; i < patchs.Length; i++)
            {
                using (StreamReader sr = File.OpenText(patchs[i]))
                    users[i] = JsonConvert.DeserializeObject<User>(sr.ReadToEnd());
            }
            return users;
        }

        public User CreateUser(string name, DateTime dateOfBirth,string passHash)
        {
            int id = 0;
            do
            {
                id++;
            } while (GetUser(id) != null);
            User user = new User(id, name, dateOfBirth,passHash);
            using (StreamWriter sr = File.CreateText(GetFilePathByIdUser(id)))
                sr.WriteLine(JsonConvert.SerializeObject(user));

            return user;
        }

        public User UpdateUser(User user)
        {
            string path = GetFilePathByIdUser(user.Id);
            if (File.Exists(path))
                File.WriteAllText(path, JsonConvert.SerializeObject(user));
            else
                throw new ArgumentException(nameof(user), "User not registered in the database,use CreateUser");
            return user;
        }





        #endregion




    }
}

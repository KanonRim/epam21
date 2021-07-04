using System;
using System.Collections.Generic;


namespace EPAM.AWARDS.Entities
{
    public class User
    {
        private string name;

        public User() { }

        private List<Award> _awards = new List<Award>();

        public List<Award> Awards { get => _awards; set { _awards = value; } }


        public User(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (value != "")
                    name = value;
                else
                    throw new ArgumentException(nameof(name), "cannot be empty.");
            }
        }     

        public TimeSpan Age
        {
            get
            {
                return DateTime.Now - DateOfBirth;
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (value < DateTime.Now)
                    dateOfBirth = value;
                else
                    throw new ArgumentException(nameof(DateOfBirth), name + "is from the future");
            }
        }

        bool HasAward(Award award)
        {
            return this.Awards.Find(a => a?.Id == award.Id)!=null;
        }

       public static User HasAward(IEnumerable<User> users,Award award)
        {
            if(users== null)
            {
                return null;
            }
            foreach (var item in users)
            {
                if (item.HasAward(award))
                {
                    return item;
                }      
            }
            return null;
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + DateOfBirth.Year + Environment.NewLine + string.Join(Environment.NewLine + " ", Awards);
        }
    }
}

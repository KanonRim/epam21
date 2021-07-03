using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        private DateTime dateOfBirth;

        [JsonIgnore]
        public TimeSpan Age { 
            get
            {
               return DateTime.Now - DateOfBirth;
            }
        }

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

        public override string ToString()
        {
            return Id +" "+ Name + " " + DateOfBirth.Year+ Environment.NewLine+ JsonSerializer.Serialize(Awards);
        }
    }
}

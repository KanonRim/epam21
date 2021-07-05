using EPAM.AWARDS.DAL.Interfaces;
using EPAM.AWARDS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EPAM.AWARDS.DAL
{
    public class SQLDAO : IAwardsDAO
    {
        //Data Source=DESKTOP-NI0AVFO\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string _connectionStrong = @"Data Source=DESKTOP-NI0AVFO\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionStrong);
        
        public Award CreateAward(string title)
        {
            int id=0;
            do
            {
                id++;
            } while (GetAward(id) != null);

            using ( _connection)
            {
                var procedure = "CreateAward";
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Title", title);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return new Award(id,title);
            }
        }

        public User CreateUser(string name, DateTime dateOfBirth, string passHash)
        {
            int id = 0;
            do
            {
                id++;
            } while (GetUser(id) != null);

            using (_connection)
            {
                
                var procedure = "CreateUser";
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@passHash", passHash);

                _connection.Open();
                var result = command.ExecuteNonQuery();
                return new User(id,name,dateOfBirth,passHash);
            }
        }

        public bool DeleteAward(int id)
        {
            var procedure = "DeleteAward";
            SqlCommand command = new SqlCommand(procedure, _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@id", id);
            _connection.Open();
            var result = command.ExecuteNonQuery();
            return result > 0;            
        }

        public bool DeleteAward(Award Award)
        {
            return DeleteAward(Award.Id);
        }

        public bool DeleteUser(int id)
        {
            var procedure = "DeleteUser";
            SqlCommand command = new SqlCommand(procedure, _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@id", id);
            _connection.Open();
            var result = command.ExecuteNonQuery();
            return result > 0;
        }

        public bool DeleteUser(User user)
        {
           return DeleteUser(user.Id);
        }

        public Award GetAward(int id)
        {
            using (_connection)
            {
                var stProc = "Award_GetByID";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award(
                        id: (int)reader["id"],
                        title: (string)reader["title"]);

                }
                else
                {
                    return null;
                }

            }
        }

        public IEnumerable<Award> GetAwards(bool orderedById)
        {
            using (_connection)
            {
                var procedure_getAllUsers = "GetAwards";
                SqlCommand command = new SqlCommand(procedure_getAllUsers, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Award(
                        id: (int)reader["id"],
                        title: (string)reader["title"]);
                }
            }
        }

        
        public User GetUser(int id)
        {
            using (_connection)
            {
                var stProc = "User_GetByID";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (int)reader["id"],
                        name: (string)reader["name"],
                        dateOfBirth: DateTime.Parse((string)reader["dateOfBirth"]),
                        passHash: (string)reader["passHash"],
                        roll: (Roll)reader["roll"],
                        awards: GetAllAwardOfUser((int)reader["id"]));
                }
                else
                {
                    return null;
                }

            }
        }


        
        public IEnumerable<User> GetUsers(bool orderedById)
        {
            using (_connection)
            {
                var procedure = "GetUsers";
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {                    
                    yield return new User(
                        id: (int)reader["id"],
                        name: (string)reader["name"],
                        dateOfBirth: DateTime.Parse((string)reader["dateOfBirth"]),
                        passHash: (string)reader["passHash"],
                        roll:  (Roll)reader["roll"],
                        awards:GetAllAwardOfUser((int)reader["id"]));
                }
            }
        }

        private IEnumerable<Award> GetAllAwardOfUser(int userID )
        {
            using (_connection)
            {
                var procedure = "GetAllAwardOfUser";
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Award(
                        id: (int)reader["id"],
                        title: (string)reader["title"]);
                }
            }
        }
        

        public User UpdateUser(User user)
        {
            using (_connection)
            {
                var procedure = "CreateUser";
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", user.Id);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@passHash", user.PassHash);

                _connection.Open();
                var result = command.ExecuteNonQuery();
                return new User(user.Id, user.Name, user.DateOfBirth, user.PassHash);
            }
        }
    }
}

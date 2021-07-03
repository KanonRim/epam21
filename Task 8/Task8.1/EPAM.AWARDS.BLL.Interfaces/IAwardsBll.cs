
using EPAM.AWARDS.Entities;
using System;
using System.Collections.Generic;

namespace EPAM.AWARDS.BLL.Interfaces
{


    public interface IAwardsBll
    {
        User AddAwardToUser(int idUser, int idAward);
        User AddAwardToUser(int idUser, string awardTitle);
        Award CreateAward(Award Award);
        Award CreateAward(string awardTitle);
        User CreateUser(string name,DateTime date);
        bool DeleteUser(int id);
        bool DeleteUser(User user);
        Award GetAward(int id);
        IEnumerable<Award> GetAwards();
        IEnumerable<Award> GetAwardsOfUser(int id);
        User GetUser(int id);
        IEnumerable<User> GetUsers();

    }
}

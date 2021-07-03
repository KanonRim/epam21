﻿using System;
using System.Collections.Generic;
using EPAM.AWARDS.BLL.Interfaces;
using EPAM.AWARDS.DAL.Interfaces;
using EPAM.AWARDS.Entities;

namespace EPAM.AWARDS.BLL
{
    public class AwardsLogic : IAwardsBll
    {

        private IAwardsDAO _dao;

        public AwardsLogic(IAwardsDAO DAO)
        {
            _dao = DAO;
        }

        public User AddAwardToUser(int idUser, int idAward)
        {
            Award award = GetAward(idAward);
            User user = GetUser(idUser);
            user.Awards.Add(award);
            _dao.UpdateUser(user);
            return user;
        }

        public User AddAwardToUser(int idUser, string awardTitle)
        {
            Award award = null;
            foreach (var item in GetAwards())
            {
                if (item.Title == awardTitle)
                    award = item;
            }

            award ??= CreateAward(awardTitle);

            User user = GetUser(idUser);
            user.Awards.Add(award);
            _dao.UpdateUser(user);
            return user;
        }


        public Award CreateAward(string awardTitle)
        {
            return _dao.CreateAward(awardTitle);
        }
        public Award CreateAward(Award Award)
        {
            return _dao.CreateAward(Award.Title);
        }

        public User CreateUser(string name,DateTime DateOfBirth)
        {
            return _dao.CreateUser(name, DateOfBirth);
        }

        public bool DeleteUser(int id)
        {
            return _dao.DeleteUser(id);
        }

        public bool DeleteUser(User user)
        {
            return DeleteUser(user.Id);
        }

        public Award GetAward(int id)
        {
            return _dao.GetAward(id);
        }

        public User GetUser(int id)
        {
            return _dao.GetUser(id);
        }

        public IEnumerable<Award> GetAwardsOfUser(int id)
        {
            return GetUser(id).Awards;
        }

        public IEnumerable<Award> GetAwards()
        {
            return _dao.GetAwards(true);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dao.GetUsers(true);
        }
    }
}

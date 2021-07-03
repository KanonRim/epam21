using EPAM.AWARDS.BLL;
using EPAM.AWARDS.BLL.Interfaces;
using EPAM.AWARDS.DAL;
using EPAM.AWARDS.DAL.Interfaces;

using System;

namespace EPAM.AWARDS.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;
        public static DependencyResolver Instance => _instance ??= new DependencyResolver();

        #endregion

        public IAwardsDAO DAO => new JsonDAO();

        public IAwardsBll Logic => new AwardsLogic(DAO);

    }
}

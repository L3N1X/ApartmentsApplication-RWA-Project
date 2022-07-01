using RwaApartmaniDataLayer.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Repositories.Factories
{
    public class RepoFactory
    {
        private static DBRepo repoInstance;
        public static DBRepo GetRepoInstance()
        {
            if(repoInstance is null)
                repoInstance = new DBRepo();
            return repoInstance;
        }
    }
}

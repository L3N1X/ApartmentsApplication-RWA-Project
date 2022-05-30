using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public static class RepoFactory
    {
        public static IRepo GetRepo() => new DBRepo();
    }
}

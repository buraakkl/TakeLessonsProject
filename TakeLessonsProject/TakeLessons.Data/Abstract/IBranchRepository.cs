using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Data.Abstract
{
    public interface IBranchRepository:  IRepository<Branch>
    {
        List<Branch> GetAllBranch();
    }
}
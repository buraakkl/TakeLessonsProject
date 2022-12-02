using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Data.Concrete.EfCore
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }

        private MyAppContext context
        {

            get { return _dbContext as MyAppContext; }
        }

        public List<Branch> GetAllBranch()
        {
           return context
                .Branches
                .ToList();
                
        }
    }
}
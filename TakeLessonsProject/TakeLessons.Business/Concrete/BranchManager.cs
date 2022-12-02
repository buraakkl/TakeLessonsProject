using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeLessons.Business.Abstract;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public List<Branch> GetAllBranch()
        {
           return _branchRepository.GetAllBranch();
        }
    }
}
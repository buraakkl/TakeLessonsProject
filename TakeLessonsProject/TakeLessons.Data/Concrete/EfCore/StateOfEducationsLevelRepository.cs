using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Data.Concrete.EfCore
{
    public class StateOfEducationsLevelRepository : GenericRepository<StateOfEducationsLevel>, IStateOfEducationsLevelRepository
    {
        public StateOfEducationsLevelRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }

        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }

        public List<StateOfEducationsLevel> GetAllEducationLevel()
        {
            return context
                .StateOfEducationsLevels
                .ToList();
        }

        async Task<List<StateOfEducationsLevel>> IStateOfEducationsLevelRepository.GetAllAsync()
        {
            return await context
                 .StateOfEducationsLevels
                 .ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Data.Abstract
{
    public interface IStateOfEducationsLevelRepository : IRepository<StateOfEducationsLevel>
    {
        List<StateOfEducationsLevel> GetAllEducationLevel();
        Task<List<StateOfEducationsLevel>> GetAllAsync();
    }
}

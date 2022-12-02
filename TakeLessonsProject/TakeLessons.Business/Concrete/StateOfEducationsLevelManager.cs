using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Business.Abstract;
using TakeLessons.Data.Abstract;
using TakeLessons.Data.Concrete.EfCore;
using TakeLessons.Entity;

namespace TakeLessons.Business.Concrete
{
    public class StateOfEducationsLevelManager : IStateOfEducationsLevelService
    {
        private readonly IStateOfEducationsLevelRepository _stateOfEducationsLevelRepository;

        public StateOfEducationsLevelManager(IStateOfEducationsLevelRepository stateOfEducationsLevelRepository)
        {
            _stateOfEducationsLevelRepository = stateOfEducationsLevelRepository;
        }

        public async Task<List<StateOfEducationsLevel>> GetAllAsync()
        {
            return await _stateOfEducationsLevelRepository.GetAllAsync();
        }

        public List<StateOfEducationsLevel> GetAllEducationLevel()
        {
            return _stateOfEducationsLevelRepository.GetAllEducationLevel();
        }
    }
}

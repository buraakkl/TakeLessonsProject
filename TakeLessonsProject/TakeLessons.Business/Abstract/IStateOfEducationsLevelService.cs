using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Data.Concrete.EfCore;
using TakeLessons.Entity;

namespace TakeLessons.Business.Abstract
{
    public interface IStateOfEducationsLevelService
    {
        List<StateOfEducationsLevel> GetAllEducationLevel(); //BU kısımda tüm eğitim seviyelerini listeledim.

        Task<List<StateOfEducationsLevel>> GetAllAsync(); //Bu kıısımda ise teacherCreate için asenkron bir metot kullanarak tüm eğitim seviyelerini listeledim.
        
    }
}

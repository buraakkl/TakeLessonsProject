using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetAll();
    }
}

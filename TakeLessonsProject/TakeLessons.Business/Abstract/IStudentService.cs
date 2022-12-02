using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Business.Abstract
{
    public interface IStudentService
    {
        ICollection<Student> GetAll();
    }
}

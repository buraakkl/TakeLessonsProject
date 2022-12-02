using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Data.Concrete.EfCore
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }

        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }

        public List<Student> GetAll()
        {
            return context
                 .Students
                 .ToList();
        }
    }
}

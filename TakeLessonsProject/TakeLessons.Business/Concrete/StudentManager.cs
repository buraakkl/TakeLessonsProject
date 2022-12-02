using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Business.Abstract;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICollection<Student> GetAll()
        {
           return _studentRepository.GetAll();
        }
    }
}

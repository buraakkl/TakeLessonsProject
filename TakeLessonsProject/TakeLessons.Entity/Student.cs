using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeLessons.Entity
{
    public class Student : BaseEntity
    {
        public int StateOfEducationsLevelId { get; set; } 

        public StateOfEducationsLevel StateOfEducationsLevel { get; set; }

        public ICollection<TeacherAndStudent> TeacherAndStudents { get; set; }
        
    }
}

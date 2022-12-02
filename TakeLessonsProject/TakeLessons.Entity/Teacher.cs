using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TakeLessons.Entity
{
    public class Teacher : BaseEntity
    {
        public string UniversityGraduatedFrom { get; set; }
        public int HourlyPrice { get; set; }
        public bool IsFaceToFace { get; set; }
        public bool CertifiedTrainer { get; set; }
        public string Email { get; set; }

        public ICollection<TeacherAndStudent> TeacherAndStudents { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int StateOfEducationsLevelId { get; set; }
        public StateOfEducationsLevel StateOfEducationsLevel { get; set; }


    }
}

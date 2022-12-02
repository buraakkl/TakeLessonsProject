using Microsoft.AspNetCore.Mvc;
using TakeLessons.Entity;

namespace TakeLessonsProject.Web.Models
{
    public class TeacherDetailModel
    {
        public Teacher Teacher { get; set; } 
        public List<StateOfEducationsLevel> EducationsLevels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Data.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetAll();
        Task<Teacher> GetById(int id);
        Task<ICollection<Teacher>> GetAllAsync();

        Task<ICollection<Teacher>> GetByTeachers();

        List<Teacher> GetTeachersByEducationLevel(string educationLevel, int page, int pageSize);
        int GetCountByEducationLevel(string educationLevel);
        Teacher GetTeachersDetails(string url);
        Task<Teacher> GetTeacherWithEducationLevelAsync(int id);
        Task CreateAsync(Teacher teacher, int categoryIds);

        void TeacherCreate(Teacher teacher, int educationLevelId, int branchId);
        void DeleteTeacher(Teacher teacher);

        Teacher GetTeacherWithCategories(int id);

        void UpdateTeacher(Teacher teacher);







    }
}

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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Task CreateAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Teacher teacher, int categoryIds)
        {
            return _teacherRepository.CreateAsync(teacher, categoryIds);
        }

        public void DeleteAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _teacherRepository.DeleteTeacher(teacher);
        }

        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public async Task<ICollection<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Teacher>> GetByTeachers()
        {
            return await _teacherRepository.GetByTeachers();
        }

        public int GetCountByEducationLevel(string educationLevel)
        {
            return _teacherRepository.GetCountByEducationLevel(educationLevel);
        }

        public List<Teacher> GetTeachersByEducationLevel(string educationLevel, int page, int pageSize)
        {
            return _teacherRepository.GetTeachersByEducationLevel(educationLevel, page, pageSize);

        }

        public Teacher GetTeachersDetails(string url)
        {
            return _teacherRepository.GetTeachersDetails(url);
        }

        public Teacher GetTeacherWithCategories(int id)
        {
            return _teacherRepository.GetTeacherWithCategories(id);
        }

        public async Task<Teacher> GetTeacherWithEducationLevelAsync(int id)
        {
            return await _teacherRepository.GetTeacherWithEducationLevelAsync(id);
        }

        public void TeacherCreate(Teacher teacher, int educationLevelId, int branchId)
        {
            _teacherRepository.TeacherCreate(teacher, educationLevelId, branchId);
        }

        public void UpdateAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.UpdateTeacher(teacher);
        }
    }
}

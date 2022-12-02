using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Data.Abstract;
using TakeLessons.Entity;

namespace TakeLessons.Data.Concrete.EfCore
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }

        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }

        }

        public async Task CreateAsync(Teacher teacher, int categoryIds)
        {
            teacher.DateOfRegistration = DateTime.Now;
            teacher.StateOfEducationsLevelId = categoryIds;
            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();

        }

        public void DeleteTeacher(Teacher teacher)
        {
            teacher.IsDeleted = true;
            context.Update(teacher);
            context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return context
                 .Teachers
                 .Where(p => p.IsDeleted == false)
                 .Include(b => b.Branch)
                 .ToList();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await context
               .Teachers
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Teacher>> GetByTeachers()
        {
            //Bu kısımda TeacherList sayfasında öğretmenleri branch bilgileriyle beraber listeledim.
            return await context
                 .Teachers
                 .Include(t => t.Branch)
                 .ToListAsync();
        }

        public int GetCountByEducationLevel(string educationLevel)
        {
            var teachers = context.Teachers.AsQueryable();
            if (!string.IsNullOrEmpty(educationLevel))
            {
                teachers = teachers
                    .Where(p => p.CertifiedTrainer == true)
                    .Include(p => p.StateOfEducationsLevel);


            };

            return teachers.Count();
        }

        public List<Teacher> GetTeachersByEducationLevel(string educationLevel, int page, int pageSize)
        {
            var teachers = context
                .Teachers
                .AsQueryable();
            if (!string.IsNullOrEmpty(educationLevel))
            {
                teachers = teachers
                    .Where(t => t.CertifiedTrainer)
                    .Include(e => e.StateOfEducationsLevel)
                    .Where(e => e.StateOfEducationsLevel.Name == educationLevel);
            }

            return teachers.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Teacher GetTeachersDetails(string url)
        {
            return context
                     .Teachers
                     .Where(p => p.Url == url)
                     .Include(t => t.StateOfEducationsLevel)
                     .FirstOrDefault();
        }

        public Teacher GetTeacherWithCategories(int id)
        {
            return context
                .Teachers
                .Where(t => t.Id == id && t.IsDeleted == false)
                 .Include(p => p.StateOfEducationsLevel)
                 .FirstOrDefault();
        }

        public async Task<Teacher> GetTeacherWithEducationLevelAsync(int id)
        {
            return await context
                .Teachers
                .Where(t => t.Id == id)
                .Include(t => t.StateOfEducationsLevel)
                .FirstOrDefaultAsync();
        }

        public void TeacherCreate(Teacher teacher, int educationLevelId, int branchId)
        {
            teacher.DateOfRegistration = DateTime.Now;
            teacher.StateOfEducationsLevelId = educationLevelId;
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            Teacher entity = context
                .Teachers
                .FirstOrDefault(t => t.Id == teacher.Id);
            entity.FirstName = teacher.FirstName;
            entity.LastName = teacher.LastName;
            entity.Description = teacher.Description;
            entity.HourlyPrice = teacher.HourlyPrice;
            entity.BranchId = teacher.BranchId;
            entity.Url = teacher.Url;
            entity.Image = teacher.Image;
            entity.Locations = teacher.Locations;

            context.Update(entity);
            context.SaveChanges();
        }
    }
}

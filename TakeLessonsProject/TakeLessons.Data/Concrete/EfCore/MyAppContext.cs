using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Data.Concrete.EfCore
{

    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<StateOfEducationsLevel> StateOfEducationsLevels { get; set; }
        public DbSet<TeacherAndStudent> TeacherAndStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
             .Entity<TeacherAndStudent>()
             .HasKey(st => new
             {
                 st.TeacherId,
                 st.StudentId
             });


            modelBuilder
                .Entity<Student>()
                .HasData(

                new Student() { StateOfEducationsLevelId = 1, Id = 1, FirstName = "Bernard ", LastName = "Anna", Gender = "Male", Url = "students", Age = 14, Image = "1.jpg", Locations = "New York", DateOfRegistration = DateTime.Now, Description = "Hi There :)" }

                );


            modelBuilder
                .Entity<Teacher>()
                .HasData(

                new Teacher() { Id = 1, BranchId = 1, FirstName = "Engin Niyazi", LastName = "Ergül", Gender = "Male", Age = 47, CertifiedTrainer = true, Description = "Hello, I'm a math teacher", Image = "24.jpg", HourlyPrice = 300, Locations = "New York", DateOfRegistration = DateTime.Now, IsFaceToFace = true, UniversityGraduatedFrom = "Stanford Universty", Url = "engin-niyazi-ergül", StateOfEducationsLevelId = 1, Email = "engin_niyazi@gmail.com" },
                 new Teacher() { Id = 2, BranchId = 2, FirstName = "Goldschmidt", LastName = "Forguson", Gender = "Male", Age = 35, CertifiedTrainer = true, Description = "Hello, I'm a english teacher", Image = "2.jpg", HourlyPrice = 100, Locations = "Alaska", DateOfRegistration = DateTime.Now, IsFaceToFace = true, UniversityGraduatedFrom = "Stanford Universty", Url = "Goldschmidt", StateOfEducationsLevelId = 2, Email = "Goldschmidt@gmail.com" },
                new Teacher() { Id = 3, BranchId = 3, FirstName = "Bagel", LastName = "Jean", Gender = "Female", Age = 31, CertifiedTrainer = true, Description = "Hi I'am a chemistry teacher", Image = "4.jpg", HourlyPrice = 150, Locations = "Florida", DateOfRegistration = DateTime.Now, IsFaceToFace = false, UniversityGraduatedFrom = "Stanford Universty", Url = "Bagel", StateOfEducationsLevelId = 2, Email = "Bagel_Jean@gmail.com" },
                new Teacher() { Id = 4, BranchId = 2, FirstName = "Autier", LastName = "Miconi", Gender = "Male", Age = 28, CertifiedTrainer = true, Description = "Hi I'am a english teacher", Image = "5.jpg", HourlyPrice = 200, Locations = "Virginia", DateOfRegistration = DateTime.Now, IsFaceToFace = true, UniversityGraduatedFrom = "Stanford Universty", Url = "Autier", StateOfEducationsLevelId = 1, Email = "Miconi_autier@gmail.com" },
                new Teacher() { Id = 5, BranchId = 1, FirstName = "Eggerer", LastName = "Alex", Gender = "Male", Age = 25, CertifiedTrainer = true, Description = "Hello, I'm a music teacher", Image = "6.jpg", HourlyPrice = 80, Locations = "Hawaii", DateOfRegistration = DateTime.Now, IsFaceToFace = false, UniversityGraduatedFrom = "Stanford Universty", Url = "Eggerer", StateOfEducationsLevelId = 3, Email = "Eggerer_alax@gmail.com" },
                new Teacher() { Id = 6, BranchId = 5, FirstName = "Li", LastName = "George", Gender = "Male", Age = 42, CertifiedTrainer = true, Description = "Hi I'am a Physics teacher", Image = "7.jpg", HourlyPrice = 100, Locations = "Kaliforniya", DateOfRegistration = DateTime.Now, IsFaceToFace = true, UniversityGraduatedFrom = "Stanford Universty", Url = "Li", StateOfEducationsLevelId = 2, Email = "George_Male@gmail.com" }

                     );

            modelBuilder
               .Entity<Branch>()
               .HasData(

             new Branch() { BranchId = 1, Name = "Math" },
             new Branch() { BranchId = 2, Name = "English" },
             new Branch() { BranchId = 3, Name = "Chemistry" },
             new Branch() { BranchId = 4, Name = "Music" },
             new Branch() { BranchId = 5, Name = "Physics" }

                 );



            modelBuilder
            .Entity<TeacherAndStudent>()
            .HasData(
                new TeacherAndStudent() { TeacherId = 1, StudentId = 1 }
                //new TeacherAndStudent() { TeacherId = 2, StudentId = 4 },
                //new TeacherAndStudent() { TeacherId = 3, StudentId = 3 },
                //new TeacherAndStudent() { TeacherId = 4, StudentId = 2 },
                //new TeacherAndStudent() { TeacherId = 5, StudentId = 1 }

                );

            modelBuilder
                .Entity<StateOfEducationsLevel>()
                .HasData(

                new StateOfEducationsLevel() { StateOfEducationsLevelId = 1, Name = "High School" },
                 new StateOfEducationsLevel() { StateOfEducationsLevelId = 2, Name = "Middle School" },
                new StateOfEducationsLevel() { StateOfEducationsLevelId = 3, Name = "Primary School" }
                );
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Entity;

namespace TakeLessons.Business.Abstract
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();
        Task<Teacher> GetByIdAsync(int id);
        Task<ICollection<Teacher>> GetAllAsync(); //Bu metot ile ana sayfada tüm öğretmenleri listeledim.
        Task CreateAsync(Teacher teacher);
        void UpdateAsync(Teacher teacher);
        void DeleteAsync(Teacher teacher);

        Task<ICollection<Teacher>> GetByTeachers();

        List<Teacher> GetTeachersByEducationLevel(string educationLevel, int page, int pageSize); //Bu metodu eğitim seviyelerine göre öğretmenleri listelemek için kullandım.Ayrıca sayfaları listelemek içinde parametre yolladım.

        int GetCountByEducationLevel(string educationLevel); //Bu metot sayfalama yapmak için yazıldı.

        Teacher GetTeachersDetails(string url); //Bu metodu öğretmenlerin detaylarını göstermek için yaptım.

        Task<Teacher> GetTeacherWithEducationLevelAsync(int id); //Bu metodu UserProfile sayfasında öğretmenlerin bilgilerini değiştirebilmesi için yaptım.(İncelenmesi gerekiyor.)

        Task CreateAsync(Teacher teacher, int categoryIds); //Bu metodu Admin controller da yeni bir öğretmen oluşturmak için yaptım.

        void TeacherCreate(Teacher teacher, int educationLevelId , int branchId); //Bu metodu öğretmen kaydetmek için yaptım.(Tekrardan bak fotoğraf yüklenmiyor)

        void DeleteTeacher(Teacher teacher); //Bu metodu kayıtlı öğretmenleri silmek için yapıyorum.


        Teacher GetTeacherWithCategories(int id); //Bu metodu öğretmenlerin editini yapabilmek için yazdım.

        void UpdateTeacher(Teacher teacher);





    }
}

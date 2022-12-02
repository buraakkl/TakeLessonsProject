using TakeLessons.Entity;

namespace TakeLessonsProject.Web.ViewModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; }//Toplam gösterilecek ürün sayısı
        public int ItemsPerPage { get; set; }//Sayfa başına ürün sayısı
        public int CurrentPage { get; set; }//Geçerli sayfa
        public string? CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }

    }
    public class TeacherViewModel
    {
        public PageInfo PageInfo { get; set; } = null!;
        public List<Teacher> Teachers { get; set; } = null!;

    }

}

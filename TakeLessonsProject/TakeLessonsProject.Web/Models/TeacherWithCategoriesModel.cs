using System.ComponentModel.DataAnnotations;
using TakeLessons.Entity;

namespace TakeLessonsProject.Web.Models
{
    public class TeacherWithCategoriesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Branch is required!")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name's length is 1-50")]
        public string? FirstName { get; set; }



        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name's length is 1-50")]
        public string? LastName { get; set; }



        [Required(ErrorMessage = "Description is required!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "10-220")]
        public string? Description { get; set; }



        [Required(ErrorMessage = "Hourly price is required!")]
        [Range(0, 30000, ErrorMessage = "0-30000")]
        public decimal? HourlyPrice { get; set; }


        [Required(ErrorMessage = "Location is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Location length is 1-50")]
        public string? Location { get; set; }




        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }


        //[Required(ErrorMessage = "Educational environment information is required!")]
        //public string IsFaceToFace { get; set; }


        [Required(ErrorMessage = "Education level is required!")]
        public int EducationLevelId { get; set; }


        public string Image { get; set; }

        public string Url { get; set; }







    }
}

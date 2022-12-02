using Microsoft.AspNetCore.Mvc;
using TakeLessons.Business.Abstract;
using TakeLessons.Entity;
using TakeLessonsProject.Web.Models;
using TakeLessonsProject.Web.ViewModels;

namespace TakeLessonsProject.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _teacherService.GetByTeachers();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult List(string educationLevel, int page = 1) //Bu kısımda anasayfada eğitim seviyelerine göre öğretmenleri listeledim.
        {
            const int pageSize = 3; //Bir sayfada göstermek istediğim ürün sayısını belirledim.
            List<Teacher> teachers = _teacherService.GetTeachersByEducationLevel(educationLevel, page, pageSize);

            PageInfo pageInfo = new PageInfo()
            {
                TotalItems = _teacherService.GetCountByEducationLevel(educationLevel),
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = educationLevel
            };

            TeacherViewModel teacherViewModel = new TeacherViewModel()
            {
                Teachers = teachers,
                PageInfo = pageInfo
            };
            return View(teacherViewModel);
        }

        [HttpGet]
        public IActionResult HowItWorks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeacherDetails(string url)
        {
            var result = _teacherService.GetTeachersDetails(url);
            TeacherDetailModel teacherDetailModel = new TeacherDetailModel()
            {
                Teacher = result
            };

            return View(teacherDetailModel);
        }

        


    }
}

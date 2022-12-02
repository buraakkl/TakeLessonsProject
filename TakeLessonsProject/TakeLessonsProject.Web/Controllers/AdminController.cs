using Microsoft.AspNetCore.Mvc;
using TakeLessons.Business.Abstract;
using TakeLessons.Core;
using TakeLessons.Entity;
using TakeLessonsProject.Web.Models;
using TakeLessonsProject.Web.ViewModels;

namespace TakeLessonsProject.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStateOfEducationsLevelService _stateOfEducationsLevelService;
        private readonly IBranchService _branchService;
        private readonly IStudentService _studentService;

        public AdminController(ITeacherService teacherService, IStateOfEducationsLevelService stateOfEducationsLevelService, IBranchService branchService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _stateOfEducationsLevelService = stateOfEducationsLevelService;
            _branchService = branchService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfil(int id)
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }


        [HttpGet]
        public IActionResult TeacherList()
        {
            var teachers = _teacherService.GetAll();
            return View(teachers);
        }



        //[HttpGet]
        //public IActionResult TeacherList(string educationLevel, int page = 1) //Bu kısımda anasayfada eğitim seviyelerine göre öğretmenleri listeledim.
        //{
        //    const int pageSize = 4; //Bir sayfada göstermek istediğim ürün sayısını belirledim.
        //    List<Teacher> teachers = _teacherService.GetTeachersByEducationLevel(educationLevel, page, pageSize);

        //    PageInfo pageInfo = new PageInfo()
        //    {
        //        TotalItems = _teacherService.GetCountByEducationLevel(educationLevel),
        //        CurrentPage = page,
        //        ItemsPerPage = pageSize,
        //        CurrentCategory = educationLevel
        //    };

        //    TeacherViewModel teacherViewModel = new TeacherViewModel()
        //    {
        //        Teachers = teachers,
        //        PageInfo = pageInfo
        //    };
        //    return View(teacherViewModel);
        //}

        [HttpGet]
        public IActionResult TeacherCreate()
        {

            ViewBag.EducationLevels = _stateOfEducationsLevelService.GetAllEducationLevel();
            var liste = _branchService.GetAllBranch();
            ViewBag.Branchs = liste;
            TeacherWithCategoriesModel teacherModel = new TeacherWithCategoriesModel();
            return View(teacherModel);
        }

        [HttpPost]
        public IActionResult TeacherCreate(TeacherWithCategoriesModel teacherModel, IFormFile file, int educationLevelId, int branchId)
        {
            if (ModelState.IsValid && file != null && educationLevelId != 0)
            {
                teacherModel.Url = Jobs.MakeUrl(teacherModel.FirstName + teacherModel.LastName);
                teacherModel.Image = Jobs.UploadImage(file, teacherModel.Url);
                Teacher teacher = new Teacher()
                {
                    FirstName = teacherModel.FirstName,
                    LastName = teacherModel.LastName,
                    Description = teacherModel.Description,
                    HourlyPrice = ((int)teacherModel.HourlyPrice),
                    Url = teacherModel.Url,
                    Image = teacherModel.Image,
                    Locations = teacherModel.Location,
                    StateOfEducationsLevelId = teacherModel.EducationLevelId,
                    BranchId = teacherModel.BranchId,
                    Email = teacherModel.Email,
                    

                };


                _teacherService.TeacherCreate(teacher, educationLevelId, branchId);
                return RedirectToAction("TeacherList");

            }

            if (educationLevelId == 0)
            {
                ViewBag.educationlevelerrormessage = "choose education level!";
            }
            else
            {
                ViewData["selectededucationlevel"] = educationLevelId;
            }

            if (file == null)
            {
                ViewBag.ImageErrorMessage = "Choose an image!";
            }

            ViewBag.EducationLevel = _stateOfEducationsLevelService.GetAllEducationLevel();
            return View(teacherModel);
        }

        public async Task<IActionResult> TeacherDelete(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _teacherService.DeleteTeacher(teacher);
            return RedirectToAction("TeacherList");
        }



        [HttpGet]
        public IActionResult TeacherEdit(int id)
        {
            Teacher teacher = _teacherService.GetTeacherWithCategories(id);
            if (teacher == null)
            {
                return NotFound();
            }
            TeacherWithCategoriesModel teacherModel = new TeacherWithCategoriesModel()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Url = teacher.Url,
                Description = teacher.Description,
                Image = teacher.Image,
                EducationLevelId = teacher.StateOfEducationsLevelId,
                Location = teacher.Locations,
                HourlyPrice = teacher.HourlyPrice,


            };
            ViewBag.Branches = _teacherService.GetAll();
            return View(teacherModel);
        }


        [HttpPost]
        public IActionResult TeacherEdit(TeacherWithCategoriesModel teacherModel, int educationLevelId, IFormFile file)
        {

            if (ModelState.IsValid && educationLevelId != 0)
            {
                teacherModel.Url = Jobs.MakeUrl(teacherModel.LastName);
                if (file != null)//Resim değiştirilmiş ise
                {
                    teacherModel.Image = Jobs.UploadImage(file, teacherModel.Url);
                }

                Teacher teacher = _teacherService.GetTeacherWithCategories(teacherModel.Id);
                if (teacher == null)
                {
                    return NotFound();
                }
                teacher.FirstName = teacherModel.FirstName;
                teacher.LastName = teacherModel.LastName;
                teacher.Url = teacherModel.Url;
                teacher.HourlyPrice = (int)teacherModel.HourlyPrice;
                teacher.Description = teacherModel.Description;
                teacher.StateOfEducationsLevelId = educationLevelId;

                if (file != null)
                {
                    teacher.Image = teacherModel.Image;
                }

                _teacherService.UpdateTeacher(teacher);
                return RedirectToAction("TeacherList");
            }


            if (file == null)
            {
                Teacher teacher = _teacherService.GetTeacherWithCategories(teacherModel.Id);
                if (teacher == null)
                {
                    return NotFound();
                }

                teacherModel.Image = teacher.Image;
            }
            else
            {
                //Buraya bir validasyon hatası ya da kategori seçimi yapılmaması durumunda ve yeni resim seçilmişse
                teacherModel.Url = Jobs.MakeUrl(teacherModel.LastName);
                teacherModel.Image = Jobs.UploadImage(file, teacherModel.Url);
            }

            ViewBag.Branches = _stateOfEducationsLevelService.GetAllEducationLevel();

            return View(teacherModel);


        }

        public IActionResult StudentList()
        {
            var students = _studentService.GetAll();
            return View(students);
        }
    }
}

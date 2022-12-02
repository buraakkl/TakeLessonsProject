using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TakeLessons.Business.Abstract;
using TakeLessons.Business.Concrete;
using TakeLessons.Entity;
using TakeLessonsProject.Web.Models;
using TakeLessonsProject.Web.ViewModels;


namespace TakeLessonsProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;

        public HomeController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var teachers = _teacherService.GetAll();
            TeacherViewModel viewModel = new TeacherViewModel();
            viewModel.Teachers = teachers;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using TakeLessons.Business.Abstract;
using TakeLessons.Business.Concrete;
using TakeLessons.Entity;

namespace TakeLessonsProject.Web.Components
{
    public class CategorizedTeachersViewComponent : ViewComponent
    {
        private readonly IStateOfEducationsLevelService _stateOfEducationsLevelService;

        public CategorizedTeachersViewComponent(IStateOfEducationsLevelService stateOfEducationsLevelService)
        {
            _stateOfEducationsLevelService = stateOfEducationsLevelService;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["educationLevel"] != null)
            {
                ViewBag.SelectedEducationLevel = RouteData.Values["educationLevel"];
            }

            List<StateOfEducationsLevel> educationsLevels = _stateOfEducationsLevelService.GetAllEducationLevel();
            return View(educationsLevels);
        }
    }
}

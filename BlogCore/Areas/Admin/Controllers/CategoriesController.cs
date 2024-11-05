using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IContainerWork _containerWork;

        public CategoriesController (IContainerWork containerWork)
        {
            _containerWork = containerWork;
        }

        [HttpGet]
        public IActionResult Index ()
        {
            return View();
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll ()
        {
            return Json(new { data = _containerWork.Category.GetAll() });
        }


        #endregion
    }
}

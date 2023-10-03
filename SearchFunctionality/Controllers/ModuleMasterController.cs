using Microsoft.AspNetCore.Mvc;
using SearchFunctionality.Repository;

namespace SearchFunctionality.Controllers
{
    public class ModuleMasterController : Controller
    {
        private readonly IModuleMasterRepository _moduleMasterRepository;

        public ModuleMasterController(IModuleMasterRepository moduleMasterRepository)
        {
            _moduleMasterRepository = moduleMasterRepository;
        }

        public IActionResult Index()
        {
            ViewBag.ModuleMasterList = _moduleMasterRepository.GetAll();
            return View();
        }
    }
}

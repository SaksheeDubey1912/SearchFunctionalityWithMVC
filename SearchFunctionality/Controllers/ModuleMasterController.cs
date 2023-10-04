using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using SearchFunctionality.Models;
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

        [HttpGet]
        public IActionResult ReadData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReadData(IFormFile excelInput)
        {
            bool skipHeaders = true;
            List<ModuleMaster> moduleList = new List<ModuleMaster>();

            using (var stream = excelInput.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (skipHeaders)
                        {
                            skipHeaders = false;
                            continue;
                        }

                        var moduleObject = new ModuleMaster();

                        moduleObject.ModuleCode =  Convert.ToString(reader.GetValue(0));
                        moduleObject.Application = (string)reader.GetValue(1);
                        moduleObject.Module = (string)reader.GetValue(2);
                        moduleObject.SubModule = (string)reader.GetValue(3);

                        moduleList.Add(moduleObject);

                    }
                }
            }

            ViewBag.UploadedModuleList = moduleList;
            return View();
        }
    }
}

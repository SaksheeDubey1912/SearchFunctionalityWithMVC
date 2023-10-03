using SearchFunctionality.Models;

namespace SearchFunctionality.Repository
{
    public class ModuleMasterRepository: IModuleMasterRepository
    {
        public List<ModuleMaster> GetAll() {
            return GenerateData.GetData();
        }

    }
}

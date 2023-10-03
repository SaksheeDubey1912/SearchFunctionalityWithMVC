namespace SearchFunctionality.Models
{
    public class ModuleMaster
    {
        public int ModuleCode { get; set; }
        public string Application { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
    }

    public static class GenerateData
    {
        public static List<ModuleMaster> GetData()
        {

            return new List<ModuleMaster>()
            {
                new ModuleMaster{ModuleCode =1, Application="Construction", Module ="Field Weld Management", SubModule="Work order assignment module" },
                new ModuleMaster{ModuleCode =2, Application="Construction", Module ="Field Weld Management", SubModule="Fitup module" },
            };
        }
    }
}

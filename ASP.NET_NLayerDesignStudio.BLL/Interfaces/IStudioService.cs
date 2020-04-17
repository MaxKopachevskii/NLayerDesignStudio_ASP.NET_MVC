using ASP.NET_NLayerDesignStudio.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.BLL.Interfaces
{
    public interface IStudioService
    {
        ServiceDTO GetService(int? id);
        MasterDTO GetMaster(int? id);
        ExampleDTO GetExample(int? id);
        IEnumerable<ServiceDTO> GetAllServices();
        IEnumerable<MasterDTO> GetAllMasters();
        IEnumerable<ExampleDTO> GetAllExamples();
        void Dispose();
    }
}

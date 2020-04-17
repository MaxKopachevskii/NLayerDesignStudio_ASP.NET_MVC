using ASP.NET_NLayerDesignStudio.BLL.DTO;
using ASP.NET_NLayerDesignStudio.BLL.Infrastructure;
using ASP.NET_NLayerDesignStudio.BLL.Interfaces;
using ASP.NET_NLayerDesignStudio.DAL.Entities;
using ASP.NET_NLayerDesignStudio.DAL.Interfaces;
using ASP.NET_NLayerDesignStudio.DAL.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.BLL.Services
{
    public class StudioService : IStudioService
    {
        IUnitOfWork Database { get; set; }

        public StudioService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ExampleDTO GetExample(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var example = Database.Examples.Get(id.Value);
            if (example == null)
                throw new ValidationException("Пример для портфолио не найден", "");

            return new ExampleDTO { Id = example.Id, Name = example.Name, Desc = example.Desc, Img = example.Img  };
        }

        public MasterDTO GetMaster(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var master = Database.Masters.Get(id.Value);
            if (master == null)
                throw new ValidationException("Мастер не найден", "");

            return new MasterDTO { Id = master.Id, Name = master.Name,  Age = master.Age, YearsOfWork = master.YearsOfWork };
        }

        public ServiceDTO GetService(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var service = Database.Services.Get(id.Value);
            if (service == null)
                throw new ValidationException("Сервис не найден", "");

            return new ServiceDTO { Id = service.Id, Name = service.Name, Img = service.Img, Description = service.Description, MasterId = service.MasterId, Price = service.Price };
        }

        public IEnumerable<ExampleDTO> GetAllExamples()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Example, ExampleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Example>, List<ExampleDTO>>(Database.Examples.GetAll());
        }

        public IEnumerable<MasterDTO> GetAllMasters()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Master, MasterDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Master>, List<MasterDTO>>(Database.Masters.GetAll());
        }

        public IEnumerable<ServiceDTO> GetAllServices()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Service>, List<ServiceDTO>>(Database.Services.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

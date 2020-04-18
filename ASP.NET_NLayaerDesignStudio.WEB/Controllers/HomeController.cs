using ASP.NET_NLayaerDesignStudio.WEB.Models;
using ASP.NET_NLayerDesignStudio.BLL.DTO;
using ASP.NET_NLayerDesignStudio.BLL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_NLayaerDesignStudio.WEB.Controllers
{
    public class HomeController : Controller
    {
        IStudioService studioService;
        public HomeController(IStudioService serv)
        {
            studioService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<ServiceDTO> phoneDtos = studioService.GetAllServices();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ServiceDTO, ServiceViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<ServiceDTO>, List<ServiceViewModel>>(phoneDtos);
            return View(services);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceViewModel service)
        {
            var serv = new ServiceDTO { Id = service.Id, Description = service.Description, Img = service.Img, Name = service.Name, Price = service.Price };
            studioService.Create(serv);
            studioService.Save();
            return RedirectToAction("EditService");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = studioService.GetService(id);
            if (service != null)
            {
                return View(service);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ServiceViewModel service)
        {
            if (service != null)
            {
                var serv = new ServiceDTO { Id = service.Id, Description = service.Description, Img = service.Img, Name = service.Name, Price = service.Price };
                studioService.Edit(serv);
                studioService.Save();
                return RedirectToAction("EditService");
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            studioService.Delete(id);
            studioService.Save();
            return RedirectToAction("EditService");
        }

        public ActionResult Details(int id)
        {
            var servise = studioService.GetService(id);
            if (servise != null)
            {
                return View(servise);
            }
            return HttpNotFound();
        }

        public ActionResult DetailsExamples(int id)
        {
            var example = studioService.GetExample(id);
            if (example != null)
            {
                return View(example);
            }
            return HttpNotFound();
        }

        public ActionResult DetailsOfMaster(int id)
        {
            var master = studioService.GetMaster(id);
            if (master != null)
            {
                return View(master);
            }
            return HttpNotFound();
        }

        public ActionResult EditService()
        {
            var services = studioService.GetAllServices();
            return View(services);
        }

        public ActionResult Portfolio()
        {
            var examples = studioService.GetAllExamples();
            return View(examples);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
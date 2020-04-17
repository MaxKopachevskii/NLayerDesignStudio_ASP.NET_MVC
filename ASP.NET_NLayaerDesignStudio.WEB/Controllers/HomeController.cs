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
            //var services = unitOfWork.Services.GetAll();
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

        //[HttpPost]
        //public ActionResult Create(ServiceViewModel service)
        //{
        //    //unitOfWork.Services.Create(service);
        //    //unitOfWork.Save();
        //    return RedirectToAction("EditService");
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var service = unitOfWork.Services.Get(id);
            var service = studioService.GetService(id);
            if (service != null)
            {
                return View(service);
            }
            return HttpNotFound();
        }

        //[HttpPost]
        //public ActionResult Edit(Service service)
        //{
        //    if (service != null)
        //    {
        //        unitOfWork.Services.Update(service);
        //        unitOfWork.Save();
        //        return RedirectToAction("EditService");
        //    }
        //    return HttpNotFound();
        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.Services.Delete(id);
        //    unitOfWork.Save();
        //    return RedirectToAction("EditService");
        //}

        public ActionResult Details(int id)
        {
            //var servise = unitOfWork.Services.Get(id);
            var servise = studioService.GetService(id);
            if (servise != null)
            {
                return View(servise);
            }
            return HttpNotFound();
        }

        public ActionResult DetailsExamples(int id)
        {
            //var example = unitOfWork.Examples.Get(id);
            var example = studioService.GetExample(id);
            if (example != null)
            {
                return View(example);
            }
            return HttpNotFound();
        }

        public ActionResult DetailsOfMaster(int id)
        {
            //var master = unitOfWork.Masters.Get(id);
            var master = studioService.GetMaster(id);
            if (master != null)
            {
                return View(master);
            }
            return HttpNotFound();
        }

        public ActionResult EditService()
        {
            //var services = unitOfWork.Services.GetAll();
            var services = studioService.GetAllServices();
            return View(services);
        }

        public ActionResult Portfolio()
        {
            //var examples = unitOfWork.Examples.GetAll();
            var examples = studioService.GetAllExamples();
            return View(examples);
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
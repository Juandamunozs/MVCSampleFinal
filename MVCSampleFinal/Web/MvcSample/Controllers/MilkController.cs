using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MvcSample.Models.MilkModels;
using Services;

namespace MvcSample.Controllers
{
    public class MilkController : Controller
    {

        private IMilkService service;
        IMapper Mapper { get; set; }
        public MilkController(IMilkService _service, IMapper mapper)
        {
            service = _service;
            Mapper = mapper;
        }

        public IActionResult Cows()
        {
            IList<CowModel> cows = Mapper.Map<IList<CowModel>>(service.GetCows());
            CowsModel cowsModel = new CowsModel();
            cowsModel.Cows = cows;
            return View(cowsModel);
        }


        public IActionResult AddCow()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCow(CowModel model)
        {
            IList<CowModel> cows = Mapper.Map<IList<CowModel>>(service.GetCows());
            CowsModel cowsModel = new CowsModel();
            cowsModel.Cows = cows;
            return View(cowsModel);
        }
        //public IActionResult Index(Guid Id)
        //{

        //    service.GetMilkExistences(Id);
        //    return View();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.Controllers
{
    //[Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private readonly IVehicleService _vehicleService;

        public SampleDataController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Route("api/[controller]/Makes")]
        [HttpGet("[action]")]
        public IActionResult Makes()
        {
            var data = _vehicleService.GetMake(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/Models")]
        [HttpGet("[action]")]
        public IActionResult Models()
        {
            var data = _vehicleService.GetModel(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/CreateMake")]
        [HttpPost("[action]")]
        public IActionResult CreateMake([FromForm] VehicleDto vehicle)
        {
            _vehicleService.InsertMake(vehicle);

            return RedirectToAction("Make");
        }

        [Route("api/[controller]/CreateModel")]
        [HttpPost("[action]")]
        public IActionResult CreateModel([FromForm] VehicleDto vehicle)
        {
            _vehicleService.InsertModel(vehicle);

            return RedirectToAction("Model");
        }


        [Route("api/[Controller]/DeleteMake/{id:int}")]
        [HttpDelete("[action]")]
        public IActionResult DeleteMake(int id)
        {
            VehicleDto vehiclemodel = _vehicleService.GetModelByMakeId(id);

            if (vehiclemodel != null)
            {
                _vehicleService.DeleteModel(vehiclemodel);
                DeleteMakeModel(id);
            }
            else
            {
                DeleteMakeModel(id);
            }


            return RedirectToAction("Make");

        }

        public void DeleteMakeModel(int id)
        {
            VehicleDto vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.DeleteMake(vehicle);
        }

        [Route("api/[Controller]/DeleteModel/{id:int}")]
        [HttpDelete("[action]")]
        public IActionResult DeleteModel(int id)
        {
            VehicleDto vehiclemodel = _vehicleService.GetModelById(id);
            _vehicleService.DeleteModel(vehiclemodel);

            return RedirectToAction("Model");

        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditMake/")]
        public IActionResult EditMake(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.UpdateMake(vehicle);

            return RedirectToAction("Make");
        }

        [HttpGet]
        [Route("api/[Controller]/EditMake/{id:int}")]
        public IActionResult EditMake(int id)
        {
            return Ok(_vehicleService.GetMakeById(id));
        }

        [HttpGet]
        [Route("api/[Controller]/EditModel/{id:int}")]
        public IActionResult EditModel(int id)
        {
            return Ok(_vehicleService.GetModelById(id));
        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditModel/")]
        public IActionResult EditModel(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.UpdateModel(vehicle);

            return RedirectToAction("Model");
        }

        [HttpGet]
        [Route("api/[Controller]/DetailsMake/{id:int}")]
        public IActionResult DetailsMake(int id)
        {
            return Ok(_vehicleService.GetMakeById(id));
        }

        [HttpGet]
        [Route("api/[Controller]/DetailsModel/{id:int}")]
        public IActionResult DetailsModel(int id)
        {
            return Ok(_vehicleService.GetModelById(id));
        }
    }
}

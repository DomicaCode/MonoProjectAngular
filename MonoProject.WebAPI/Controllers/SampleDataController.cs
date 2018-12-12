using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonoProject.Service.Common;
using MonoProject.Model;
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
        public async Task<IActionResult> AsyncMakes()
        {
            var data = await _vehicleService.AsyncGetMake(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/Models")]
        [HttpGet("[action]")]
        public async Task<IActionResult> AsyncModels()
        {
            var data = await _vehicleService.GetModel(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/CreateMake")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AsyncCreateMake([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.AsyncInsertMake(vehicle);

            return Redirect("./fetch-data");
        }

        [Route("api/[controller]/CreateModel")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AsyncCreateModel([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.AsyncInsertModel(vehicle);

            return RedirectToAction("Model");
        }


        [Route("api/[Controller]/DeleteMake/{id:int}")]
        [HttpDelete("[action]")]
        public async Task <IActionResult> AsyncDeleteMake(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.AsyncGetModelByMakeId(id);

            if (vehiclemodel != null)
            {
                await _vehicleService.AsyncDeleteModel(vehiclemodel);
                await AsyncDeleteMakeModel(id);
            }
            else
            {
                await AsyncDeleteMakeModel(id);
            }


            return RedirectToAction("Make");

        }

        public async Task AsyncDeleteMakeModel(int id)
        {
            VehicleDto vehicle = await _vehicleService.AsyncGetMakeById(id);
            await _vehicleService.AsyncDeleteMake(vehicle);
        }

        [Route("api/[Controller]/DeleteModel/{id:int}")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> AsyncDeleteModel(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.AsyncGetModelById(id);
            await _vehicleService.AsyncDeleteModel(vehiclemodel);

            return RedirectToAction("Model");

        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditMake/")]
        public async Task<IActionResult> AsyncEditMake(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            await _vehicleService.AsyncUpdateMake(vehicle);

            return RedirectToAction("Make");
        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditModel/")]
        public async Task<IActionResult> AsyncEditModel(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            await _vehicleService.AsyncUpdateModel(vehicle);

            return RedirectToAction("Model");
        }

        [HttpGet]
        [Route("api/[Controller]/GetMake/{id:int}")]
        public async Task<IActionResult> AsyncGetMakeObjectById(int id)
        {
            return Ok(await _vehicleService.AsyncGetMakeById(id));
        }

        [HttpGet]
        [Route("api/[Controller]/GetModel/{id:int}")]
        public async Task<IActionResult> AsyncGetModelObjectById(int id)
        {
            return Ok(await _vehicleService.AsyncGetModelById(id));
        }
    }
}

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
        public async Task<IActionResult> Makes()
        {
            var data = await _vehicleService.GetMake(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/Models")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Models()
        {
            var data = await _vehicleService.GetModel(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/CreateMake")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMake([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.InsertMake(vehicle);

            return RedirectToAction("Make");
        }

        [Route("api/[controller]/CreateModel")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateModel([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.InsertModel(vehicle);

            return RedirectToAction("Model");
        }


        [Route("api/[Controller]/DeleteMake/{id:int}")]
        [HttpDelete("[action]")]
        public async Task <IActionResult> DeleteMake(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.GetModelByMakeId(id);

            if (vehiclemodel != null)
            {
                await _vehicleService.DeleteModel(vehiclemodel);
                await DeleteMakeModel(id);
            }
            else
            {
                await DeleteMakeModel(id);
            }


            return RedirectToAction("Make");

        }

        public async Task DeleteMakeModel(int id)
        {
            VehicleDto vehicle = await _vehicleService.GetMakeById(id);
            await _vehicleService.DeleteMake(vehicle);
        }

        [Route("api/[Controller]/DeleteModel/{id:int}")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.GetModelById(id);
            await _vehicleService.DeleteModel(vehiclemodel);

            return RedirectToAction("Model");

        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditMake/")]
        public async Task<IActionResult> EditMake(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            await _vehicleService.UpdateMake(vehicle);

            return RedirectToAction("Make");
        }

        [HttpGet]
        [Route("api/[Controller]/EditMake/{id:int}")]
        public async Task<IActionResult> EditMake(int id)
        {
            return Ok(await _vehicleService.GetMakeById(id));
        }

        [HttpGet]
        [Route("api/[Controller]/EditModel/{id:int}")]
        public async Task<IActionResult> EditModel(int id)
        {
            return Ok(await _vehicleService.GetModelById(id));
        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditModel/")]
        public async Task<IActionResult> EditModel(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            await _vehicleService.UpdateModel(vehicle);

            return RedirectToAction("Model");
        }

        [HttpGet]
        [Route("api/[Controller]/DetailsMake/{id:int}")]
        public async Task<IActionResult> DetailsMake(int id)
        {
            return Ok(await _vehicleService.GetMakeById(id));
        }

        [HttpGet]
        [Route("api/[Controller]/DetailsModel/{id:int}")]
        public async Task<IActionResult> DetailsModel(int id)
        {
            return Ok(await _vehicleService.GetModelById(id));
        }
    }
}

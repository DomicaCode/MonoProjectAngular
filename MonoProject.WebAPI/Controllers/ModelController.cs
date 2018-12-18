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
    public class ModelController : Controller
    {

        private readonly IVehicleService _vehicleService;


        public ModelController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Route("api/[controller]/Models")]
        [HttpGet("[action]")]
        public async Task<IActionResult> ModelsAsync()
        {
            var data = await _vehicleService.GetModelAsync(0, 10);

            return Ok(data);
        }


        [Route("api/[controller]/CreateModel")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateModelAsync([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.InsertModelAsync(vehicle);

            return RedirectToAction("Model");
        }


        [Route("api/[Controller]/DeleteModel/{id:int}")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteModelAsync(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.GetModelByIdAsync(id);
            await _vehicleService.DeleteModelAsync(vehiclemodel);

            return RedirectToAction("Model");

        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditModel/")]
        public async Task<IActionResult> EditModelAsync(VehicleDto vehicle)
        {
            await _vehicleService.UpdateModelAsync(vehicle);

            return RedirectToAction("Model");
        }


        [HttpGet]
        [Route("api/[Controller]/GetModel/{id:int}")]
        public async Task<IActionResult> GetModelObjectByIdAsync(int id)
        {
            return Ok(await _vehicleService.GetModelByIdAsync(id));
        }
    }
}

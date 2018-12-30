using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonoProject.Service.Common;
using MonoProject.Model;
using Microsoft.AspNetCore.Mvc;
using MonoProject.WebAPI.ViewModels;
using MonoProject.Model.Interfaces;

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

            var vehicleDto = AutoMapper.Mapper.Map<IEnumerable<IVehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return Ok(vehicleDto);
        }


        [Route("api/[controller]/CreateModel")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateModelAsync([FromForm] VehicleDto vehicle)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicle);

            await _vehicleService.InsertModelAsync(entity);

            return RedirectToAction("Model");
        }


        [Route("api/[Controller]/DeleteModel/{id:int}")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteModelAsync(int id)
        {

            await _vehicleService.DeleteModelAsync(id);

            return RedirectToAction("Model");

        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditModel/")]
        public async Task<IActionResult> EditModelAsync(VehicleDto vehicle)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicle);

            await _vehicleService.UpdateModelAsync(entity);

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

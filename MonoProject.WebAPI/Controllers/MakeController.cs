using Microsoft.AspNetCore.Mvc;
using MonoProject.Model;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MonoProject.WebAPI.Controllers
{
    public class MakeController : Controller
    {
        private readonly IVehicleService _vehicleService;


        public MakeController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Route("api/[controller]/Makes")]
        [HttpGet("[action]")]
        public async Task<IActionResult> MakesAsync()
        {
            var data = await _vehicleService.GetMakeAsync(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/CreateMake")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMakeAsync([FromForm] VehicleDto vehicle)
        {
            await _vehicleService.InsertMakeAsync(vehicle);

            return Redirect("./fetch-data");
        }

        [Route("api/[Controller]/DeleteMake/{id:int}")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMakeAsync(int id)
        {
            VehicleDto vehiclemodel = await _vehicleService.GetModelByMakeIdAsync(id);

            if (vehiclemodel != null)
            {
                await _vehicleService.DeleteModelAsync(vehiclemodel);
                await DeleteMakeModelAsync(id);
            }
            else
            {
                await DeleteMakeModelAsync(id);
            }


            return RedirectToAction("Make");

        }

        public async Task DeleteMakeModelAsync(int id)
        {
            VehicleDto vehicle = await _vehicleService.GetMakeByIdAsync(id);
            await _vehicleService.DeleteMakeAsync(vehicle);
        }

        [HttpPut("[action]")]
        [Route("api/[Controller]/EditMake/")]
        public async Task<IActionResult> EditMakeAsync(VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            await _vehicleService.UpdateMakeAsync(vehicle);

            return RedirectToAction("Make");
        }

        [HttpGet]
        [Route("api/[Controller]/GetMake/{id:int}")]
        public async Task<IActionResult> GetMakeObjectByIdAsync(int id)
        {
            return Ok(await _vehicleService.GetMakeByIdAsync(id));
        }
    }
}

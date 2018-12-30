using MonoProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model
{
    public class VehicleMakeEntity : IVehicleMakeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public List<VehicleModelEntity> Models { get; set; }
    }
}

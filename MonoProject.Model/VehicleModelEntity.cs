using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public VehicleMakeEntity Make { get; set; }
    }
}

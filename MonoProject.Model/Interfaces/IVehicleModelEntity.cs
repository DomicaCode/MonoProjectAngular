using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model.Interfaces
{
    public interface IVehicleModelEntity
    {
        int Id { get; set; }

        int MakeId { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        VehicleMakeEntity Make { get; set; }
    }
}

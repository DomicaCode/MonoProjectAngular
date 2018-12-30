using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model.Common
{
    public interface IVehicleModelEntity
    {
        int Id { get; set; }

        int MakeId { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        IVehicleMakeEntity Make { get; }
    }
}

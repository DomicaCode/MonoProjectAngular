using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model.Common
{
     public interface IVehicleMakeEntity
    {
        int Id { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        List<IVehicleModelEntity> Models { get;}
    }
}

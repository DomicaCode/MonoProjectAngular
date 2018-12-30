using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model.Interfaces
{
    public interface IVehicleMakeEntity
    {
        /*
        Razlog zasto je Interface u MonoProject.Model (a ne u MonoProject.Model.Common) projektu jer nisam nikako mogao zaobici reference problem
        Moram imati List<Model>, no interface u drugom projektu ne moze znati za modele.
        Pokusao sam nesto poput ovog:
        public List<VehicleModelEntity> Models { get; set; }

        List<IVehicleModelEntity> IVehicleMakeEntity.Models
        {
            get
            {
                return this.Models.Cast<IVehicleModelEntity>().ToList();
            }
            set { }
        }

        Da zaobidem taj problem, no i dalje sam imao poteskocu jer ne mogu imati set{} za to, te bez set{} opet imam poteskoca sa ostalim kodom.

            Ako imate rjesenje, javite.
        */


        int Id { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        List<VehicleModelEntity> Models { get; set; }
    }
}

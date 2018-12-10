using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Data.Services;
using Data.Interfaces;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MonoProject.Tests
{
    public class VehicleServiceModelsTest
    {
        /* Imam jos dosta za istraziti u vezi unit testinga
           Nisam znao sto tocno treba tesitrati.
           Updatat cu nakon sto naucim vise.
        */


        [Fact]
        public void InsertModelTest()
        {
            //arrange
            var vehiclemake = new VehicleMakeEntity();
            var vehiclemodel = new VehicleModelEntity();
            var vehicledto = new VehicleDto();

            var testMakeRepository = new Mock<IMakeRepository>();
            testMakeRepository.Setup(m => m.Insert(vehiclemake))
                .Returns(Task.CompletedTask);
            var testModelRepository = new Mock<IModelRepository>();
            testModelRepository.Setup(m => m.Insert(vehiclemodel))
                .Returns(Task.CompletedTask);

            //var options = new DbContextOptionsBuilder<ProjectDbContext>().UseInMemoryDatabase(databaseName: "mono").Options;

            var context = new Mock<ProjectDbContext>();

            context.Setup(m => m.Add(vehiclemake));

            var testingClass = new VehicleService(testMakeRepository.Object, testModelRepository.Object, context.Object);

            //act

            var insertMethod = testingClass.InsertModel(vehicledto);

            //assert
            //testingClass.InsertModel().Should().


            Assert.True(insertMethod.IsCompletedSuccessfully);
        }

        /*
        [Fact]
        public void InsertModelTestTwo()
        {
            var data = new List<VehicleModelEntity>
            {
                new VehicleModelEntity{ Id = 1, MakeId = 1 ,Name = "test1", Abrv = "test1" },
                new VehicleModelEntity{ Id = 2, MakeId = 2 ,Name = "test2", Abrv = "test2" },
                new VehicleModelEntity{ Id = 3, MakeId = 3 ,Name = "test3", Abrv = "test3" },
            }.AsQueryable();
        }
        */
    }
}

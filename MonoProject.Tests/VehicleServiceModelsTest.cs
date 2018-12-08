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

            var context = new ProjectDbContext();

            var testingClass = new VehicleService(testMakeRepository.Object, testModelRepository.Object, context);

            //act

            var insertMethod = testingClass.InsertModel(vehicledto);

            //assert
            //testingClass.InsertModel().Should().

            Assert.True(insertMethod.IsCompletedSuccessfully);
        }
    }
}

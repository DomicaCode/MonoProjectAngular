using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using MonoProject.DAL;
using MonoProject.Model;
using MonoProject.Service;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MonoProject.Repository.Common;

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

            var testMakeRepository = new Mock<IGenericRepository<VehicleMakeEntity>>();
            testMakeRepository.Setup(m => m.AsyncInsert(vehiclemake))
                .Returns(Task.CompletedTask);
            var testModelRepository = new Mock<IGenericRepository<VehicleModelEntity>>();
            testModelRepository.Setup(m => m.AsyncInsert(vehiclemodel))
                .Returns(Task.CompletedTask);

            var testUnitOfWork = new Mock<IUnitOfWork>();

            //var options = new DbContextOptionsBuilder<ProjectDbContext>().UseInMemoryDatabase(databaseName: "mono").Options;

            var context = new Mock<ProjectDbContext>();

            context.Setup(m => m.Add(vehiclemake));

            var testingClass = new VehicleService(context.Object, testUnitOfWork.Object);

            //act

            var insertMethod = testingClass.AsyncInsertModel(vehicledto);

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

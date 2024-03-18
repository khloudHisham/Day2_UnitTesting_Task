using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;
using CarFactoryMVC.Payment;
using CarFactoryMVC.Repositories_DAL;
using CarFactoryMVC.Services_BLL;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CarFactoryMVC_Test
{
    public class CarsServiceTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private Mock<ICarsRepository> carRepoMock;
        private CarsService carsService;

        public CarsServiceTests(ITestOutputHelper testOutputHelper)
        {
            // test setup
            _output = testOutputHelper;
            _output.WriteLine("Test setup");

            // Create mock for dependencies
            carRepoMock = new Mock<ICarsRepository>();
            carsService = new CarsService(carRepoMock.Object);
        }

        public void Dispose()
        {
            // Test cleanup
            _output.WriteLine("Test Cleanup");
            // Clean test DB state
        }

        [Fact]
        public void GetAll_ListCars_Found()
        {
            _output.WriteLine("GetAll");

            // Arrange
            var car1 = new Car { Id = 1 };
            var cars = new List<Car>
            {
                car1,
                new Car { Id = 2 },
                new Car { Id = 3 }
            };
            carRepoMock.Setup(c => c.GetAllCars()).Returns(cars);

            // Act
            var result = carsService.GetAll();

            // Assert
            Assert.Contains(car1, result);
        }

        [Fact]
        public void GetCarById_CarExist_ReturnCar()
        {
            _output.WriteLine("GetCarById_CarExist_ReturnCar");

            // Arrange
            var carId = 20;
            var car = new Car { Id = carId };
            carRepoMock.Setup(repo => repo.GetCarById(carId)).Returns(car);

            // Act
            var result = carsService.GetCarById(carId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(car, result);
        }

        [Theory]
        [InlineData(1)]
        public void GetCarById_CarNotExist_ReturnNull(int id)
        {
            _output.WriteLine("GetCarById_CarNotExist_ReturnNull");

            // Arrange
            carRepoMock.Setup(repo => repo.GetCarById(id)).Returns((Car)null);

            // Act
            var result = carsService.GetCarById(id);

            // Assert
            Assert.Null(result);
        }
    }
}

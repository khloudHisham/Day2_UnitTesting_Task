using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarStoreTests
    {
        [Fact]

        public void AddCar_car_NotEmpty()
        {
            //Arrange
            CarStore carStore = new CarStore();
            Car car = new Toyota { velocity = 10, drivingMode = DrivingMode.Forward };

            //Act

            carStore.AddCar(car);

            //Assert
            //    carStore.NotEmpty(carStore.cars);
            Assert.NotEmpty(carStore.cars);

        }

        [Fact]
        public void AddCars_ListOFCars_True()
        {
            // Arrange
            CarStore carStore = new CarStore();

            Car car = new Toyota { velocity = 0, drivingMode = DrivingMode.Stopped };
            List<Car> cars = new List<Car>()
         {
             car,
             new BMW{velocity = 15, drivingMode=DrivingMode.Forward},

         };

            //Act
            carStore.AddCars(cars);

            //value Equality
            Assert.Contains<Car>(car, carStore.cars);
        }
    }
}

using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarTests
    {

        [Fact]

        public void TimeToCoverDistance_CarVelocity10ForDistance20_10s()
        {
            // Arrange
            Car car = new Toyota() { velocity = 10 };

            // Act
            double time = car.TimeToCoverDistance(20);

            // Boolean Assert
            Assert.Equal(2, time);
        }

        [Fact]
        public void Stop_isStop_true()
        {
            // Arrange
            Car car = new Toyota() { velocity = 20, drivingMode = DrivingMode.Forward };

            // Act
            car.Stop();
            var result = car.IsStopped();

            // Boolean Assert
            Assert.True(result); //pass
                                 //Assert.False(result);  //Fail
        }

        [Fact]
        public void GetMyCar_car_Equal()
        {
            // Arrange
            Car car = new Toyota();


            // Act
            Car RefCar = car.GetMyCar();

            // Assert
            Assert.Equal<Car>(car, RefCar);
        }

        [Fact]
        public void GetDirection_CarModeForward_Stopped()
        {
            // Arrange
            Car car = new Toyota() { velocity = 0, drivingMode = DrivingMode.Stopped };

            // Act
            var result = car.GetDirection();

            // Assert

            Assert.DoesNotContain("War", result);

        }

        [Fact]

        public void Accelerate_CarVelocity20_VelocityIncrease()
        {
            // Arrage

            Car car = new Toyota { velocity = 20 };

            // Act
            car.Accelerate();   // range 5 to 15

            //  Assert
            Assert.InRange(car.velocity, 20, 30);

        }
    }
}

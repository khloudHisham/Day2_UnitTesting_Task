using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
  
    public class CarFactoryTests
    {
        [Fact]

        [Trait("Author", "khokha")]
        [Trait("Priority", "1")]
        public void NewCar_AskForBMW_BMW()
        {

            // Act
            var result = CarFactory.NewCar(CarTypes.BMW);

            //  Assert
            Assert.IsType<BMW>(result);
        }


        [Fact]
        [Trait("Author", "Ali")]
        [Trait("Priority", "2")]
        public void NewCar_AskForAudi_NotNull()
        {
            // Act
            var result = CarFactory.NewCar(CarTypes.BMW);

            // Reference Assert
            Assert.NotNull(result);
        }

        [Fact(Skip = "Working on adding Honda")]
        [Trait("Author", "Sally")]
        [Trait("Priority", "3")]
        public void NewCar_AskForHonda_Exception()
        {

            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
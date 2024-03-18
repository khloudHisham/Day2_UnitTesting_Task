using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryMVC_Test
{
    public class OwnerRepositoryTests
    {
        [Fact]
        public void GetAllOwners_returnOwnerList()
        {
            // Arrange
            // Create mock of dependencies
            Mock<FactoryContext> factoryContext = new Mock<FactoryContext>();

            // prepare mock data
            List<Owner> owners = new List<Owner>()
            {
                new Owner(){Id = 10,Name="Amr"},
                new Owner(){Id = 20,Name="khloud"},
                new Owner(){Id = 30 , Name="Noha"},
            };

            // setup called Dbset
            factoryContext.Setup(fc=>fc.Owners).ReturnsDbSet(owners);

            // use the fake object as dependency
            OwnerRepository ownerRepository = new OwnerRepository(factoryContext.Object);

            // Act
            List<Owner> result = ownerRepository.GetAllOwners();

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}

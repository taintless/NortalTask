using eShop.Data.Entities;
using eShop.DataContracts;
using eShop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Tests.UnitTests
{
    [TestClass]
    public class FiltersServiceTests
    {
        private readonly Mock<IManufacturersRepository> _manufacturersRepositoryMock;
        private readonly Mock<IOsesRepository> _osesRepositoryMock;
        private readonly Mock<IProductsRepository> _productsRepositoryMock;

        private FiltersService _filtersService;

        public FiltersServiceTests()
        {
            _manufacturersRepositoryMock = new Mock<IManufacturersRepository>();
            _osesRepositoryMock = new Mock<IOsesRepository>();
            _productsRepositoryMock = new Mock<IProductsRepository>();
            _filtersService = new FiltersService(_manufacturersRepositoryMock.Object, _osesRepositoryMock.Object, _productsRepositoryMock.Object);
        }

        [TestMethod]
        public async Task ShoudReturnManufacturers()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer {
                    Id = 1
                }
            };

            _manufacturersRepositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult(manufacturers));

            Assert.IsTrue((await _filtersService.GetAll()).Manufacturers.Exists(x => x.Id == 1));
        }

        [TestMethod]
        public async Task ShoudReturnOses()
        {
            var oses = new List<Os>
            {
                new Os {
                    Id = 1
                }
            };

            _osesRepositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult(oses));

            Assert.IsTrue((await _filtersService.GetAll()).Oses.Exists(x => x.Id == 1));
        }

        [TestMethod]
        public async Task ShoudReturnStorages()
        {
            var storages = new List<int>
            {
                16
            };

            _productsRepositoryMock.Setup(x => x.GetDifferentStorages()).Returns(Task.FromResult(storages));

            Assert.IsTrue((await _filtersService.GetAll()).Storages.Contains(16));
        }

        [TestMethod]
        public async Task ShoudReturnAvgStorage()
        {
            double avg = 10;

            _productsRepositoryMock.Setup(x => x.GetAverageStorage()).Returns(Task.FromResult(avg));

            Assert.AreEqual(avg, (await _filtersService.GetAll()).AvgStorage);
        }

        [TestMethod]
        public async Task ShoudReturnAvgCamera()
        {
            double avg = 10;

            _productsRepositoryMock.Setup(x => x.GetAverageCamera()).Returns(Task.FromResult(avg));

            Assert.AreEqual(avg, (await _filtersService.GetAll()).AvgCamera);
        }
    }
}

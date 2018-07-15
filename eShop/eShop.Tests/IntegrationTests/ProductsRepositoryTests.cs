using AutoMapper;
using eShop.Data;
using eShop.Data.Entities;
using eShop.Data.Repositories;
using eShop.DataContracts.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Tests.IntegrationTests
{
    [TestClass]
    public class ProductsRepositoryTests
    {
        private readonly DbContextOptionsBuilder<AppDbContext> _optionsBuilder;
        private readonly AppDbContext _dbContext;
        private readonly ProductsRepository _productsRepository;

        public ProductsRepositoryTests()
        {
            _optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=eShop-testing;Trusted_Connection=True;");
            _dbContext = new AppDbContext(_optionsBuilder.Options);
            _productsRepository = new ProductsRepository(_dbContext);
        }

        [TestMethod]
        public async Task ShouldContaintExistingItem()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var product = new Product
                {
                    Price = 100,
                    Storage = 32,
                    Camera = 5,
                    Manufacturer = new Manufacturer(),
                    Os = new Os()
                };

                _dbContext.Add(product);
                _dbContext.SaveChanges();

                var itemExists = await _productsRepository.GetFiltered(new ProductsRequest());

                Assert.IsTrue(itemExists.Exists(x => x.Id == product.Id));

                transaction.Rollback();
            }
        }

        [TestMethod]
        public async Task ShouldContaintDifferentStorages()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Price = 100,
                        Storage = 32,
                        Camera = 5,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    },
                    new Product
                    {
                        Price = 100,
                        Storage = 32,
                        Camera = 5,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    },
                    new Product
                    {
                        Price = 100,
                        Storage = 16,
                        Camera = 5,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    }
                };

                _dbContext.AddRange(products);
                _dbContext.SaveChanges();

                var storages = await _productsRepository.GetDifferentStorages();

                Assert.IsTrue(storages.Exists(x => x == 16));
                Assert.IsTrue(storages.Exists(x => x == 32));

                transaction.Rollback();
            }
        }

        [TestMethod]
        public async Task ShouldReturnAverageCamera()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Price = 100,
                        Storage = 32,
                        Camera = 5,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    },
                    new Product
                    {
                        Price = 100,
                        Storage = 32,
                        Camera = 10,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    },
                    new Product
                    {
                        Price = 100,
                        Storage = 16,
                        Camera = 12,
                        Manufacturer = new Manufacturer(),
                        Os = new Os()
                    }
                };

                _dbContext.AddRange(products);
                _dbContext.SaveChanges();

                var avgCamera = await _productsRepository.GetAverageCamera();

                Assert.AreEqual(products.Select(x => x.Camera).Average(), avgCamera);

                transaction.Rollback();
            }
        }
    }
}

using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace TestCore
{
    [TestFixture]
    public class ProductCategoryServiceTests
    {
        private Mock<IProductCategory> _productCategoryMock;
        private Mock<IProductService> _productServiceMock;
        private IProductCategoryService _service;

        [SetUp]
        public void Setup()
        {
            _productCategoryMock = new Mock<IProductCategory>();
            _productServiceMock = new Mock<IProductService>();
            _service = new ProductCategoryService(_productCategoryMock.Object, _productServiceMock.Object);
        }

        [Test]
        public void GetAll_ReturnsProductsForCategory()
        {
            // Arrange
            int categoryId = 1;
            var productCategories = new List<ProductCatergory>
            {
                new ProductCatergory(1, "Zuivel", categoryId, 10),
                new ProductCatergory(2, "Zuivel", categoryId, 20)
            };
            var product1 = new Product(10, "Milk", 5);
            var product2 = new Product(20, "Cheese", 3);

            _productCategoryMock.Setup(x => x.GetAll(categoryId)).Returns(productCategories);
            _productServiceMock.Setup(x => x.Get(10)).Returns(product1);
            _productServiceMock.Setup(x => x.Get(20)).Returns(product2);

            // Act
            var result = _service.GetAll(categoryId);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.Contains(product1, result);
            Assert.Contains(product2, result);
        }

        [Test]
        public void GetAll_SkipsNullProducts()
        {
            // Arrange
            int categoryId = 1;
            var productCategories = new List<ProductCatergory>
            {
                new ProductCatergory(1, "Zuivel", categoryId, 10),
                new ProductCatergory(2, "Zuivel", categoryId, 20)
            };

            _productCategoryMock.Setup(x => x.GetAll(categoryId)).Returns(productCategories);
            _productServiceMock.Setup(x => x.Get(10)).Returns((Product)null);
            _productServiceMock.Setup(x => x.Get(20)).Returns(new Product(20, "Cheese", 3));

            // Act
            var result = _service.GetAll(categoryId);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(20, result[0].Id);
        }

        [Test]
        public void AddProductToCategory_CallsRepositoryAdd()
        {
            // Arrange
            var product = new Product(1, "Bread", 10);
            var category = new Category(2, "Bakery");

            // Act
            _service.AddProductToCategory(product, category);

            // Assert
            _productCategoryMock.Verify(x => x.Add(product, category), Times.Once);
        }

        [Test]
        public void AddProductToCategory_DoesNotCallAdd_WhenProductOrCategoryIsNull()
        {
            // Act
            _service.AddProductToCategory(null, new Category(1, "Bakery"));
            _service.AddProductToCategory(new Product(1, "Bread", 10), null);

            // Assert
            _productCategoryMock.Verify(x => x.Add(It.IsAny<Product>(), It.IsAny<Category>()), Times.Never);
        }
    }
}
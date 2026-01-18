using E_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.UnitTests.Core.Models
{
    public class ProductTests
    {
        private readonly Guid _testId;
        private readonly string _testName;
        private readonly string _testDescription;
        private readonly decimal _testPrice;
        private readonly Guid? _testCategoryId;
        private readonly string _testImage;
        private readonly bool _testIsAvailable;

        public ProductTests()
        {
            _testId = Guid.NewGuid();
            _testName = "iPhone 15";
            _testDescription = "cмартфон Apple";
            _testPrice = 99999.99m;
            _testCategoryId = Guid.NewGuid();
            _testImage = "https://topzero.com/wp-content/uploads/2020/06/topzero-products-Malmo-Matte-Black-TZ-PE458M-image-003.jpg";
            _testIsAvailable = true;
        }



        [Fact]
        public void Create_WithValidParameters_ReturnsSuccessResult()
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                _testPrice,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.True(result.IsSuccess);

            var product = result.Value;
            Assert.Equal(_testId, product.Id);
            Assert.Equal(_testName, product.Name);
            Assert.Equal(_testDescription, product.Description);
            Assert.Equal(_testPrice, product.Price);
            Assert.Equal(_testCategoryId, product.CategoryId);
            Assert.Equal(_testImage, product.Image);
            Assert.Equal(_testIsAvailable, product.IsAvailable);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithInvalidName_ReturnsFailureResult(string invalidName)
        {
            var result = Product.Create(
                _testId,
                invalidName,
                _testDescription,
                _testPrice,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.False(result.IsSuccess);
            Assert.Contains("Название не может быть пустым", result.Error);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-9999.99)]
        [InlineData(0.99)]
        public void Create_WithInvalidPrice_ReturnsFailureResult(decimal invalidPrice)
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                invalidPrice,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.False(result.IsSuccess);
            Assert.Contains("Цена не может быть меньше 1", result.Error);
        }

        [Fact]
        public void Create_WithPriceOne_ReturnsSuccessResult()
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                1.00m,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.True(result.IsSuccess);
            Assert.Equal(1.00m, result.Value.Price);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithEmptyDescription_SetsDefault(string emptyDescription)
        {
            var result = Product.Create(
                _testId,
                _testName,
                emptyDescription,
                _testPrice,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.True(result.IsSuccess);
            Assert.Equal("no description", result.Value.Description);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithEmptyImage_SetsDefault(string emptyImage)
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                _testPrice,
                _testCategoryId,
                emptyImage,
                _testIsAvailable);

            Assert.True(result.IsSuccess);
            Assert.Equal("https://topzero.com/wp-content/uploads/2020/06/topzero-products-Malmo-Matte-Black-TZ-PE458M-image-003.jpg", result.Value.Image);
        }


        [Fact]
        public void Create_WithNullCategoryId_ReturnsSuccessResult()
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                _testPrice,
                null,
                _testImage,
                _testIsAvailable);

            Assert.True(result.IsSuccess);
            Assert.Null(result.Value.CategoryId);
        }

        [Fact]
        public void Create_WithIsAvailableFalse_ReturnsSuccessWithCorrectValue()
        {
            var result = Product.Create(
                _testId,
                _testName,
                _testDescription,
                _testPrice,
                _testCategoryId,
                _testImage,
                false);

            Assert.True(result.IsSuccess);
            Assert.False(result.Value.IsAvailable);
        }

        [Fact]
        public void Create_WithLongName_ReturnsFailureResult()
        {
            var longName = new string('A', 301);

            var result = Product.Create(
                _testId,
                longName,
                _testDescription,
                _testPrice,
                _testCategoryId,
                _testImage,
                _testIsAvailable);

            Assert.False(result.IsSuccess);
            Assert.Contains("Длина названия не может превышать 300 симмволов", result.Error);
        }

        [Fact]
        public void Create_WithMinimumdData_ReturnsSuccessResult()
        {
            var minimalProduct = Product.Create(
                Guid.NewGuid(),
                "A", 
                " ",
                1.00m,
                null,
                " ", 
                true);

            Assert.True(minimalProduct.IsSuccess);
        }

    }




}


using E_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.UnitTests.Core.Models
{
    public class UserTests
    {
        private readonly Guid _testId;
        private readonly string _testName;
        private readonly string _testEmail;
        private readonly string _testLogin;
        private readonly string _testPassword;
        private readonly string _testImage;

        public UserTests()
        {
            _testId = Guid.NewGuid();
            _testName = "Тест Тестов";
            _testEmail = "test@testing.com";
            _testLogin = "test1";
            _testPassword = "test123";
            _testImage = "https://www.no5.com/media/1772/place-holder-image.png";

            Users.UserCounter = 0;
        }

        [Fact]
        public void Create_WithValidParameters_ReturnsSuccessResult()
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                _testLogin,
                _testPassword,
                _testImage);

            Assert.True(result.IsSuccess);

            var user = result.Value;
            Assert.Equal(_testId, user.Id);
            Assert.Equal(_testName, user.Name);
            Assert.Equal(_testEmail, user.Email);
            Assert.Equal(_testLogin, user.Login);
            Assert.Equal(_testPassword, user.Password);
            Assert.Equal(_testImage, user.ProfileImage);
            Assert.Equal(1, Users.UserCounter);
        }

        [Theory]
        [InlineData("test_1")]
        [InlineData("test-1")]
        [InlineData("test.1")]
        [InlineData("тест1")]
        [InlineData("test 1")]
        [InlineData("test@1")]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithInvalidLogin_ReturnsFailureResult(string invalidLogin)
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                invalidLogin,
                _testPassword,
                _testImage);

            Assert.False(result.IsSuccess);
            Assert.Contains("Для поля Login запрещены все символы кроме латинских букв и цифр", result.Error);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("TEST")]
        [InlineData("123456")]
        [InlineData("Test1")]
        [InlineData("a")]
        [InlineData("TE23st")]
        public void Create_WithValidLogin_ReturnsSuccessResult(string validLogin)
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                validLogin,
                _testPassword,
                _testImage);

            Assert.True(result.IsSuccess);
            Assert.Equal(validLogin, result.Value.Login);
        }

        [Theory]
        [InlineData("te_st")]
        [InlineData("te-st")]
        [InlineData("te.st")]
        [InlineData("тест123")]
        [InlineData("test 123")]
        [InlineData("test@123")]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithInvalidPassword_ReturnsFailureResult(string invalidPassword)
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                _testLogin,
                invalidPassword,
                _testImage);

            Assert.False(result.IsSuccess);
            Assert.Contains("Для поля Password запрещены все символы кроме латинских букв и цифр", result.Error);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("TEST")]
        [InlineData("12345678")]
        [InlineData("test123")]
        [InlineData("a")]
        [InlineData("Te23ST")]
        public void Create_WithValidPassword_ReturnsSuccessResult(string validPassword)
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                _testLogin,
                validPassword,
                _testImage);

            Assert.True(result.IsSuccess);
            Assert.Equal(validPassword, result.Value.Password);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithEmptyImage_SetsDefault(string emptyImage)
        {
            var result = Users.Create(
                _testId,
                _testName,
                _testEmail,
                _testLogin,
                _testPassword,
                emptyImage);

            Assert.True(result.IsSuccess);
            Assert.Equal("https://www.no5.com/media/1772/place-holder-image.png", result.Value.ProfileImage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_WithEmptyName_SetsDefaultNameWithCounter(string emptyName)
        {
            Users.UserCounter = 5;

            var result = Users.Create(
                _testId,
                emptyName,
                _testEmail,
                _testLogin,
                _testPassword,
                _testImage);

            Assert.True(result.IsSuccess);
            Assert.Equal("user5", result.Value.Name);
            Assert.Equal(6, Users.UserCounter);
        }

        [Fact]
        public void UserCounter_IncrementsOnEachCreation()
        {
            Assert.Equal(0, Users.UserCounter);

            var user1 = Users.Create(
                Guid.NewGuid(),
                "user1",
                "user1@test.com",
                "login1",
                "pass1",
                null);

            Assert.Equal(1, Users.UserCounter);

            var user2 = Users.Create(
                Guid.NewGuid(),
                "user2",
                "user2@test.com",
                "login2",
                "pass2",
                null);

            Assert.Equal(2, Users.UserCounter);

            Assert.True(user1.IsSuccess);
            Assert.True(user2.IsSuccess);
            Assert.Equal("user1", user1.Value.Name);
        }

        [Fact]
        public void Create_With_GenerateUniqueDefaultNames()
        {
            Users.UserCounter = 0;

            var user1 = Users.Create(
                Guid.NewGuid(),
                "", 
                "user1@test.com",
                "login1",
                "pass1",
                null);

            var user2 = Users.Create(
                Guid.NewGuid(),
                null,
                "user2@test.com",
                "login2",
                "pass2",
                null);

            var user3 = Users.Create(
                Guid.NewGuid(),
                "   ",
                "user3@test.com",
                "login3",
                "pass3",
                null);

            Assert.True(user1.IsSuccess);
            Assert.True(user2.IsSuccess);
            Assert.True(user3.IsSuccess);

            Assert.Equal("user0", user1.Value.Name);
            Assert.Equal("user1", user2.Value.Name);
            Assert.Equal("user2", user3.Value.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("test-st-test")]
        [InlineData("@test.com")]
        public void Create_WithInvalidEmail_ReturnsFailure(string email)
        {
            var result = Users.Create(
                _testId,
                _testName,
                email,
                _testLogin,
                _testPassword,
                _testImage);

            Assert.False(result.IsSuccess);
            Assert.Equal("Неверный формат email", result.Error);
        }

        [Theory]
        [InlineData("test@test.com")]
        [InlineData("test.test@test.com")]
        public void Create_WithValidEmail_ReturnsSuccess(string email)
        {
            var result = Users.Create(
                _testId,
                _testName,
                email,
                _testLogin,
                _testPassword,
                _testImage);

            Assert.True(result.IsSuccess);
        }
    }
}


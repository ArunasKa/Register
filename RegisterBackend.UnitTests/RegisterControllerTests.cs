using Microsoft.AspNetCore.Mvc;
using Moq;
using RegisterApi.BL.Interfaces;
using RegisterApi.Controllers;
using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;

namespace RegisterBackend.UnitTests
{
    public class RegisterControllerTests
    {
        private Mock<IRegisterService> _registerServiceMock;
        private RegisterController _sut;
        private static int testId = testId;
        public RegisterControllerTests()
        {
            _registerServiceMock = new Mock<IRegisterService>();
            _sut = new RegisterController(_registerServiceMock.Object);
        }
        [Fact]
        public async Task UpdateName_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateName(testId, "Name") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateName_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateName(testId, "Name") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateLastName_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateLastName(testId, "Lastname") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateLastName_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateLastName(testId, "Lastname") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdatePersonalCode_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdatePersonalCode(testId, 1) as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdatePersonalCode_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdatePersonalCode(testId, 1) as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdatePhoneNumber_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdatePhoneNumber(testId, 1) as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdatePhoneNumber_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdatePhoneNumber(testId, 1) as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateEmail_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateEmail(testId, "Email") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateEmail_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateEmail(testId, "Email") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdatePhoto_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdatePhoto(testId, new ImageDto { }) as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdatePhoto_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdatePhoto(testId, new ImageDto { }) as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateCity_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateCity(testId, "City") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateCity_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateCity(testId, "City") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateStreetName_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateStreetName(testId, "Street name") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateStreetName_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateStreetName(testId, "Street name") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateHouseNumber_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateHouseNumber(testId, "House number") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateHouseNumber_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateHouseNumber(testId, "House number") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task UpdateApartmentNumber_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateApartmentNumber(testId, "Apartment number") as StatusCodeResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task UpdateApartmentNumber_WhenPersonNotFound_ReturnNull()
        {
            var result = await _sut.UpdateApartmentNumber(testId, "Apartment number") as StatusCodeResult;
            Assert.Equal(null, result);
        }
        [Fact]
        public async Task GetAllInfoById_WhenPersonFound_ReturnPerson()
        {

            var testPerson = new Person
            {
                Name = "testName"
            };
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(testPerson);
            var result = await _sut.GetAllInfoById(testId);
            var actual = result.Result as OkObjectResult;
            Assert.Equal(testPerson, actual.Value);
        }
        [Fact]
        public async Task GetAllInfoById_WhenPersonNotFound_ReturnBadObjectResult()
        {
            var result = await _sut.GetAllInfoById(testId);
            var actual = result.Result as ObjectResult;
            Assert.Equal("No user by id", actual.Value);
        }
        [Fact]
        public async Task DownloadImage_WhenImageisFound_ReturnImage()
        {
            var testPerson = new Person
            {
                ImageContentType = "image/jpeg",
                ImageBytes = new byte[0]

            };
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(testId)).ReturnsAsync(testPerson);
            var result = await _sut.DownloadImage(testId) as FileContentResult;
            Assert.Equal(testPerson.ImageBytes, result.FileContents);
        }
        [Fact]
        public async Task DownloadImage_WhenImageisNotFound_ReturnImage()
        {
            var result = await _sut.DownloadImage(testId);
            var actual = result as ObjectResult;
            Assert.Equal("No user by id", actual.Value);

        }
        [Fact]
        public async Task DeleteUser_WhenUserIsFound_ReturnImage()
        {
            var testPerson = new UserAccount
            {
                UserName ="TestUsername",

            };
            _registerServiceMock.Setup(w => w.GetUserIdAsync(testId)).ReturnsAsync(testPerson);
            var result = await _sut.Delete(testId) as ObjectResult;
            Assert.Equal("User Deleted", result.Value);
        }
        [Fact]
        public async Task DeleteUser_WhenUserIsNotFound_ReturnImage()
        {
            var result = await _sut.Delete(testId);
            var actual = result as ObjectResult;
            Assert.Equal("No user by id", actual.Value);

        }
    } 
}
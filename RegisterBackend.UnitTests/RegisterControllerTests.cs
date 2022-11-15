using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RegisterApi.BL.Interfaces;
using RegisterApi.Controllers;
using RegisterApi.DAL.Interfaces;
using RegisterApi.DAL.Repository;
using RegisterApi.Domain.Models;

namespace RegisterBackend.UnitTests
{
    public class RegisterControllerTests
    {
        private Mock<IRegisterService> _registerServiceMock;
        private RegisterController _sut;
        public RegisterControllerTests()
        {
            _registerServiceMock = new Mock<IRegisterService>();
            _sut = new RegisterController( _registerServiceMock.Object);
        }
        [Fact]
        public async Task UpdateName_WhenPersonFound_ReturnOkCodeResult()
        {
            _registerServiceMock.Setup(w => w.GetPersonByIdAsync(15)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateName(15, "Name")as StatusCodeResult;
            Assert.Equal(200, result.StatusCode );
        }
        [Fact]
        public async Task UpdateName_WhenPersonNotFound_ReturnNull()
        {
            //_registerServiceMock.Setup(w => w.GetPersonByIdAsync(15)).ReturnsAsync(new Person { });
            var result = await _sut.UpdateName(15, "Name")as StatusCodeResult;
            Assert.Equal(null, result );
        }
    }
}
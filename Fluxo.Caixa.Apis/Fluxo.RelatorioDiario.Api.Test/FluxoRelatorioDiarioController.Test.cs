using NUnit.Framework;
using AutoMapper;
using Fluxo.RelatorioDiario.Api.Controllers;
using Moq;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fluxo.RelatorioDiario.Api.Tests.Controllers
{
    [TestFixture]
    public class FluxoRelatorioDiarioControllerTests
    {
        private FluxoRelatorioDiarioController _controller;
        private Mock<IRelatorioDiarioService> _relatorioDiarioServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _relatorioDiarioServiceMock = new Mock<IRelatorioDiarioService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new FluxoRelatorioDiarioController(_relatorioDiarioServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task ConsultaRelatorioDiario_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new ConsultaRelatorioDiarioRequest();
            var consultaRelatorio = new Caixa.Domain.Models.RelatorioDiario();
            var response = new ConsultaRelatorioDiarioResponse { Sucesso = true };

            _mapperMock.Setup(m => m.Map<ConsultaRelatorioDiarioRequest, Caixa.Domain.Models.RelatorioDiario>(request))
                .Returns(consultaRelatorio);
            _relatorioDiarioServiceMock.Setup(s => s.ConsultaRelatorioDiario(consultaRelatorio))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.ConsultaRelatorioDiario(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public async Task ConsultaRelatorioDiario_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new ConsultaRelatorioDiarioRequest();
            var consultaRelatorio = new Caixa.Domain.Models.RelatorioDiario();
            var response = new ConsultaRelatorioDiarioResponse { Sucesso = false, Mensagem = "Erro" };

            _mapperMock.Setup(m => m.Map<ConsultaRelatorioDiarioRequest, Caixa.Domain.Models.RelatorioDiario>(request))
                .Returns(consultaRelatorio);
            _relatorioDiarioServiceMock.Setup(s => s.ConsultaRelatorioDiario(consultaRelatorio))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.ConsultaRelatorioDiario(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
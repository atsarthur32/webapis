using AutoMapper;
using Fluxo.Lancamentos.Caixa.Api.Controllers;
using Moq;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Fluxo.Lancamentos.Caixa.Api.Tests.Controllers
{
    [TestFixture]
    public class FluxoLancamentosControllerTests
    {
        private FluxoLancamentosController _controller;
        private Mock<ILancamentosService> _lancamentoServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _lancamentoServiceMock = new Mock<ILancamentosService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new FluxoLancamentosController(_lancamentoServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CadastroLancamento_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new CadastroLancamentoRequest();
            var cadastroLancamento = new Fluxo.Caixa.Domain.Models.Lancamentos();
            var response = new CadastroLancamentoResponse { Sucesso = true };

            _mapperMock.Setup(m => m.Map<CadastroLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request))
                .Returns(cadastroLancamento);
            _lancamentoServiceMock.Setup(s => s.CadastrarLancamento(cadastroLancamento))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CadastroLancamento(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public async Task CadastroLancamento_InvalidRequest_ReturnsBadRequest()
        {
            var request = new CadastroLancamentoRequest();
            var cadastroLancamento = new Fluxo.Caixa.Domain.Models.Lancamentos();
            var response = new CadastroLancamentoResponse { Sucesso = false, Mensagem = "Erro" };

            _mapperMock.Setup(m => m.Map<CadastroLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request))
                .Returns(cadastroLancamento);
            _lancamentoServiceMock.Setup(s => s.CadastrarLancamento(cadastroLancamento))
                .ReturnsAsync(response);

            var result = await _controller.CadastroLancamento(request);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
        }

        [Test]
        public async Task ConsultarLancamento_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new ConsultaLancamentoRequest();
            var consultaLancamento = new Fluxo.Caixa.Domain.Models.Lancamentos();
            var response = new ConsultaLancamentoResponse { Sucesso = true };

            _mapperMock.Setup(m => m.Map<ConsultaLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request))
                .Returns(consultaLancamento);
            _lancamentoServiceMock.Setup(s => s.ConsultarLancamento(consultaLancamento))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.ConsultarLancamento(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public async Task ConsultarLancamento_InvalidRequest_ReturnsBadRequest()
        {
            var request = new ConsultaLancamentoRequest();
            var consultaLancamento = new Fluxo.Caixa.Domain.Models.Lancamentos();
            var response = new ConsultaLancamentoResponse { Sucesso = false, Mensagem = "Erro" };

            _mapperMock.Setup(m => m.Map<ConsultaLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request))
                .Returns(consultaLancamento);
            _lancamentoServiceMock.Setup(s => s.ConsultarLancamento(consultaLancamento))
                .ReturnsAsync(response);

            var result = await _controller.ConsultarLancamento(request);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
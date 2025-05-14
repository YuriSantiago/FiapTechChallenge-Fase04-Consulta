﻿using Consulta.Controllers;
using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers
{
    public class RegiaoControllerTests
    {

        private readonly Mock<IRegiaoService> _regiaoServiceMock;
        private readonly RegiaoController _controller;

        public RegiaoControllerTests()
        {
            _regiaoServiceMock = new Mock<IRegiaoService>();
            _controller = new RegiaoController(_regiaoServiceMock.Object);
        }

        [Fact]
        public void Get_ShouldReturnOkWithListOfRegiaoDTO()
        {
            // Arrange
            var regioesDTO = new List<RegiaoDTO>
            {
                new() {
                    Id = 1,
                    DDD = 11,
                    Descricao = "São Paulo",
                    DataInclusao = DateTime.Now }
            };

            _regiaoServiceMock.Setup(service => service.GetAll()).Returns(regioesDTO);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(regioesDTO, okResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnOkWithRegiaoDTO_WhenIdExists()
        {
            // Arrange
            var regiaoDTO = new RegiaoDTO
            {
                Id = 1,
                DDD = 11,
                Descricao = "São Paulo",
                DataInclusao = DateTime.Now
            };

            _regiaoServiceMock.Setup(service => service.GetById(1)).Returns(regiaoDTO);

            // Act
            var result = _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(regiaoDTO, okResult.Value);
        }

        [Fact]
        public void GetByDDD_ShouldReturnOkWithRegiaoDTO_WhenDDDExists()
        {
            // Arrange
            var regiaoDTO = new RegiaoDTO
            {
                Id = 1,
                DDD = 11,
                Descricao = "São Paulo",
                DataInclusao = DateTime.Now
            };

            _regiaoServiceMock.Setup(service => service.GetByDDD(11)).Returns(regiaoDTO);

            // Act
            var result = _controller.Get((short)11);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(regiaoDTO, okResult.Value);
        }

    }
}

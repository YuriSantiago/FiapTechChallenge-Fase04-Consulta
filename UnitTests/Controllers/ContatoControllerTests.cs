using Consulta.Controllers;
using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers
{
    public class ContatoControllerTests
    {

        private readonly Mock<IContatoService> _contatoServiceMock;
        private readonly Mock<IRegiaoService> _regiaoServiceMock;
        private readonly ContatoController _contatoController;

        public ContatoControllerTests()
        {
            _contatoServiceMock = new Mock<IContatoService>();
            _regiaoServiceMock = new Mock<IRegiaoService>();
            _contatoController = new ContatoController(_contatoServiceMock.Object, _regiaoServiceMock.Object);
        }

        [Fact]
        public void Get_ShouldReturnOkWithListOfContatoDTO()
        {
            // Arrange
            var contatosDTO = new List<ContatoDTO>
            {
               new() {
                   Id = 1,
                   Nome = "Yuri",
                   Telefone = "11999999999",
                   Email = "yuri@email.com",
                   DataInclusao = DateTime.Now,
                   Regiao = new RegiaoDTO { Id = 1, DDD = 11, Descricao = "São Paulo", DataInclusao = DateTime.Now }
               }
             };

            _contatoServiceMock.Setup(service => service.GetAll()).Returns(contatosDTO);

            // Act
            var result = _contatoController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(contatosDTO, okResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnOkWithContatoDTO_WhenIdExists()
        {
            // Arrange
            var contatoDTO = new ContatoDTO
            {
                Id = 1,
                Nome = "Yuri",
                Telefone = "11999999999",
                Email = "yuri@email.com",
                DataInclusao = DateTime.Now,
                Regiao = new RegiaoDTO { Id = 1, DDD = 11, Descricao = "São Paulo", DataInclusao = DateTime.Now }
            };

            _contatoServiceMock.Setup(service => service.GetById(1)).Returns(contatoDTO);

            // Act
            var result = _contatoController.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(contatoDTO, okResult.Value);
        }

        [Fact]
        public void GetByDDD_ShouldReturnContatos_WhenDDDExists()
        {
            // Arrange
            var contatosDTO = new List<ContatoDTO>
            {
               new() {
                   Id = 1,
                   Nome = "Yuri",
                   Telefone = "11999999999",
                   Email = "yuri@email.com",
                   DataInclusao = DateTime.Now,
                   Regiao = new RegiaoDTO { Id = 1, DDD = 11, Descricao = "São Paulo", DataInclusao = DateTime.Now }
               }
             };

            _contatoServiceMock.Setup(s => s.GetAllByDDD(11)).Returns(contatosDTO);

            // Act
            var result = _contatoController.Get((short)11);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(contatosDTO, okResult.Value);
        }   

    }
}

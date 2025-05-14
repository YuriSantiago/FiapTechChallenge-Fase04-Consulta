        using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Services;
using Moq;

namespace ServiceTests.Services
{
    public class RegiaoServiceTests
    {

        private readonly Mock<IRegiaoRepository> _regiaoRepositoryMock;
        private readonly RegiaoService _regiaoService;

        public RegiaoServiceTests()
        {
            _regiaoRepositoryMock = new Mock<IRegiaoRepository>();
            _regiaoService = new RegiaoService(_regiaoRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnListOfRegiaoDTO()
        {
            // Arrange
            var regioes = new List<Regiao>
            {
               new() {
                   Id = 1,
                   DDD = 11,
                   Descricao = "São Paulo"
               }
             };

            _regiaoRepositoryMock.Setup(repo => repo.GetAll()).Returns(regioes);

            // Act
            var result = _regiaoService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(regioes.Count, result.Count);
        }

        [Fact]
        public void GetById_ShouldReturnRegiaoDTO_WhenIdExists()
        {
            // Arrange
            var regiao = new Regiao
            {
                Id = 1,
                DDD = 11,
                Descricao = "São Paulo"
            };

            _regiaoRepositoryMock.Setup(repo => repo.GetById(regiao.Id)).Returns(regiao);

            // Act
            var result = _regiaoService.GetById(regiao.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(regiao.Id, result.Id);
        }

        [Fact]
        public void GetByDDD_ShouldReturnRegiaoDTO_WhenDDDExists()
        {
            // Arrange
            short ddd = 11;

            var regiao = new Regiao
            {
                Id = 1,
                DDD = 11,
                Descricao = "São Paulo"
            };

            _regiaoRepositoryMock.Setup(repo => repo.GetByDDD(ddd)).Returns(regiao);

            // Act
            var result = _regiaoService.GetByDDD(ddd);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ddd, result.DDD);
        }

    }
}


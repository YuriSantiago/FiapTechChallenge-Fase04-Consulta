using Core.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class RegiaoControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public RegiaoControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk()
        {
            // Act
            var response = await _client.GetAsync("/Regiao");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var regioes = await response.Content.ReadFromJsonAsync<List<RegiaoDTO>>();
            Assert.NotNull(regioes);
            Assert.True(regioes.Count >= 0);
        }

        [Fact]
        public async Task GetById_ShouldReturnRegiao_WhenIdExists()
        {
            // Arrange
            int regiaoId = 1;

            // Act
            var response = await _client.GetAsync($"/Regiao/{regiaoId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var regiao = await response.Content.ReadFromJsonAsync<RegiaoDTO>();
            Assert.NotNull(regiao);
            Assert.Equal(regiaoId, regiao.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnBadRequest_WhenIdDoesNotExist()
        {
            // Arrange
            int regiaoId = 9999;

            // Act
            var response = await _client.GetAsync($"/Regiao/{regiaoId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetByDDD_ShouldReturnRegiao_WhenIdExists()
        {
            // Arrange
            short ddd = 11;

            // Act
            var response = await _client.GetAsync($"/Regiao/getbyDDD/{ddd}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var regiao = await response.Content.ReadFromJsonAsync<RegiaoDTO>();
            Assert.NotNull(regiao);
            Assert.Equal(ddd, regiao.DDD);
        }

        [Fact]
        public async Task GetByDDD_ShouldReturnNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            short ddd = 9999;

            // Act
            var response = await _client.GetAsync($"/Regiao/getbyDDD/{ddd}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }

  
}

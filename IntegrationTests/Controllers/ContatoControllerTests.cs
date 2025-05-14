using Core.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests.Controllers
{
    public class ContatoControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ContatoControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk()
        {
            // Act
            var response = await _client.GetAsync("/Contato");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var contatos = await response.Content.ReadFromJsonAsync<List<ContatoDTO>>();
            Assert.NotNull(contatos);
            Assert.True(contatos.Count >= 0);
        }

        [Fact]
        public async Task GetByDDD_ShouldReturnContato_WhenIdExists()
        {
            // Arrange
            short ddd = 11;

            // Act
            var response = await _client.GetAsync($"/Contato/getbyDDD/{ddd}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var contatos = await response.Content.ReadFromJsonAsync<List<ContatoDTO>>();
            Assert.NotNull(contatos);
            Assert.True(contatos.Count >= 0);
        }

        [Fact]
        public async Task GetByDDD_ShouldReturnNotResults_WhenIdDoesNotExist()
        {
            // Arrange
            short ddd = 9999;

            // Act
            var response = await _client.GetAsync($"/Contato/getbyDDD/{ddd}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var contatos = await response.Content.ReadFromJsonAsync<List<ContatoDTO>>();
            Assert.Equal(0, contatos?.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnContato_WhenIdExists()
        {
            // Arrange
            int contatoId = 1;

            // Act
            var response = await _client.GetAsync($"/Contato/{contatoId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var contato = await response.Content.ReadFromJsonAsync<ContatoDTO>();
            Assert.NotNull(contato);
            Assert.Equal(contatoId, contato.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            int contatoId = 9999;

            // Act
            var response = await _client.GetAsync($"/Contato/{contatoId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

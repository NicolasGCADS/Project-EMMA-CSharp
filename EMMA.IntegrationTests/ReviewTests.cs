using System.Net;
using System.Net.Http.Json;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using EMMAData;
using EMMAModel;

namespace EMMA.IntegrationTests
{
    public class ReviewCrudTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ReviewCrudTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_Get_Update_Delete_Review_Workflow()
        {
            var review = new Review { Description = "Initial" };

            var createResp = await _client.PostAsJsonAsync("/api/v1/Review", review);
            createResp.StatusCode.Should().Be(HttpStatusCode.Created);
            var created = await createResp.Content.ReadFromJsonAsync<Review>();
            created.Should().NotBeNull();

            var getResp = await _client.GetAsync($"/api/v1/Review/{created.IdReading}");
            getResp.StatusCode.Should().Be(HttpStatusCode.OK);

            created.Description = "Updated";
            var putResp = await _client.PutAsJsonAsync($"/api/v1/Review/{created.IdReading}", created);
            putResp.StatusCode.Should().Be(HttpStatusCode.OK);

            var delResp = await _client.DeleteAsync($"/api/v1/Review/{created.IdReading}");
            delResp.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}

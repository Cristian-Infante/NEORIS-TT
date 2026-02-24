using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NEORIS.Web.Models;

namespace NEORIS.Web.Services
{
    /// <summary>
    /// HTTP client adapter for the /api/authors endpoint.
    /// </summary>
    public class AuthorApiClient : IAuthorApiClient
    {
        private readonly HttpClient _http;
        private readonly IApiResponseParser _parser;

        public AuthorApiClient(HttpClient http, IApiResponseParser parser)
        {
            _http = http;
            _parser = parser;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAllAsync()
        {
            var response = await _http.GetAsync("api/authors");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<AuthorViewModel>>(json);
        }

        public async Task<AuthorViewModel> GetByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/authors/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthorViewModel>(json);
        }

        public async Task<AuthorViewModel> CreateAsync(CreateAuthorViewModel model)
        {
            var payload = JsonConvert.SerializeObject(new
            {
                model.FullName,
                model.BirthDate,
                model.OriginCity,
                model.Email
            });

            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("api/authors", content);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new ApiException(_parser.ExtractMessage(body));
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthorViewModel>(json);
        }
    }
}
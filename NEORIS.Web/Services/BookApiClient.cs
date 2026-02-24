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
    /// HTTP client adapter for the /api/books endpoint.
    /// </summary>
    public class BookApiClient : IBookApiClient
    {
        private readonly HttpClient _http;
        private readonly IApiResponseParser _parser;

        public BookApiClient(HttpClient http, IApiResponseParser parser)
        {
            _http = http;
            _parser = parser;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var response = await _http.GetAsync("api/books");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<BookViewModel>>(json);
        }

        public async Task<BookViewModel> GetByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/books/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookViewModel>(json);
        }

        public async Task<BookViewModel> CreateAsync(CreateBookViewModel model)
        {
            var payload = JsonConvert.SerializeObject(new
            {
                model.Title,
                model.Year,
                model.Genre,
                model.PageCount,
                model.AuthorId
            });

            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("api/books", content);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new ApiException(_parser.ExtractMessage(body));
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookViewModel>(json);
        }
    }
}

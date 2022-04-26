using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZverGram.Web
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly HttpClient httpClient;

        public ExhibitionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ExhibitionListModel>> GetExhibitions(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/v1/exhibitions/?offset={offset}&limit={limit}";
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) 
            { 
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<ExhibitionListModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) 
                       ?? new List<ExhibitionListModel>();

            return data;
        }
        public async Task<ExhibitionListModel> GetExhibition(int exhibitionId)
        {
            string url = $"{Settings.ApiRoot}/v1/exhibitions/{exhibitionId}";
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<ExhibitionListModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                       ?? new ExhibitionListModel();

            return data;
        }
        public async Task AddExhibition(ExhibitionModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/exhibitions";
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task EditExhibition(int exhibitionId, ExhibitionModel model)
        {
            string url = $"{Settings.ApiRoot}/v1/exhibitions/{exhibitionId}";
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url, request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
        public async Task DeleteExhibition(int exhibitionId)
        {
            string url = $"{Settings.ApiRoot}/v1/exhibitions/{exhibitionId}";
            var response = await httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }
    }
}

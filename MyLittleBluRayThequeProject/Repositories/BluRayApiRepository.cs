using MyLittleBluRayThequeProject.DTOs;
using Newtonsoft.Json;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayApiRepository
    {
        public List<BluRayApi> GetBluRays(string baseUrl)
        {
            HttpClient client = new HttpClient();
            List<BluRayApi> result = new List<BluRayApi>();
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}/BluRays").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<BluRayApi>>(responseBody);
            }
            finally
            {
                client.Dispose();
            }
            return result;
        }
    }
}

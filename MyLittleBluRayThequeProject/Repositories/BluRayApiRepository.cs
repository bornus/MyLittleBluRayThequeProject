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
            result.ForEach(x => x.FromUrl = baseUrl);
            return result;
        }

        public void EmprunterBluRay(BluRayApi brApi, string baseUrl)
        {
            if (brApi.Disponible)
            {
                HttpClient client = new HttpClient();
                BluRayApi result = new BluRayApi();
                try
                {
                    HttpContent httpContent = new StringContent("");
                    HttpResponseMessage response = client.PostAsync($"{baseUrl}/{brApi.Id}/Emprunt", httpContent).Result;
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<BluRayApi>(responseBody);
                }
                finally
                {
                    client.Dispose();
                }
            }
            
        }

        public List<string> getUrls()
        {
            List<string> urls = new List<string>(){ "https://localhost:7266"};
            return urls;
        }
    }
}

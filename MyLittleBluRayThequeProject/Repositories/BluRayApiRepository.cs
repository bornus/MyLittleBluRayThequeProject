using MyLittleBluRayThequeProject.DTOs;
using Newtonsoft.Json;
using Npgsql;

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

        public void EmprunterBluRay(long brId, SourceEmprunt emprunt)
        {
            BluRayApi brFinal = this.GetBluRays(emprunt.Url).FirstOrDefault(x => x.Id == brId);
            if (brId >= 0 && brFinal!= null)
            {
                HttpClient client = new HttpClient();
                BluRayApi result = new BluRayApi();
                try
                {
                    HttpContent httpContent = new StringContent("");
                    HttpResponseMessage response = client.PostAsync($"{emprunt.Url}/{brId}/Emprunt", httpContent).Result;
                    response.EnsureSuccessStatusCode();
                    this.AddBluRay(brFinal, emprunt);
                }
                finally
                {
                    client.Dispose();
                }
            }
            
        }

        private void AddBluRay(BluRayApi bluRay, SourceEmprunt emprunt)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();
                
                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRay\" VALUES(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)", conn);
                command.Parameters.AddWithValue("p0", bluRay.Id);
                command.Parameters.AddWithValue("p1", bluRay?.Titre);
                command.Parameters.AddWithValue("p2", bluRay?.Duree.TotalMinutes);
                command.Parameters.AddWithValue("p3", bluRay?.DateSortie);
                command.Parameters.AddWithValue("p4", bluRay?.Version);
                command.Parameters.AddWithValue("p5", true);
                command.Parameters.AddWithValue("p6", bluRay?.Proprietaire);
                command.Parameters.AddWithValue("p7", false);
                //TODO ajouter l'id externe
                //command.Parameters.AddWithValue("p8", emprunt.Url);
                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    Console.WriteLine("Object inserted !");
                }

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void RendreBluRay(long brId, SourceEmprunt emprunt)
        {
            BluRayApi brFinal = this.GetBluRays(emprunt.Url).FirstOrDefault(x => x.Id == brId);
            if (brId >= 0 && brFinal != null)
            {
                HttpClient client = new HttpClient();
                BluRayApi result = new BluRayApi();
                try
                {
                    HttpContent httpContent = new StringContent("");
                    HttpResponseMessage response = client.PostAsync($"{emprunt.Id}/{brId}/Rendu", httpContent).Result;
                    response.EnsureSuccessStatusCode();
                    this.DeleteBluRay(brId);
                }
                finally
                {
                    client.Dispose();
                }
            }

        }


        private void DeleteBluRay(long id)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"BluRayTheque\".\"BluRay\" WHERE Id = @p0", conn);
                command.Parameters.AddWithValue("p0", id);
                //TODO ajouter l'id externe
                //command.Parameters.AddWithValue("p8", emprunt.Url);
                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    Console.WriteLine("Object inserted !");
                }

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<SourceEmprunt> getEmprunts()
        {
            List<SourceEmprunt> urls = new List<SourceEmprunt>(){ new SourceEmprunt()
            {
                Id = 1,
                Nom = "moi",
                Url = "https://localhost:7266"
            }};
            return urls;
        }
    }
}

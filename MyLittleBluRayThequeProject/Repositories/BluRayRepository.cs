using MyLittleBluRayThequeProject.DTOs;
using Npgsql;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayRepository
    {
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BluRayRepository()
        {

        }

        public List<BluRay> GetListeBluRay()
        {
            NpgsqlConnection conn = null;
            List<BluRay> result = new List<BluRay>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=49rkpFl0;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"Duree\", \"Version\" FROM \"BluRayTheque\".\"BluRay\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    result.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        Duree = TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                        Version = dr[3].ToString()
                    });

            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Récupération d'un BR par son Id
        /// </summary>
        /// <param name="Id">l'Id du bluRay</param>
        /// <returns></returns>
        public BluRay GetBluRay(long Id)
        {
            NpgsqlConnection conn = null;
            BluRay result = new BluRay();
            try
            {
                List<BluRay> qryResult = new List<BluRay>();
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=49rkpFl0;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"Duree\", \"Version\" FROM \"BluRayTheque\".\"BluRay\" where \"Id\" = @p", conn);
                command.Parameters.AddWithValue("p", Id);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    qryResult.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        Duree = TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                        Version = dr[3].ToString()
                    });

                result = qryResult.SingleOrDefault();

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}

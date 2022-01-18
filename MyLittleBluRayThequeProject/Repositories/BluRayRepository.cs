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
        PersonneRepository personneRepository = new PersonneRepository();
        public IEnumerable<BluRay> GetListeBluRaySQL()
        {
            NpgsqlConnection conn = null;
            List<BluRay> result = new List<BluRay>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"Duree\", \"DateSortie\", \"Version\",\"Emprunt\",\"Proprietaire\", \"Disponible\" FROM \"BluRayTheque\".\"BluRay\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();
                // Output rows

                while (dr.Read())
                {
                    if (dr != null && dr[2].ToString() != null)
                    {
                        BluRay br = new BluRay
                        {
                            Id = long.Parse(dr[0].ToString()),
                            Titre = dr[1].ToString(),
                            Duree = dr[2].ToString().Equals("") ? new TimeSpan() : TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                            DateSortie = dr[3].ToString().Equals("") ? new DateTime() : DateTime.Parse(dr[3].ToString()),
                            Version = dr[4].ToString(),
                            Emprunt = dr[5].ToString().Equals("") ? false : bool.Parse(dr[5].ToString()),
                            Proprietaire = dr[6].ToString().Equals("") ? 0 : int.Parse(dr[6].ToString()),
                            Disponible = dr[7].ToString().Equals("") ? false : bool.Parse(dr[7].ToString()),
                        };
                        br.Acteurs = personneRepository.GetListActeursOfBluRay(br.Id);
                        br.Realisateur = personneRepository.GetRealisateurOfBluRay(br.Id);
                        br.Scenariste = personneRepository.GetScenaristeOfBluRay(br.Id);

                        result.Add(br);

                    }

                }

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

        public void PostBluRay(BluRay bluRay)
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
                command.Parameters.AddWithValue("p5", bluRay?.Emprunt);
                command.Parameters.AddWithValue("p6", bluRay?.Proprietaire);
                command.Parameters.AddWithValue("p7", bluRay?.Disponible);

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

        public void LinkBluRayRealisateur(BluRay bluRay, long idReal)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                long Id = this.GetLastIdOfTable("Realisateur") + 1;

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Realisateur\" VALUES(@p0,@p1,@p2)", conn);
                command.Parameters.AddWithValue("p0", Id);
                command.Parameters.AddWithValue("p1", bluRay?.Id);
                command.Parameters.AddWithValue("p2", idReal);

                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    Console.WriteLine("Link created !");
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

        public void LinkBluRayScenariste(BluRay bluRay, long idScenar)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                long Id = this.GetLastIdOfTable("Scenariste") + 1;

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Scenariste\" VALUES(@p0,@p1,@p2)", conn);
                command.Parameters.AddWithValue("p0", Id);
                command.Parameters.AddWithValue("p1", bluRay?.Id);
                command.Parameters.AddWithValue("p2", idScenar);

                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    Console.WriteLine("Link created !");
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

        public void LinkBluRayActeurs(BluRay bluRay, List<long> ids)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                foreach (long idActeur in ids)
                {
                    long Id = this.GetLastIdOfTable("Scenariste") + 1;

                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Acteur\" VALUES(@p0,@p1,@p2)", conn);
                    command.Parameters.AddWithValue("p0", Id);
                    command.Parameters.AddWithValue("p1", bluRay?.Id);
                    command.Parameters.AddWithValue("p2", idActeur);

                    var dr = command.ExecuteNonQuery();

                    if (dr > 0)
                    {
                        Console.WriteLine("Link created !");
                    }
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

        public void LinkBluRayLangues(BluRay bluRay, List<string> ids)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                foreach(string idLangue in ids)
                {
                    long Id = this.GetLastIdOfTable("BluRayLangue") + 1;

                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRayLangue\" VALUES(@p0,@p1,@p2)", conn);
                    command.Parameters.AddWithValue("p0", Id);
                    command.Parameters.AddWithValue("p1", bluRay?.Id);
                    command.Parameters.AddWithValue("p2", idLangue);

                    var dr = command.ExecuteNonQuery();

                    if (dr > 0)
                    {
                        Console.WriteLine("Link created !");
                    }
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

        public void LinkBluRaySsTitres(BluRay bluRay, List<string> ids)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();


                foreach (string idssTitre in ids)
                {
                    long Id = this.GetLastIdOfTable("BluRaySsTitre") + 1;

                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRaySsTitre\" VALUES(@p0,@p1,@p2)", conn);
                    command.Parameters.AddWithValue("p0", Id);
                    command.Parameters.AddWithValue("p1", bluRay?.Id);
                    command.Parameters.AddWithValue("p2", idssTitre);

                    var dr = command.ExecuteNonQuery();

                    if (dr > 0)
                    {
                        Console.WriteLine("Link created !");
                    }
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

        /// <summary>
        /// Récupération d'un BR par son Id
        /// </summary>
        /// <param name="Id">l'Id du bluRay</param>
        /// <returns></returns>
        public BluRay GetBluRay(long Id)
        {
            NpgsqlConnection conn = null;
            BluRay result = null;
            try
            {
                List<BluRay> qryResult = new List<BluRay>();
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
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


        public IEnumerable<(long, string)> GetListLangues()
        {
            NpgsqlConnection conn = null;
            List<(long, string)> result = new List<(long, string)>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"l\".\"Id\", \"l\".\"Langue\" FROM \"BluRayTheque\".\"RefLangue\" AS l", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    result.Add(((int) dr[0] , dr[1].ToString()));
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

        public IEnumerable<(long, string)> GetListSsTitre()
        {
            NpgsqlConnection conn = null;
            List<(long, string)> result = new List<(long, string)>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"l\".\"Langue\", \"l\".\"Langue\" FROM \"BluRayTheque\".\"RefLangue\" AS l", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    result.Add(((int)dr[0], dr[1].ToString()));
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


        public int GetLastIdOfTable(string text)
        {
            NpgsqlConnection conn = null;
            List<int>result = new List<int>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\" FROM \"BluRayTheque\".\"" + text + "\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();
                // Output rows

                while (dr.Read())
                {
                    result.Add((int) dr[0]);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result.Last();

        }

        public bool EmpruntBluRay(long idBr)
        {
            bool success = false;
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("UPDATE \"BluRayTheque\".\"BluRay\" SET disponible = 'false' WHERE Id = @p0", conn);
                command.Parameters.AddWithValue("p0", idBr);

                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    success = true;
                }

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return success;
        }

        public bool RendBluRay(long idBr)
        {
            bool success = false;
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=network;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("UPDATE \"BluRayTheque\".\"BluRay\" SET disponible = 'true' WHERE Id = @p0", conn);
                command.Parameters.AddWithValue("p0", idBr);

                var dr = command.ExecuteNonQuery();

                if (dr > 0)
                {
                    success = true;
                }

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return success;
        }
    }
}

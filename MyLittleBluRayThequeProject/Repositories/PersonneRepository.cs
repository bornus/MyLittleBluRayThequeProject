using MyLittleBluRayThequeProject.DTOs;
using Npgsql;
using System.Data;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class PersonneRepository
    {

        public PersonneRepository () { }

        public Personne GetRealisateurBr(long idBr)
        {

            NpgsqlConnection conn = null;
            Personne personne = null;
            NpgsqlTransaction tran = null;
            try
            {

                List<Personne> qryResult = new List<Personne>();
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=49rkpFl0;Database=postgres;");
                conn.Open();
                tran = conn.BeginTransaction();
                using (var cmd = new NpgsqlCommand("select \"BluRayTheque\".\"GetRealisateurByBRId\"(@brid, @cur)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("brid", idBr);
                    cmd.Parameters.Add(new NpgsqlParameter("@cur", NpgsqlTypes.NpgsqlDbType.Refcursor) { Direction = ParameterDirection.InputOutput, Value = "cur" });

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "fetch all in \"cur\"";
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {

                        // Output rows
                        while (reader.Read())
                            qryResult.Add(new Personne
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                DateNaissance = reader.GetDateTime(3),
                                Nationalite = reader.GetString(4),
                            });
                    }
                }

                personne = qryResult.SingleOrDefault();
            }
            finally
            {
                if (conn != null)
                {
                    tran.Commit();
                    conn.Close();
                }
            }
            return personne;
        }

        public List<Personne> GetActeursBr(long idBr)
        {
            NpgsqlConnection conn = null;
            List<Personne> acteurs = new List<Personne>();
            NpgsqlTransaction tran = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=49rkpFl0;Database=postgres;");
                conn.Open();
                tran = conn.BeginTransaction();
                using (var cmd = new NpgsqlCommand("\"BluRayTheque\".\"GetActeursByBRId\"", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("brid", idBr);
                    cmd.Parameters.Add(new NpgsqlParameter("@cur", NpgsqlTypes.NpgsqlDbType.Refcursor) { Direction = ParameterDirection.InputOutput, Value = "cur" });

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "fetch all in \"cur\"";
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {

                        // Output rows
                        while (reader.Read())
                            acteurs.Add(new Personne
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                DateNaissance = reader.GetDateTime(3),
                                Nationalite = reader.GetString(4),
                            });
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    tran.Commit();
                    conn.Close();
                }
            }
            return acteurs;
        }
    }
}

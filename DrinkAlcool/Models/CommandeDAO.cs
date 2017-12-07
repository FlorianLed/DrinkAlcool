using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public class CommandeDAO 
    {
        private static readonly string QUERY = "SELECT * FROM commande";
        private static readonly string GET = QUERY + "WHERE id=@id";
        private static readonly string CREATE = "INSERT INTO commande(idUtilisateur, idProduit, total, quantite, numerocommande) OUTPUT INSERTED.id VALUES (@idUtilisateur, @idProduit, @total, @quantite, @numerocommande)";
        private static readonly string DELETE = "DELETE from commande where id=@id";

        public static List<Commande> GetAllCommande()
        {
            List<Commande> listeCommandes = new List<Commande>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listeCommandes.Add(new Commande(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2),
                                                    reader.GetDecimal(3),
                                                    reader.GetInt32(4),
                                                    reader.GetInt32(5)
                                                    ));
                }
            }

            return listeCommandes;
        }

        public static Commande Get(int id)  // fonctionne pas
        {
            Commande com = null;

            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(GET, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    com = new Commande(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetDecimal(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                       );
                }
            }
            return com;
        }

        public static Commande Create(Commande prod)
        {
            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(CREATE, conn);
                command.Parameters.AddWithValue("@idUtilisateur", prod.IdUtilisateur);
                command.Parameters.AddWithValue("@idProduit", prod.IdProduit);
                command.Parameters.AddWithValue("@total", prod.Total);
                command.Parameters.AddWithValue("@quantite", prod.Quantite);
                command.Parameters.AddWithValue("@numerocommande", prod.NumeroCommande);

                prod.Id = (int)command.ExecuteScalar();
            }
            return prod;
        }

        public static bool Delete(int id)   // pas test
        {
            bool estSupprime = false;
            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(DELETE, conn);
                command.Parameters.AddWithValue("@id", id);

                estSupprime = command.ExecuteNonQuery() != 0;
            }
            return estSupprime;
        }

    }
}
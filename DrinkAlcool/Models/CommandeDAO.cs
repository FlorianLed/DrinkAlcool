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
        private static readonly string GET = QUERY + " where id=@id";
        //private static readonly string CREATE = "INSERT INTO produit(nom, prix, stock, urlImage, description, pourcentage) OUTPUT INSERTED.id VALUES (@nom, @prix, @stock, @urlImage, @description, @pourcentage)";
        private static readonly string CREATE = "INSERT INTO commande(idUtilisateur,nom, prix, stock, urlImage) OUTPUT INSERTED.id VALUES (@idUtilisateur,@nom, @prix, @stock, @urlImage)";
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
                                                    reader.GetString(2),
                                                    reader.GetDecimal(3),
                                                    reader.GetInt32(4),
                                                    reader.GetString(5)));
                }
            }

            return listeCommandes;
        }

        public static Commande Get(int id)
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
                                        reader.GetString(2),
                                        reader.GetDecimal(3),
                                        reader.GetInt32(4),
                                        reader.GetString(5)
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
                command.Parameters.AddWithValue("@nom", prod.Nom);
                command.Parameters.AddWithValue("@prix", prod.Prix);
                command.Parameters.AddWithValue("@stock", prod.Stock);
                command.Parameters.AddWithValue("@urlImage", prod.UrlImage);

                prod.Id = (int)command.ExecuteScalar();
            }
            return prod;
        }

        public static bool Delete(int id)
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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public class ProduitDAO
    {
        private static readonly string QUERY = "SELECT * FROM produit";
        private static readonly string GET = QUERY + "where id=@id";
        private static readonly string CREATE = "INSERT INTO produit(nom, prix, stock, urlImage, description, pourcentage) OUTPUT INSERTED.id VALUES (@nom, @prix, @stock, @urlImage, @description, @pourcentage)";

        public static List<Produit> GetAllProduits()
        {
            List<Produit> listeProduits = new List<Produit>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listeProduits.Add(new Produit(reader.GetInt32(0),
                                                    reader.GetString(1),
                                                    reader.GetInt32(2),
                                                    reader.GetInt32(3),
                                                    reader.GetString(4),
                                                    reader.GetString(5),
                                                    reader.GetInt32(6)));
                }
            }

            return listeProduits;
        }

        public static Produit Get(int id)
        {
            Produit prod = null;

            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(GET, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    prod = new Produit(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetInt32(6));

                }
            }

            return prod;
        }


        public static Produit Create(Produit prod)
        {
            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(CREATE, conn);
                command.Parameters.AddWithValue("@nom", prod.Nom);
                command.Parameters.AddWithValue("@prix", prod.Prix);
                command.Parameters.AddWithValue("@stock", prod.Stock);
                command.Parameters.AddWithValue("@urlImage", prod.UrlImage);
                command.Parameters.AddWithValue("@description", prod.Description);
                command.Parameters.AddWithValue("@pourcentage", prod.Pourcentage);

                prod.Id = (int)command.ExecuteScalar();
            }
            return prod;
        }


    }
}
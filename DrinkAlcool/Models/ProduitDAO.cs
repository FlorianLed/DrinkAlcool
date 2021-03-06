﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public class ProduitDAO
    {
        private static readonly string QUERY = "SELECT * FROM produit";
        private static readonly string GET = QUERY + " where id=@id";
        private static readonly string CREATE = "INSERT INTO produit(nom, prix, stock, urlImage, description, pourcentage) OUTPUT INSERTED.id VALUES (@nom, @prix, @stock, @urlImage, @description, @pourcentage)";
        private static readonly string UPDATE = "UPDATE produit SET nom=@nom, prix=@prix, stock=@stock, urlImage=@urlImage, description=@description, pourcentage=@pourcentage WHERE Id = @id";
        private static readonly string DELETE = "DELETE from produit where id=@id";

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
                                                    reader.GetDecimal(2),
                                                    reader.GetInt32(3),
                                                    reader.GetString(4),
                                                    reader.GetString(5),
                                                    reader.GetDecimal(6)));
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
                                        reader.GetDecimal(2),
                                        reader.GetInt32(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetDecimal(6));
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


        public static Boolean Update(Produit prod)
        {
            bool aEteModifie = false;

            using (SqlConnection conn = DataBase.GetConnection())
            {

                conn.Open();
                SqlCommand command = new SqlCommand(UPDATE, conn);          
                command.Parameters.AddWithValue("@nom", prod.Nom);
                command.Parameters.AddWithValue("@prix", prod.Prix);
                command.Parameters.AddWithValue("@stock", prod.Stock);
                command.Parameters.AddWithValue("@urlImage", prod.UrlImage);
                command.Parameters.AddWithValue("@description", prod.Description);
                command.Parameters.AddWithValue("@pourcentage", prod.Pourcentage);
                command.Parameters.AddWithValue("@id", prod.Id);

                aEteModifie = command.ExecuteNonQuery() != 0;
            }
            return aEteModifie;
        }

        public static bool Delete(int id)
        {
            bool estSupprime = false;
            using(SqlConnection conn = DataBase.GetConnection())
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
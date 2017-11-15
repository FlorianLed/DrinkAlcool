using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public static class UtilisateurDAO
    {
        private static readonly string QUERY = "SELECT * FROM utilisateur";
        private static readonly string GET = QUERY + "where id=@id";
        private static readonly string CREATE = "INSERT INTO utilisateur(nom, prenom, dateNaissance, codePostal, ville, rue, numero, gsm, email, pseudo, mdp) OUTPUT INSERTED.id VALUES (@nom, @prenom, @dateNaissance, @codePostal, @ville, @rue, @numero, @gsm, @email, @pseudo, @mdp)";
        private static readonly string DELETE = "DELETE FROM utilisateur WHERE id=@id";
        private static readonly string UPDATE = "UPDATE utilisateur SET nom=@nom, prenom=@prenom, dateNaissance=@dateNaissance, codePostal=@codePostal, ville=@ville, rue=@rue, numero=@numero, gsm=@gsm, email=@email, pseudo=@pseudo, motDePasse=@motDePasse";

        public static List<Utilisateur> GetAllUtilisateurs()
        {
            List<Utilisateur> listeUtilisateurs = new List<Utilisateur>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(QUERY, connection);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                      listeUtilisateurs.Add(new Utilisateur(reader.GetInt32(0),
                                                            reader.GetString(1),
                                                            reader.GetString(2),
                                                            reader.GetString(3),
                                                            reader.GetInt32(4),
                                                            reader.GetString(5),
                                                            reader.GetString(6),
                                                            reader.GetInt32(7),
                                                            reader.GetString(8),
                                                            reader.GetString(9),
                                                            reader.GetString(10),
                                                            reader.GetString(11)));
                }
            }

            return listeUtilisateurs;
        }

        public static Utilisateur Get(int id)
        {
            Utilisateur u = null;

            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(GET, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    u = new Utilisateur(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetInt32(7),
                                        reader.GetString(8),
                                        reader.GetString(9),
                                        reader.GetString(10),
                                        reader.GetString(11));
                }
            }

            return u;
        }


        public static Utilisateur Create(Utilisateur user)
        {
            using (SqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(CREATE, conn);
                command.Parameters.AddWithValue("@nom", user.Nom);
                command.Parameters.AddWithValue("@prenom", user.Prenom);
                command.Parameters.AddWithValue("@dateNaissance", user.DateNaissance);
                command.Parameters.AddWithValue("@codePostal", user.CodePostal);
                command.Parameters.AddWithValue("@ville", user.Ville);
                command.Parameters.AddWithValue("@rue", user.Rue);
                command.Parameters.AddWithValue("@numero", user.Numero);
                command.Parameters.AddWithValue("@gsm", user.Gsm);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@pseudo", user.Pseudo);
                command.Parameters.AddWithValue("@mdp", user.MDP);

                user.Id = (int)command.ExecuteScalar();
            }
            return user;
        }

        









    }
}
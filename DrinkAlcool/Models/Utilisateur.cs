using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrinkAlcool.Models
{
    public class Utilisateur
    {

        public Utilisateur() {}

        public Utilisateur(int id, string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, int gsm, string email, string pseudo, string mdp)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            CodePostal = codePostal;
            Ville = ville;
            Rue = rue;
            Numero = numero;
            Gsm = gsm;
            Email = email;
            Pseudo = pseudo;
            MDP = mdp;
        }

        public Utilisateur(string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, int gsm, string email, string pseudo, string mdp) : this(0, nom, prenom, dateNaissance, codePostal, ville, rue, numero, gsm, email, pseudo, mdp) {}

        public int Id
        {
            get;
            internal set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Prenom
        {
            get;
            set;
        }

        public string DateNaissance
        {
            get;
            set;
        }

        public string Ville
        {
            get;
            set;
        }

        public int CodePostal
        {
            get;
            set;
        }

        public string Rue
        {
            get;
            set;
        }

        public int Numero
        {
            get;
            set;
        }

        public int Gsm
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Pseudo
        {
            get;
            set;
        }

        public string MDP
        {
            get;
            set;
        }





    }
}
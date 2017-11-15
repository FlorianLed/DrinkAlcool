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

        public Utilisateur(int id, string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, string gsm, string email, string pseudo, string mdp)
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

        public Utilisateur(string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, string gsm, string email, string pseudo, string mdp) : this(0, nom, prenom, dateNaissance, codePostal, ville, rue, numero, gsm, email, pseudo, mdp) {}

        public object Id
        {
            get;
            internal set;
        }

        public object Nom
        {
            get;
            set;
        }

        public object Prenom
        {
            get;
            set;
        }

        public object DateNaissance
        {
            get;
            set;
        }

        public object Ville
        {
            get;
            set;
        }

        public object CodePostal
        {
            get;
            set;
        }

        public object Rue
        {
            get;
            set;
        }

        public object Numero
        {
            get;
            set;
        }

        public object Gsm
        {
            get;
            set;
        }

        public object Email
        {
            get;
            set;
        }

        public object Pseudo
        {
            get;
            set;
        }

        public object MDP
        {
            get;
            set;
        }

        /*public object ConfirmationMDP
        {
            get;
            set;
        }*/







    }
}
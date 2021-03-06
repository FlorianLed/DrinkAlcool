﻿using System;
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

        public Utilisateur(int id, string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, int gsm, string email, string mdp, bool admin)
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
            MDP = mdp;
            Admin = admin;
        }

        public Utilisateur(string nom, string prenom, string dateNaissance, int codePostal, string ville, string rue, int numero, int gsm, string email, string mdp, bool admin) : this(0, nom, prenom, dateNaissance, codePostal, ville, rue, numero, gsm, email, mdp, admin) {}

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

        public string MDP
        {
            get;
            set;
        }

        public bool Admin
        {
            get;
            set;
        }




    }
}
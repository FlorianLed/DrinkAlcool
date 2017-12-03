using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkAlcool.Models
{
    public class Commande
    {
        public Commande() {}

        public Commande(int id,int idUtilisateur,string nom, Decimal prix, int stock, string urlImage)
        {
            Id = id;
            IdUtilisateur = idUtilisateur;
            Nom = nom;
            Prix = prix;
            Stock = stock;
            UrlImage = urlImage;
        }

        public Commande(int idUtilisateur, string nom, Decimal prix, int stock, string urlImage) : this(0,idUtilisateur, nom, prix, stock, urlImage) { }

        public int Id
        {
            get;
            set;
        }

        public int IdUtilisateur
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public Decimal Prix
        {
            get;
            set;
        }

        public int Stock
        {
            get;
            set;
        }

        public string UrlImage
        {
            get;
            set;
        }

    }
}
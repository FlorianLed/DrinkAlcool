using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public class Produit
    {
        public Produit() {}

        public Produit(int id, string nom, Decimal prix, int stock, string urlImage, string description, Decimal pourcentage)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
            Stock = stock;
            UrlImage = urlImage;
            Description = description;
            Pourcentage = pourcentage;
        }

        public Produit(string nom, Decimal prix, int stock, string urlImage, string description, Decimal pourcentage) : this(0, nom, prix, stock, urlImage, description, pourcentage) { }


        public int Id
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

        public string Description
        {
            get;
            set;
        }

        public Decimal Pourcentage
        {
            get;
            set;
        }


    }
}
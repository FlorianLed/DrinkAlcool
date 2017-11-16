using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAlcool.Models
{
    public class Produit
    {
        public Produit() {}

        public Produit(int id, string nom, int prix, int stock, string urlImage, string description, int pourcentage)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
            Stock = stock;
            UrlImage = urlImage;
            Description = description;
            Pourcentage = pourcentage;
        }

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

        public object Prix
        {
            get;
            set;
        }

        public object Stock
        {
            get;
            set;
        }

        public object UrlImage
        {
            get;
            set;
        }

        public object Description
        {
            get;
            set;
        }

        public object Pourcentage
        {
            get;
            set;
        }


    }
}
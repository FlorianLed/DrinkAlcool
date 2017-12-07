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

        public Commande(int id, int idUtilisateur, int idProduit, Decimal total, int quantite, int numerocommande)
        {
            Id = id;
            IdUtilisateur = idUtilisateur;
            IdProduit = idProduit;
            Total = total;
            Quantite = quantite;
            NumeroCommande = numerocommande;
        }

        public Commande(int idUtilisateur, int idProduit, Decimal total, int quantite, int numerocommande) : this(0, idUtilisateur, idProduit, total, quantite, numerocommande) { }

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
        
        public int IdProduit
        {
            get;
            set;
        }

        public Decimal Total
        {
            get;
            set;
        }

        public int Quantite
        {
            get;
            set;
        }

        public int NumeroCommande
        {
            get;
            set;
        }


    }
}
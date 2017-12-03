using DrinkAlcool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrinkAlcool.Controllers
{
    public class ProduitController : ApiController
    {
        // GET: Produit
        public IEnumerable<Produit> Get()
        {
            return ProduitDAO.GetAllProduits();
        }
        //obligatoire et reprend tous les Get
        public Produit Get(int id)
        {
            return ProduitDAO.Get(id);
        }

        public Produit Post(Produit p)
        {
            return ProduitDAO.Create(p);
        }

        public string Put(Produit prod)
        {
            if (ProduitDAO.Update(prod))
            {
                return "Modification effectuée";
            }

            return "Erreur de modification";
        }

        public string Delete(int id)
        {
            if (ProduitDAO.Delete(id))
            {
                return "Supression effectuée";
            }
            return "Erreur de suppression";
        }

    }
}
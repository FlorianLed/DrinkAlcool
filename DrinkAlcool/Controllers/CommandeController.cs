using DrinkAlcool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrinkAlcool.Controllers
{
    public class CommandeController : ApiController
    {
        // GET: Produit
        public IEnumerable<Commande> Get()
        {
            return CommandeDAO.GetAllCommande();
        }

        public Commande Get(int id)
        {
            return CommandeDAO.Get(id);
        }

        public Commande Post(Commande p)
        {
            return CommandeDAO.Create(p);
        }

        public string Delete(int id)
        {
            if (CommandeDAO.Delete(id))
            {
                return "Supression effectuée";
            }
            return "Erreur de suppression";
        }
    }
}

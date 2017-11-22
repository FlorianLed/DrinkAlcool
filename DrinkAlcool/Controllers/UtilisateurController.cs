using DrinkAlcool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrinkAlcool.Controllers
{
    public class UtilisateurController : ApiController
    {
        // GET: Utilisateur
        public IEnumerable<Utilisateur> Get()
        {
            return UtilisateurDAO.GetAllUtilisateurs();
        }
        //obligatoire et reprend tous les Get
        public Utilisateur Get(int id)
        {
            return UtilisateurDAO.Get(id);
        }

        public Utilisateur Post(Utilisateur u)
        {
            return UtilisateurDAO.Create(u);
        }

        public string Put(Utilisateur u)
        {
            if (UtilisateurDAO.Update(u))
            {
                return "Modification effectuée";
            }

            return "Erreur de modification";
        }

        public string Delete(int id)
        {
            if (UtilisateurDAO.Delete(id))
            {
                return "Supression effectuée";
            }
            return "Erreur de suppression";
        }


    }
}
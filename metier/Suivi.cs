using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class Suivi
    {


        public string IdSuivi { get; }
        public string Libelle { get; }

        public Suivi(string id, string libelle)
        {
            IdSuivi = id;
            Libelle = libelle;
        }

        /// <summary>
        /// stock les états de commandes dans une liste
        /// </summary>
        public static List<Suivi> SuiviItems { get; set; }

        /// <summary>
        /// la commande possède un état ou non
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Suivi LibelleCmd(string id)
        {
            foreach (Suivi suivi in SuiviItems)
            {
                if (suivi.IdSuivi == id) return suivi;
            }
            return new Suivi("-1", "Erreur");
        }

        /// <summary>
        /// Retourne le libellé du suivi
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Libelle;
        }
    }
}

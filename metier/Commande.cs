using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class Commande
    {
        public Commande(string id, DateTime date, int montant)
        {
            this.Id = id;
            this.DateCommande = date;
            this.Montant = montant;
        }

        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public int Montant { get; set; }
    }
}
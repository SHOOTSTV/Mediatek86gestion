using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class Abonnement
    {
        public Abonnement(string id, DateTime datefinabonnement, string idrevue)
        {
            this.Id = id;
            this.DateFinAbonnement = datefinabonnement;
            this.IdRevue = idrevue;
        }

        public string Id { get; set; }
        public DateTime DateFinAbonnement { get; set; }
        public string IdRevue { get; set; }
    }
}

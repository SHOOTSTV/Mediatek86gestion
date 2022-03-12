using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class CommandeDocument
    {
        private readonly string id;
        private readonly int nbexemplaire;
        private readonly string idlivredvd;

        public CommandeDocument(string id, int nbexemplaire, string idlivredvd)
        {
            this.id = id;
            this.nbexemplaire = nbexemplaire;
            this.idlivredvd = idlivredvd;
        }

        public string Id { get => id; }
        public int NbExemplaire { get => nbexemplaire; }
        public string IdLivredvd { get => idlivredvd; }
    }
}

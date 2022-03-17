using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class CommandeRevue
    {
        private readonly string id;
        private readonly DateTime datecommande;
        private readonly double montant;

        private readonly DateTime datefinabo;
        private readonly string idRevue;

        private readonly bool empruntable;
        private readonly string periodicite;
        private readonly int delaiMiseADispo;

        private readonly string titre;
        private readonly string genre;
        private readonly string typepublic;
        private readonly string rayon;
        private readonly string image;

        public CommandeRevue(string id, DateTime datecommande, double montant, DateTime datefinabo, string idRevue, bool empruntable, string periodicite, int delaiMiseADispo, string titre, string genre, string typepublic, string rayon, string image)
        {
            this.id = id;
            this.datecommande = datecommande;
            this.montant = montant;

            this.datefinabo = datefinabo;
            this.idRevue = idRevue;

            this.empruntable = empruntable;
            this.periodicite = periodicite;
            this.delaiMiseADispo = delaiMiseADispo;

            this.titre = titre;
            this.genre = genre;
            this.typepublic = typepublic;
            this.rayon = rayon;
            this.image = image;
        }

        public string Id { get => id; }
        public DateTime DateCommande { get => datecommande; }
        public double Montant { get => montant; }

        public DateTime DateFinAbo { get => datefinabo; }
        public string IdRevue { get => idRevue; }

        public bool Empruntable { get => empruntable; }
        public string Periodicite { get => periodicite; }
        public int DelaiMiseADispo { get => delaiMiseADispo; }

        public string Titre { get => titre; }
        public string Genre { get => genre; }
        public string Typepublic { get => typepublic; }
        public string Rayon { get => rayon; }
        public string Image { get => image; }
    }
}

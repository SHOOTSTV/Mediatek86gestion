using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.metier
{
    public class CommandeDocumentLivre
    {
        private readonly string id;
        private readonly DateTime datecommande;
        private readonly double montant;
        private readonly int nbexemplaire;
        private readonly string idlivredvd;
        private readonly string idsuivi;
        private readonly string libelle;

        private readonly string isbn;
        private readonly string auteur;
        private readonly string collection;

        private readonly string titre;
        private readonly string genre;
        private readonly string typepublic;
        private readonly string rayon;
        private readonly string image;

        public CommandeDocumentLivre(string id, DateTime datecommande, double montant, int nbexemplaire, string idlivredvd, string idsuivi, string libelle, string isbn, string auteur, string collection, string titre, string genre, string typepublic, string rayon, string image)
        {
            this.id = id;
            this.datecommande = datecommande;
            this.montant = montant;
            this.nbexemplaire = nbexemplaire;
            this.idlivredvd = idlivredvd;
            this.idsuivi = idsuivi;
            this.libelle = libelle;

            this.isbn = isbn;
            this.auteur = auteur;
            this.collection = collection;

            this.titre = titre;
            this.genre = genre;
            this.typepublic = typepublic;
            this.rayon = rayon;
            this.image = image;
        }

        public string Id { get => id; }
        public DateTime DateCommande { get => datecommande; }
        public double Montant { get => montant; }
        public int NbExemplaire { get => nbexemplaire; }
        public string IdLivredvd { get => idlivredvd; }
        public string IdSuivi { get => idsuivi; }
        public string Libelle { get => libelle; }

        public string Isbn { get => isbn; }
        public string Auteur { get => auteur; }
        public string Collection { get => collection; }

        public string Titre { get => titre; }
        public string Genre { get => genre; }
        public string Typepublic { get => typepublic; }
        public string Rayon { get => rayon; }
        public string Image { get => image; }
    }
}


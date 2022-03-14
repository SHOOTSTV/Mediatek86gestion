using System.Collections.Generic;
using Mediatek86.modele;
using Mediatek86.metier;
using Mediatek86.vue;


namespace Mediatek86.controleur
{
    internal class Controle
    {
        private readonly List<Livre> lesLivres;
        private readonly List<Dvd> lesDvd;
        private readonly List<Revue> lesRevues;
        private readonly List<Categorie> lesRayons;
        private readonly List<Categorie> lesPublics;
        private readonly List<Categorie> lesGenres;
        private List<CommandeDocumentLivre> lesCommandesLivres;
        private List<CommandeDocumentDvd> lesCommandesDvd;
        private readonly List<Suivi> lesSuivis;


        /// <summary>
        /// Ouverture de la fenêtre
        /// </summary>
        public Controle()
        {
            lesLivres = Dao.GetAllLivres();
            lesDvd = Dao.GetAllDvd();
            lesRevues = Dao.GetAllRevues();
            lesGenres = Dao.GetAllGenres();
            lesRayons = Dao.GetAllRayons();
            lesPublics = Dao.GetAllPublics();
            lesSuivis = Dao.GetAllSuivis();
            FrmMediatek frmMediatek = new FrmMediatek(this);
            frmMediatek.ShowDialog();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Collection d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return lesGenres;
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Collection d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return lesLivres;
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Collection d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return lesDvd;
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Collection d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return lesRevues;
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Collection d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return lesRayons;
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Collection d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return lesPublics;
        }

        /// <summary>
        /// Recupère tout les statut de la base de données
        /// </summary>
        /// <returns>La liste contenant tout les suivis</returns>
        public List<Suivi> GetAllSuivis()
        {
            return lesSuivis;
        }

        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <returns>Collection d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return Dao.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return Dao.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// getter sur la liste des commandes de livres
        /// </summary>
        /// <returns>Collection d'objets Commandes</returns>
        public List<CommandeDocumentLivre> GetAllCommandesLivres()
        {
            lesCommandesLivres = Dao.GetAllCommandesLivres();
            return lesCommandesLivres;
        }

        /// <summary>
        /// Demande d'ajout d'une commande
        /// </summary>
        /// <param name="commande"></param>
        public void AddCommande(Commande commande)
        {
            Dao.AddCommande(commande);
        }

        /// <summary>
        /// Demande d'ajout d'une commande document
        /// </summary>
        /// <param name="commandedocument"></param>
        public void AddCommandeDocument(CommandeDocument commandedocument)
        {
            Dao.AddCommandeDocument(commandedocument);
        }

        /// <summary>
        /// Demande de modification d'une commande de livre
        /// </summary>
        /// <param name="idCommande"></param>
        /// <param name="idSuivi"></param>
        public void EditCommandeLivre(string idCommande, string idSuivi)
        {
            Dao.EditCommandeLivre(idCommande, idSuivi);
        }

        /// <summary>
        /// Demande de suppression d'une commande de livre
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCmdLivre(string id)
        {
            Dao.DeleteCmdLivre(id);
            Dao.DeleteCmd(id);
        }

        /// <summary>
        /// getter sur la liste des commandes de dvd
        /// </summary>
        /// <returns>Collection d'objets Commandes</returns>
        public List<CommandeDocumentDvd> GetAllCommandesDvd()
        {
            lesCommandesDvd = Dao.GetAllCommandesDvd();
            return lesCommandesDvd;
        }
    }

}


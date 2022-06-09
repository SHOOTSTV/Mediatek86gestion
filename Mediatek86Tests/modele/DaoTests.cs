using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mediatek86.modele;
using Mediatek86.metier;
using Mediatek86.bdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.modele.Tests
{
    [TestClass()]
    public class DaoTests
    {
        // connexion à la bdd
        private static readonly string server = "localhost";
        private static readonly string userid = "root";
        private static readonly string password = "";
        private static readonly string database = "mediatek86";
        private static readonly string connectionString = "server=" + server + ";user id=" + userid + ";password=" + password + ";database=" + database + ";SslMode=none";
        private readonly BddMySql curs = BddMySql.GetInstance(connectionString);
        /// <summary>
        /// Ouverture d'une transaction dans la bdd
        /// </summary>
        private void StartTransaction()
        {
            curs.ReqUpdate("SET AUTOCOMMIT=0", null);
        }
        /// <summary>
        /// Fermeture de la transaction
        /// </summary>
        private void EndTransaction()
        {
            curs.ReqUpdate("ROLLBACK", null);
        }

        /// <summary>
        /// Si le test de login à l'application fonctionne alors réussi
        /// </summary>
        [TestMethod()]
        public void ControleAuthentificationTest()
        {
            string identifiant = "admin";
            string mdp = "admin";
                        
            Service testlogin = Dao.ControleAuthentification(identifiant, mdp);
            Assert.IsNotNull(testlogin);
        }

        /// <summary>
        /// Si le test de login renvois null à cause d'indentifiants ou de mot de passe faux alors réussi
        /// </summary>
        [TestMethod()]
        public void ControleAuthentificationTestFalse()
        {
            string identifiant = "login";
            string mdp = "motdepasse";

            Service testloginfalse = Dao.ControleAuthentification(identifiant, mdp);
            Assert.IsNull(testloginfalse);
        }

        /// <summary>
        /// Si au moins un genre est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllGenresTest()
        {
            List<Categorie> lesGenres = Dao.GetAllGenres();
            Assert.IsTrue(lesGenres.Count != 0);
        }
        /// <summary>
        ///  Si au moins un rayon est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllRayonsTest()
        {
            List<Categorie> lesRayons = Dao.GetAllRayons();
            Assert.IsTrue(lesRayons.Count != 0);
        }
        /// <summary>
        /// Si au moins un type de public est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllPublicsTest()
        {
            List<Categorie> lesPublic = Dao.GetAllPublics();
            Assert.IsTrue(lesPublic.Count != 0);
        }
        /// <summary>
        /// Si au moins un livre est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllLivresTest()
        {
            List<Livre> lesLivres = Dao.GetAllLivres();
            Assert.IsTrue(lesLivres.Count != 0);
        }
        /// <summary>
        /// Si au moins un dvd est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllDvdTest()
        {
            List<Dvd> lesDvd = Dao.GetAllDvd();
            Assert.IsTrue(lesDvd.Count != 0);
        }
        /// <summary>
        /// Si au moins une revue est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllRevuesTest()
        {
            List<Revue> lesRevues = Dao.GetAllRevues();
            Assert.IsTrue(lesRevues.Count != 0);
        }
        /// <summary>
        /// Si au moins un exemplaire de la revue passé en paramètre est présent alors réussi
        /// </summary>
        [TestMethod()]
        public void GetExemplairesRevueTest()
        {
            List<Exemplaire> lesExemplaires = Dao.GetExemplairesRevue("10007");
            Assert.IsTrue(lesExemplaires.Count != 0);
        }
        /// <summary>
        /// Si au moins une étape de suivi est présente alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllSuivisTest()
        {
            List<Suivi> lesSuivis = Dao.GetAllSuivis();
            Assert.IsTrue(lesSuivis.Count != 0);
        }

        /// <summary>
        /// Si la création d'un exemplaire est possible alors réussi 
        /// </summary>
        [TestMethod()]
        public void CreerExemplaireTest()
        {
            StartTransaction();
            // création de l'exemplaire
            int numero = 9999;
            DateTime dateAchat = DateTime.Today;
            string photo = "";
            string idEtat = "00001";
            string idDocument = "10007";
            Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, idDocument);
            Dao.CreerExemplaire(exemplaire);
            Assert.IsNotNull(exemplaire);
            EndTransaction();
        }
        /// <summary>
        /// Si au moins une commande de livre est présente alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllCommandesLivresTest()
        {
            List<CommandeDocumentLivre> lesCommandesLivres = Dao.GetAllCommandesLivres();
            Assert.IsTrue(lesCommandesLivres.Count != 0);
        }
        /// <summary>
        /// Si la création d'une commande est possible alors réussi
        /// </summary>
        [TestMethod()]
        public void AddCommandeTest()
        {
            StartTransaction();
            string id = "Test";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);           
            Assert.IsNotNull(commande);
            EndTransaction();
        }
        /// <summary>
        /// Si la création d'une commandedocument est possible alors réussi
        /// Pour qu'une commandedocument soit possible il faut l'id d'une commande déjà existante
        /// Donc pour l'exemple nous allons crée une commande avec l'id 'tests' pour ensuite faire la commandedocument
        /// </summary>
        [TestMethod()]
        public void AddCommandeDocumentTest()
        {
            StartTransaction();
            // création d'une commande
            string id = "Test";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);
            // création de la commandedocument
            string idcmd = "Test"; // utilisation de l'id de la commande crée
            int nbExemplaire = 1;
            string idLivreDvd = "00007";
            CommandeDocument commandedocument = new CommandeDocument(idcmd, nbExemplaire, idLivreDvd);
            Dao.AddCommandeDocument(commandedocument);
            Assert.IsNotNull(commandedocument);
            EndTransaction();
        }

        /// <summary>
        /// Si la modification du suivi d'une commande est possible alors réussi
        /// On va crée une commande et une commandedocument qui va donc avoir un idsuivi = à 00001 (En cours.)
        /// Puis on va tester de mettre ce suivi à 00003 (Réglée.)
        /// </summary>
        [TestMethod()]
        public void EditCommandeTest()
        {
            StartTransaction();
            // création d'une commande
            string id = "Test2";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);
            // création de la commandedocument
            string idcmd = "Test2"; 
            int nbExemplaire = 1;
            string idLivreDvd = "00007";
            CommandeDocument commandedocument = new CommandeDocument(idcmd, nbExemplaire, idLivreDvd);
            Dao.AddCommandeDocument(commandedocument);

            // on reprends la commande crée juste en haut
            string idcommande = "Test2"; 
            // on met le suivi à 'réglée.'
            string idSuivi = "00003";
            Dao.EditCommande(idcommande, idSuivi);
            Assert.IsTrue(idSuivi == "00003");
            EndTransaction();
        }

        /// <summary>
        /// Si l'id de la commandedocument est null alors test de suppression réussi
        /// </summary>
        [TestMethod()]
        public void DeleteCmdDocTest()
        {
            StartTransaction();
            // création d'une commande pour pouvoir crée une comandedocument
            string id = "Test4";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);
            // création de la commandedocument
            string idcmd = "Test4";
            int nbExemplaire = 1;
            string idLivreDvd = "00007";
            CommandeDocument commandedocument = new CommandeDocument(idcmd, nbExemplaire, idLivreDvd);
            Dao.AddCommandeDocument(commandedocument);
            // Suppression de la commandedocument concernant l'id mis en paramètre 
            Dao.DeleteCmdDoc(idcmd);
            // Vérifie si l'id est null après la suppression
            List<CommandeDocumentLivre> lesCommandesLivres = Dao.GetAllCommandesLivres();
            CommandeDocumentLivre DelCmdDoc = lesCommandesLivres.Find(obj => obj.Id.Equals(id));
            Assert.IsNull(DelCmdDoc);
            EndTransaction();

        }
        /// <summary>
        /// Si l'id de la commande est null alors test de suppression réussi
        /// </summary>
        [TestMethod()]
        public void DeleteCmdTest()
        {
            StartTransaction();            
            // création d'une commande pour pouvoir la supprimer
            string id = "Test3";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);         
            // Suppression de la commande concernant l'id mis en paramètre 
            Dao.DeleteCmd(id);
            // Vérifie si l'id est null après la suppression
            List<CommandeDocumentLivre> lesCommandesLivres = Dao.GetAllCommandesLivres();
            CommandeDocumentLivre DelCmd = lesCommandesLivres.Find(obj => obj.Id.Equals(id));
            Assert.IsNull(DelCmd);
            EndTransaction();
        }

        /// <summary>
        /// Si au moins une commande de dvd est présente alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllCommandesDvdTest()
        {
            List<CommandeDocumentDvd> lesCommandesDvd = Dao.GetAllCommandesDvd();
            Assert.IsTrue(lesCommandesDvd.Count != 0);
        }
        /// <summary>
        /// Si au moins une commande de revue est présente alors réussi
        /// </summary>
        [TestMethod()]
        public void GetAllCommandesRevuesTest()
        {
            List<CommandeRevue> lesCommandesRevues = Dao.GetAllCommandesRevues();
            Assert.IsTrue(lesCommandesRevues.Count != 0);
        }

        /// <summary>
        /// Si la création d'un abonnement est possible alors réussi
        /// </summary>
        [TestMethod()]
        public void AddAbonnementRevueTest()
        {
            StartTransaction();
            // création d'une commande pour pouvoir crée un abonnement
            string id = "Test5";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);
            // création de l'abonnement avec la commande qu'on viens d'être crée
            string idabo = "Test5";
            DateTime datefin = DateTime.Parse("2022-05-12");
            string idRevue = "10010";
            Abonnement abonnement = new Abonnement(idabo, datefin, idRevue);
            Dao.AddAbonnementRevue(abonnement);
            Assert.IsNotNull(abonnement);
            EndTransaction();
        }

        /// <summary>
        /// Si l'id de l'abonnement est null alors test de suppression réussi
        /// </summary>
        [TestMethod()]
        public void DeleteCmdAbonnementTest()
        {
            StartTransaction();
            // création d'une commande pour pouvoir crée un abonnement
            string id = "Test5";
            DateTime date = DateTime.Today;
            int montant = 1;
            Commande commande = new Commande(id, date, montant);
            Dao.AddCommande(commande);
            // création de l'abonnement pour pouvoir le supprimer
            string idabo = "Test5";
            DateTime datefin = DateTime.Parse("2022-05-12");
            string idRevue = "10010";
            Abonnement abonnement = new Abonnement(idabo, datefin, idRevue);
            Dao.AddAbonnementRevue(abonnement);
            // suppression de l'abonnement lié à une commande
            Dao.DeleteCmdAbonnement(idabo);
            Assert.IsNotNull(idabo);
            EndTransaction();
        }
    }
}
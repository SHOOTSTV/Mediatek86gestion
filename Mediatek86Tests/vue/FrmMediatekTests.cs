using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mediatek86.controleur;
using System;
using Mediatek86.metier;

namespace Mediatek86.vue.Tests
{
    [TestClass()]
    public class FrmMediatekTests
    {
        /// <summary>
        /// Si la parution d'un exemplaire est dans la date d'un abonnement alors réussi
        /// </summary>
        [TestMethod()]
        public void ParutionDansAbonnementTest()
        {
            DateTime dateCommande = DateTime.Today;
            DateTime dateFinAbonnement = dateCommande.AddDays(30);
            DateTime dateParutionFalse = dateCommande.AddDays(2);
            DateTime dateParution = dateCommande.AddDays(31);
            FrmMediatek frmMediatek = new FrmMediatek(new Controle(), new Service("admin", 1, "Administratif"));
            Assert.AreEqual(true, frmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParutionFalse), "doit réussir");
            Assert.AreEqual(false, frmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution), "doit échouer");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public class DAO
    {
        public commercialEntities2 ctx
        {
            get { return DAO.Instance.DbEntities; }
            set { DAO.Instance.DbEntities = value; }
        }

        private commercialEntities2 dbEntities;

        public commercialEntities2 DbEntities
        {
            get { return dbEntities; }
            set { dbEntities = value; }
        }

        private static DAO instance;

        private DAO()
        {
            DbEntities = new commercialEntities2();
            
        }

        public static DAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO();
                }
                return instance;
            }
        }


        #region Insert/Update Methodes
        public int InsertOrUpdateClient(DataAccessLib.clientel clt)
        {
            try
            {
                var result = ctx.clientel.SingleOrDefault(c => c.NO_CLIENT == clt.NO_CLIENT);
                if (result != null)
                {
                    result.NOM_CL = clt.NOM_CL;
                    result.PRENOM_CL = clt.PRENOM_CL;
                    result.SOCIETE = clt.SOCIETE;
                    result.VILLE_CL = clt.VILLE_CL;
                    result.ADRESSE_CL = clt.ADRESSE_CL;
                    result.CODE_POST_CL = clt.CODE_POST_CL;

                }
                else
                {
                    ctx.clientel.Add(new DataAccessLib.clientel()
                    {
                        NOM_CL = clt.NOM_CL,
                        ADRESSE_CL = clt.ADRESSE_CL,
                        CODE_POST_CL = clt.CODE_POST_CL,
                        VILLE_CL = clt.VILLE_CL,
                        SOCIETE = clt.SOCIETE,
                        PRENOM_CL = clt.PRENOM_CL,
                        NO_CLIENT = IncremPK(ctx.clientel.AsEnumerable().Last().NO_CLIENT)
                    });
                }

                return ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex) { Debug.Print(ex.ToString()); return 0; }
        }

       

        public int InsertOrUpdateArticles(DataAccessLib.articles art)
        {
            try
            {
                var result = ctx.articles.SingleOrDefault(a => a.NO_ARTICLE == art.NO_ARTICLE);
                if (result != null)
                {
                    result.INTERROMPU = art.INTERROMPU;
                    result.LIB_ARTICLE = art.LIB_ARTICLE;
                    result.PRIX_ART = art.PRIX_ART;
                    result.QTE_DISPO = art.QTE_DISPO;
                    result.VILLE_ART = art.VILLE_ART;

                }
                else
                {
                    ctx.articles.Add(new DataAccessLib.articles()
                    {
                        VILLE_ART = art.VILLE_ART,
                        QTE_DISPO = art.QTE_DISPO,
                        LIB_ARTICLE = art.LIB_ARTICLE,
                        PRIX_ART = art.PRIX_ART,
                        INTERROMPU = art.INTERROMPU,
                        NO_ARTICLE = IncremPK(ctx.articles.AsEnumerable().Last().NO_ARTICLE)
                    });
                }

                return ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex) { Debug.Print(ex.ToString()); return 0; }
        }

        public int InsertOrUpdateVendeur(DataAccessLib.vendeur vd)
        {
            try
            {
                var result = ctx.vendeur.SingleOrDefault(v => v.NO_VENDEUR == vd.NO_VENDEUR);
                if (result != null)
                {

                    result.NO_VEND_CHEF_EQ = vd.NO_VEND_CHEF_EQ;
                    result.NOM_VEND = vd.NOM_VEND;
                    result.PRENOM_VEND = vd.PRENOM_VEND;
                    result.SALAIRE_VEND = vd.SALAIRE_VEND;
                    result.VILLE_VEND = vd.VILLE_VEND;
                    result.COMMISSION = vd.COMMISSION;
                    result.DATE_EMBAU = vd.DATE_EMBAU;

                }
                else
                {
                    ctx.vendeur.Add(new DataAccessLib.vendeur()
                    {
                        COMMISSION = vd.COMMISSION,
                        DATE_EMBAU = vd.DATE_EMBAU,
                        VILLE_VEND = vd.VILLE_VEND,
                        SALAIRE_VEND = vd.SALAIRE_VEND,
                        PRENOM_VEND = vd.PRENOM_VEND,
                        NOM_VEND = vd.NOM_VEND,
                        NO_VEND_CHEF_EQ = vd.vendeur2.NO_VENDEUR,
                        NO_VENDEUR = IncremPK(ctx.vendeur.AsEnumerable().Last().NO_VENDEUR)
                    });
                }

                return ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex) { throw ex; }
        }

        public int InsertOrUpdateCommandes(DataAccessLib.commandes cd)
        {
            try
            {
                var result = ctx.commandes.SingleOrDefault(c => c.NO_COMMAND == cd.NO_COMMAND);
                if (result != null)
                {
                    result.DATE_CDE = cd.DATE_CDE;
                    result.FACTURE = cd.FACTURE;
                    result.NO_CLIENT = cd.clientel.NO_CLIENT;
                    result.NO_VENDEUR = cd.vendeur.NO_VENDEUR;

                }
                else
                {
                    ctx.commandes.Add(new DataAccessLib.commandes()
                    {
                        NO_VENDEUR = cd.vendeur.NO_VENDEUR,
                         NO_CLIENT = cd.clientel.NO_CLIENT,
                          FACTURE = cd.FACTURE,
                           DATE_CDE = cd.DATE_CDE,
                           
                        
                        NO_COMMAND = IncremPK(ctx.commandes.AsEnumerable().Last().NO_COMMAND)
                    });
                }

                return ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex) { throw ex; }
        }

        #endregion

        

        private static string IncremPK(string oldnum)
        {
           var tmp =  int.Parse(oldnum) + 1000001;
           return tmp.ToString().Substring(1);
        }
    }
}

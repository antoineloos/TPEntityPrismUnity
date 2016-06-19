using Infrastructure.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module3.ViewModelModels
{
    public class AjoutCommandeViewModel : BindableBase,IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }

        public string Title { get; set;  }

        private DataAccessLib.commandes newCommande;
        public DataAccessLib.commandes NewCommande
        {
            get { return newCommande; }
            set { SetProperty(ref newCommande, value); }
        }

        private ObservableCollection<DataAccessLib.clientel> lstClient;
        public ObservableCollection<DataAccessLib.clientel> LstClient
        {
            get { return lstClient; }
            set { SetProperty(ref lstClient, value); }
        }

        private ObservableCollection<DataAccessLib.vendeur> lstVendeur;
        public ObservableCollection<DataAccessLib.vendeur> LstVendeur
        {
            get { return lstVendeur; }
            set { SetProperty(ref lstVendeur, value); }
        }
        public DelegateCommand CreerCommand { get; private set; } 
        public string Header { get; set; }
        public AjoutCommandeViewModel()
        {
            Title = "Commandes";
            Header = "Commandes";
            NewCommande = new DataAccessLib.commandes();
            CreerCommand = new DelegateCommand(ValidFunc);
            try
            {
                LstClient = new ObservableCollection<DataAccessLib.clientel>(ctx.clientel.AsEnumerable());
                LstVendeur = new ObservableCollection<DataAccessLib.vendeur>(ctx.vendeur.AsEnumerable());
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        private void ValidFunc()
        {
            try
            {

                if (DataAccessLib.DAO.Instance.InsertOrUpdateCommandes(NewCommande) == 1)
                {
                    MessageBox.Show("La modification à bien été prise en compte");
                    
                }

            }

            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
        }
    }
}

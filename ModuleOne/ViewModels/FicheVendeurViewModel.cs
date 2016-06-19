using Infrastructure.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModuleOne.ViewModels
{
    public class FicheVendeurViewModel : BindableBase, IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        
        private DataAccessLib.vendeur selectedVd;
        public DataAccessLib.vendeur SelectedVd
        {
            get { return selectedVd; }
            set { SetProperty(ref selectedVd, value); }
        }


        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public string Title { get; set; }
        public string Header { get; set; }

        private ObservableCollection<DataAccessLib.vendeur> lstVendeur;
        public ObservableCollection<DataAccessLib.vendeur> LstVendeur
        {
            get { return lstVendeur; }
            set { SetProperty(ref lstVendeur, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand SuprCommand { get; private set; } 
        public FicheVendeurViewModel(INavMethods _navMethods)
        {
            Title = "Vendeur";
            Header = "Vendeur";
            SelectedVd = new DataAccessLib.vendeur();
            UpdateCommand = new DelegateCommand(UpdateClt);
            SelectCommand = new DelegateCommand(SelectFunc);
            SuprCommand = new DelegateCommand(SuprFunc);
            IsSelected = false;
            try
            {
                LstVendeur = new ObservableCollection<DataAccessLib.vendeur>(ctx.vendeur.AsEnumerable());
                LstVendeur.Insert(0, new DataAccessLib.vendeur() { NOM_VEND = "Nouveau ..." , vendeur2 = ctx.vendeur.FirstOrDefault()});
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }

        private void SuprFunc()
        {
            MessageBox.Show("Fonction non implémenté car aucune stratégie de supression n'est indiquées de le TP\n ici il s'agit d'archiver plutot que de suprrimer\n problème de foraing key avec commande par exemple");
        }

        private void SelectFunc()
        {
            if (SelectedVd.NOM_VEND != null)
            {
                IsSelected = true;
            }
        }

        private void UpdateClt()
        {
            try 
            {
                
                if (DataAccessLib.DAO.Instance.InsertOrUpdateVendeur(SelectedVd) == 1) 
                {
                    MessageBox.Show("La modification à bien été prise en compte");
                    if (LstVendeur.Where(v => v.NOM_VEND == "Nouveau ...").Count() == 0)
                    {
                        LstVendeur.Insert(0, new DataAccessLib.vendeur() { NOM_VEND = "Nouveau ...", vendeur2 = ctx.vendeur.FirstOrDefault() });
                        
                       
                    }
                    SelectedVd = ctx.vendeur.AsEnumerable().Last();
                }
               
            }
            
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
        }

      
    }
}

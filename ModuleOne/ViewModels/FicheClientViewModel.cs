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

namespace ModuleOne.ViewModels
{
    public class FicheClientViewModel : BindableBase, IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        private DataAccessLib.clientel selectedClt;
        public DataAccessLib.clientel SelectedClt
        {
            get { return selectedClt; }
            set { SetProperty(ref selectedClt, value); }
        }

        public string Title { get; set; }
        public string Header { get; set; }

        private ObservableCollection<DataAccessLib.clientel> lstClient;
        public ObservableCollection<DataAccessLib.clientel> LstClient
        {
            get { return lstClient; }
            set { SetProperty(ref lstClient, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand SuprCommand { get; private set; } 
        
        public FicheClientViewModel(INavMethods _navMethods)
        {
            Title = "Client";
            Header = "Client";
           
            SelectedClt = new DataAccessLib.clientel();
            UpdateCommand = new DelegateCommand(UpdateClt);
            SelectCommand = new DelegateCommand(SelectFunc);
            SuprCommand = new DelegateCommand(SuprFunc);
            try
            {
                LstClient = new ObservableCollection<DataAccessLib.clientel>(ctx.clientel.AsEnumerable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SuprFunc()
        {
            MessageBox.Show("non implémenté : consigne pas claire entre dans le tp  : archivage ou supression ? ");
        }

        private void SelectFunc()
        {
            IsSelected = true;
        }

        private void UpdateClt()
        {
            try
            {

                if (DataAccessLib.DAO.Instance.InsertOrUpdateClient(SelectedClt) == 1)
                {
                    MessageBox.Show("La modification à bien été prise en compte");
                    if (LstClient.Where(v => v.NOM_CL == "Nouveau ...").Count() == 0)
                    {
                        LstClient.Insert(0, new DataAccessLib.clientel() { NOM_CL = "Nouveau ..." });


                    }
                    SelectedClt = ctx.clientel.AsEnumerable().Last();
                }

            }

            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
        }

        
       
    }
}

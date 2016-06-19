using Infrastructure.Core;
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
    public class FicheArticlesViewModel : BindableBase , IViewModel
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

        private ObservableCollection<DataAccessLib.articles> lstArticles;
        public ObservableCollection<DataAccessLib.articles> LstArticles
        {
            get { return lstArticles; }
            set { SetProperty(ref lstArticles, value); }
        }

        private DataAccessLib.articles selectedArt;
        public DataAccessLib.articles SelectedArt
        {
            get { return selectedArt; }
            set { SetProperty(ref selectedArt, value); }
        }
      
        public string Title { get; set; }

      

        public string Header { get; set; }

        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand SelectCommand { get; private set; }
        public DelegateCommand SuprCommand { get; private set; } 

        public FicheArticlesViewModel(INavMethods _navMethods)
        {
            Title = "Article";
            Header = "Article";
          
            SelectedArt = new DataAccessLib.articles();

            UpdateCommand = new DelegateCommand(UpdateArt);
            SelectCommand = new DelegateCommand(SelectFunc);
            SuprCommand = new DelegateCommand(SuprFunc);
            try
            {
                LstArticles = new ObservableCollection<DataAccessLib.articles>(ctx.articles.AsEnumerable());
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

        private void UpdateArt()
        {
            try
            {

                if (DataAccessLib.DAO.Instance.InsertOrUpdateArticles(SelectedArt) == 1)
                {
                    MessageBox.Show("La modification à bien été prise en compte");
                    if (LstArticles.Where(v => v.LIB_ARTICLE == "Nouveau ...").Count() == 0)
                    {
                        LstArticles.Insert(0, new DataAccessLib.articles() { LIB_ARTICLE = "Nouveau ..." });


                    }
                    SelectedArt = ctx.articles.AsEnumerable().Last();
                }

            }

            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
        }


      
    }
}

using Infrastructure.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module2.ViewModels
{
    public class ArticlesViewModel : BindableBase, IViewModel
    {

        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        public string Title { get; set; }
        public string Header { get; set; }

        private DataAccessLib.clientel selectedClt;
        

        private ObservableCollection<DataAccessLib.articles> lstArticles;
        public ObservableCollection<DataAccessLib.articles> LstArticles
        {
            get { return lstArticles; }
            set { SetProperty(ref lstArticles, value); }
        }
        public ArticlesViewModel()
        {
            Title = "Liste Articles";
            Header = "Liste Articles";
          


            try
            {
                LstArticles = new ObservableCollection<DataAccessLib.articles>(ctx.articles.AsEnumerable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

    }
}

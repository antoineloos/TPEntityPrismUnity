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
    public class ClientsViewModel : BindableBase , IViewModel
    {
         public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        public string Title { get; set; }
        public string Header { get; set; }

        public string Contenu { get; set; }

        private ObservableCollection<DataAccessLib.clientel> lstClient;
        public ObservableCollection<DataAccessLib.clientel> LstClient
        {
            get { return lstClient; }
            set { SetProperty(ref lstClient, value); }
        }
        public ClientsViewModel()
        {
            Title = "Liste Client";
            Header = "Liste Client";
            
            try
            {
                LstClient = new ObservableCollection<DataAccessLib.clientel>(ctx.clientel.AsEnumerable());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vous n'êtes pas connecté à la base de donnée");
            }
            
            
        }
        
    }
}

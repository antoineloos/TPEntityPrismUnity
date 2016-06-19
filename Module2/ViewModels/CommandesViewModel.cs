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
    public class CommandesViewModel : BindableBase,IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        public string Title { get; set; }
        public string Header { get; set; }

        public string Contenu { get; set; }

        private ObservableCollection<DataAccessLib.commandes> lstCommande;
        public ObservableCollection<DataAccessLib.commandes> LstCommande
        {
            get { return lstCommande; }
            set { SetProperty(ref lstCommande, value); }
        }
        public CommandesViewModel()
        {
            Title = "Liste Commandes";
            Header = "Liste Commandes";
            
            try
            {
                LstCommande = new ObservableCollection<DataAccessLib.commandes>(ctx.commandes.AsEnumerable());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vous n'êtes pas connecté à la base de donnée");
            }
            
            
        }
       
    }
}

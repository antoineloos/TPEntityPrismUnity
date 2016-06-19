﻿using Infrastructure.Interfaces;
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
    public class VendeurViewModel : BindableBase , IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        public string Title { get; set; }
        public string Header { get; set; }

        public string Contenu { get; set; }

        private ObservableCollection<DataAccessLib.vendeur> lstVendeur;
        public ObservableCollection<DataAccessLib.vendeur> LstVendeur
        {
            get { return lstVendeur; }
            set { SetProperty(ref lstVendeur, value); }
        }
        public VendeurViewModel()
        {
            Title = "Liste Vendeurs";
            Header = "Liste Vendeurs";
            
            try
            {
                LstVendeur = new ObservableCollection<DataAccessLib.vendeur>(ctx.vendeur.AsEnumerable());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vous n'êtes pas connecté à la base de donnée");
            }
            
            
        }
    }
}

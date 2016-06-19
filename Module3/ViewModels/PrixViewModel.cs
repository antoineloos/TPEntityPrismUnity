using Infrastructure.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module3.ViewModelModels
{
    public class PrixViewModel : BindableBase, IViewModel
    {
        public DataAccessLib.commercialEntities2 ctx
        {
            get { return DataAccessLib.DAO.Instance.DbEntities; }
            set { DataAccessLib.DAO.Instance.DbEntities = value; }
        }
        public DelegateCommand<RoutedPropertyChangedEventArgs<double>> CommandVChanged { get; private set; }
        public DelegateCommand IsNegCommand { get; private set; }
        public DelegateCommand ValidCommand { get; private set; } 
        public PrixViewModel()
        {
            Title = "Prix";
            Header = "Prix";
            CommandVChanged = new DelegateCommand<RoutedPropertyChangedEventArgs<double>>( ChangVFunc);
            IsNegCommand = new DelegateCommand(ToggleIsNeg);
            ValidCommand = new DelegateCommand(ValidFunc);
            IsNegatif = false;
            LbIsNeg = "Augmentation de : ";
        }

        private void ValidFunc()
        {
            if (IsNegatif)
            {
                double? tmp = 0.1*double.Parse(LbPourcentage.Substring(1, LbPourcentage.Length - 1));
            }
            else
            {
                double? tmp = 1+0.1 * double.Parse(LbPourcentage.Substring(0, LbPourcentage.Length - 1));
            }
            
           MessageBox.Show("le prix de vos produit vient d'être modifier");
        }

        private void ToggleIsNeg()
        {
            IsNegatif = !IsNegatif;
            if (IsNegatif) LbIsNeg = "Diminution de :";
            else LbIsNeg = "Augmentation de : ";
        }

        private void ChangVFunc(RoutedPropertyChangedEventArgs<double> obj)
        {
            if (IsNegatif)
            {
                LbPourcentage = ((int)obj.NewValue*(-1)).ToString() + "%";
            }
            else
            {
                LbPourcentage = ((int)obj.NewValue ).ToString() + "%";
            }
            
        }

        public string Title { get; set; }


        public string Header { get; set; }

        private bool isNegatif;
        public bool IsNegatif
        {
            get { return isNegatif; }
            set { SetProperty(ref isNegatif, value); }
        }

        private string lbIsNeg;
        public string LbIsNeg
        {
            get { return lbIsNeg; }
            set { SetProperty(ref lbIsNeg, value); }
        }

        private string lbPourcentage;
        public string LbPourcentage
        {
            get { return lbPourcentage; }
            set { SetProperty(ref lbPourcentage, value); }
        }
        
    }
}

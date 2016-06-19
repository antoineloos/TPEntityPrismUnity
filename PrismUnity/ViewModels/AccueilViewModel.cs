using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnity.ViewModels
{
    public class AccueilViewModel : BindableBase,IViewModel
    {
        public string Title { get; set; }


        public string Header { get; set; }

    

        public AccueilViewModel()
        {
           
        }

      


        
    }
}

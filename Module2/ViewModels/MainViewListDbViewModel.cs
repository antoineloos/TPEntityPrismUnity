using Infrastructure.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2.ViewModels
{
    public class MainViewListDbViewModel : BindableBase , IViewModel
    {
        public string Title {get;set;}
        public string Header { get; set; }

        public MainViewListDbViewModel ()
	    {
            Title = "Listes";
            Header = "Listes";
	    }
        
    }
}

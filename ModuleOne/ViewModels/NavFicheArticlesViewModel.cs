using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleOne.ViewModels
{
    public class NavFicheArticlesViewModel : BindableBase, IViewModel
    {
        public INavMethods _navMethods { get; set; }
        public IEventAggregator _eventAggregator { get; set; }
        public DelegateCommand NavCommand { get; private set; } 
        public NavFicheArticlesViewModel(INavMethods navMethods )
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _navMethods = navMethods;
            NavCommand = new DelegateCommand(NavFunc);
        }

        private void NavFunc()
        {
            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish("Article");
        }


        public string Title { get; set; }


        public string Header { get; set; }
        
    }
}

using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleOne.ViewModels
{
    public class NavFicheClientViewModel
    {
        public IEventAggregator _eventAggregator { get; set; }
        public DelegateCommand NavCommand { get; private set; }
        public NavFicheClientViewModel(INavMethods navMethods)
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            
            NavCommand = new DelegateCommand(NavFunc);
        }

        private void NavFunc()
        {
            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish("Client");
        }

    }
}

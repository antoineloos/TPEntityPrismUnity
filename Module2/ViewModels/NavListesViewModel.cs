using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2.ViewModels
{
    public class NavListesViewModel
    {
        public IEventAggregator _eventAggregator { get; set; }
        public DelegateCommand NavCommand { get; private set; }
        public NavListesViewModel(INavMethods navMethods)
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            
            NavCommand = new DelegateCommand(NavFunc);
        }

        private void NavFunc()
        {
            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish("Listes");
        }

    }
}

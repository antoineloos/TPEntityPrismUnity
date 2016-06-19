using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.ViewModelModels
{
    public class NavPrixViewModel : BindableBase , IViewModel
    {
   
        public IEventAggregator _eventAggregator { get; set; }
        public DelegateCommand NavCommand { get; private set; }
        public NavPrixViewModel()
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            NavCommand = new DelegateCommand(NavFunc);
        }

        private void NavFunc()
        {
            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish("Prix");
        }


        public string Title { get; set; }


        public string Header { get; set; }
    }
}

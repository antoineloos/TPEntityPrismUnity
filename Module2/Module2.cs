using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using Module2.ViewModels;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    public class Module2 : IModule
    {
       
            private readonly IUnityContainer _container;
            private readonly IRegionManager _manager;

            public Module2(IUnityContainer container, IRegionManager manager)
            {
                _container = container;
                _manager = manager;
            }

            public void Initialize()
            {
                _container.RegisterType<IViewModel, MainViewListDbViewModel>("MainViewModel");
                var viewM = _container.Resolve<Views.MainViewListDb>();
                _manager.Regions[RegionNames.MainContentRegion].Add(viewM);

                var NavViewM = _container.Resolve<Views.NavListes>();
                _manager.Regions[RegionNames.AccueilRegion].Add(NavViewM);
            }
        
    }
}

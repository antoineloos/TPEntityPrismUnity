using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using Module3.ViewModelModels;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    public class Module3 : IModule
    {
        private readonly IUnityContainer _container;
            private readonly IRegionManager _manager;

            public Module3(IUnityContainer container, IRegionManager manager)
            {
                _container = container;
                _manager = manager;
            }

            public void Initialize()
            {
                _container.RegisterType<IViewModel, PrixViewModel>("PrixViewModel");
                var viewM = _container.Resolve<Views.Prix>();
                _manager.Regions[RegionNames.MainContentRegion].Add(viewM);


                _container.RegisterType<IViewModel, AjoutCommandeViewModel>("AjoutCViewModel");
                var viewA = _container.Resolve<Views.AjoutCommande>();
                _manager.Regions[RegionNames.MainContentRegion].Add(viewA);

                //

                var viewNavP = _container.Resolve<Views.NavPrix>();
                _manager.Regions[RegionNames.AccueilRegion].Add(viewNavP);

                var viewNavC = _container.Resolve<Views.NavCommande>();
                _manager.Regions[RegionNames.AccueilRegion].Add(viewNavC);
            }
    }
}

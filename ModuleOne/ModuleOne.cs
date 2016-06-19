using System;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using ModuleOne.ViewModels;
using ModuleOne.Views;

namespace ModuleOne
{
    public class ModuleOne : IModule
    {
        public ModuleOne(IUnityContainer container, IRegionManager regionManager)
        {
            if(container == null)throw new ArgumentNullException("container");
            if(regionManager == null) throw new ArgumentNullException("regionManager");
            _container = container;
            _regionManager = regionManager;
            _navMethods = _container.Resolve<INavMethods>();
        }

        public void Initialize()
        {

            _container.RegisterType<Object, FicheClient>("FicheClient");
            _container.RegisterType<IViewModel, FicheClientViewModel>("ClientViewModel", new InjectionConstructor(_navMethods));
            var viewC = _container.Resolve<Views.FicheClient>();
            _regionManager.Regions[RegionNames.MainContentRegion].Add(viewC,"FicheClient");

            _container.RegisterType<Object, FicheClient>("FicheArticles");
            _container.RegisterType<IViewModel, FicheArticlesViewModel>("ArticlesViewModel", new InjectionConstructor(_navMethods));
            var viewA = _container.Resolve<Views.FicheArticles>();
            _regionManager.Regions[RegionNames.MainContentRegion].Add(viewA,"FicheArticles");

            _container.RegisterType<Object, FicheClient>("FicheVendeur");
            _container.RegisterType<IViewModel, FicheVendeurViewModel>("VendeurViewModel", new InjectionConstructor(_navMethods));
            var viewV = _container.Resolve<Views.FicheVendeur>();
            _regionManager.Regions[RegionNames.MainContentRegion].Add(viewV ,"FicheVendeur");

            
            var viewNavC = _container.Resolve<Views.NavFicheClient>();
            _regionManager.Regions[RegionNames.AccueilRegion].Add(viewNavC);

            var viewNavV = _container.Resolve<Views.NavFicheVendeur>();
            _regionManager.Regions[RegionNames.AccueilRegion].Add(viewNavV);

            _container.RegisterType<IViewModel, NavFicheArticlesViewModel>("NavCViewModel", new InjectionConstructor(_navMethods));
            var viewNavA = _container.Resolve<Views.NavFicheArticles>();
            _regionManager.Regions[RegionNames.AccueilRegion].Add(viewNavA);

            
        }

        private readonly INavMethods _navMethods;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
    }
}

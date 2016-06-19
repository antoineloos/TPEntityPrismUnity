using System.Windows;
using Dragablz;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Microsoft.Practices.Unity;
using PrismUnity.ViewModels;
using PrismUnity.Views;
using VDeskToolBox.Utils;
using System.Windows.Controls;
using Prism.Events;
using System.IO;
using PrismUnity.Utils;

namespace PrismUnity
{
    public class Bootstrapper : UnityBootstrapper
    {
        public IEventAggregator _eventAggregator { get; set; }
        

        protected override DependencyObject CreateShell()
        {
            var view = Container.TryResolve<Shell>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
            
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var regionManager = Container.Resolve<IRegionManager>();
            _navMethods = new NavMethods(Container, regionManager);
            _eventAggregator = new EventAggregator();
            Container.RegisterInstance<IEventAggregator>(_eventAggregator, new ContainerControlledLifetimeManager());
            Container.RegisterInstance<INavMethods>(_navMethods, new ContainerControlledLifetimeManager());
            Container.RegisterType<IViewModel, ShellViewModel>("ShellViewModel", new InjectionConstructor(regionManager, Container));
        }



        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            mappings.RegisterMapping(typeof(WrapPanel), Container.Resolve<WrapPanelRegionAdapter>());
            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(TabablzControl), new TabablzControlRegionAdapter(regionBehaviorFactory));
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {

            DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
            return catalog;
        }

        private INavMethods _navMethods;
    }
}

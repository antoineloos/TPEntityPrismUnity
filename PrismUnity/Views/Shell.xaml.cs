using System.Windows;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using System.Windows.Controls;

namespace PrismUnity.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell([Dependency("ShellViewModel")]IViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            _navMethods.ShellTabControl = MainTabControl;
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(NavHanlder, true);
            
        }


        /// <summary>
        /// A NE JAMAIS FAIRE ; CECI EST TRES MAUVAIS BRICOLAGE POUR LA NAVIGATION DES ONGLETS ; PASSEZ PAR LE SYSTEM DE NAVIGATION DE PRISM
        /// </summary>
        /// <param name="obj"></param>
        private void NavHanlder(string obj)
        {
            foreach (TabItem elem in MainTabControl.Items)
            {
                if (elem.Header.ToString() == obj)
                {
                    elem.IsSelected = true;
                }
            }
        }
        private IEventAggregator _eventAggregator{ get; set; }
        private INavMethods _navMethods = ServiceLocator.Current.GetInstance<INavMethods>();

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public string Header
        {
            get { return ViewModel.Header; }
            set { ViewModel.Header = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Accueil.IsSelected = true;
        }

      
    }
}

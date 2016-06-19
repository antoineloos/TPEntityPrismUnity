using Module3.ViewModelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module3.Views
{
    /// <summary>
    /// Logique d'interaction pour NavCommande.xaml
    /// </summary>
    public partial class NavCommande : UserControl
    {
        public NavCommande()
        {
            InitializeComponent();
            this.DataContext = new NavCommandeViewModel();
        }
    }
}

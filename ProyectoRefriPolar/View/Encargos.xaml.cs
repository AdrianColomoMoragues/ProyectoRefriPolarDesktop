using ProyectoRefriPolar.ViewModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProyectoRefriPolar.View
{
    /// <summary>
    /// Lógica de interacción para Encargos.xaml
    /// </summary>
    public partial class Encargos : UserControl
    {
        EncargosVM vm;
        private ObservableCollection<Model.Encargos> searchResult;
        public Encargos()
        {
            vm = new EncargosVM();
            InitializeComponent();
            searchResult = new ObservableCollection<Model.Encargos>();
            this.DataContext = vm;
        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchResult.Clear();

            string searchText = textSearch.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                listSearchRearch.ItemsSource = searchResult;
                foreach (Model.Encargos encargo in vm.ListaEncargos)
                {
                    if (encargo.nombre.ToLower().Contains(searchText))
                    {
                        searchResult.Add(encargo);
                    }
                }
            }
            else
            {
                listSearchRearch.ItemsSource = vm.ListaEncargos;
            }

        }
    }
}

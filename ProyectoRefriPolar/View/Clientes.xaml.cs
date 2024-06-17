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
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        ClientesVM vm;
        private ObservableCollection<Model.Clientes> searchResult;
        public Clientes()
        {
            vm = new ClientesVM();
            InitializeComponent();
            searchResult = new ObservableCollection<Model.Clientes>();
            this.DataContext = vm;
        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchResult.Clear();

            string searchText = textSearch.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                listSearchRearch.ItemsSource = searchResult;
                foreach (Model.Clientes clientes in vm.ListaClientes)
                {
                    if (clientes.nombre.ToLower().Contains(searchText))
                    {
                        searchResult.Add(clientes);
                    }
                }
            }
            else
            {
                listSearchRearch.ItemsSource = vm.ListaClientes;
            }
        }
    }
}

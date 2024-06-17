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
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : UserControl
    {
        EmpleadosVM vm;
        private ObservableCollection<Model.Empleados> searchResult;
        public Empleados()
        {
            vm = new EmpleadosVM();
            InitializeComponent();
            searchResult = new ObservableCollection<Model.Empleados>();
            this.DataContext = vm;
        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchResult.Clear();

            string searchText = textSearch.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                listSearchRearch.ItemsSource = searchResult;
                foreach (Model.Empleados empleado in vm.ListaEmpleados)
                {
                    if (empleado.nombre.ToLower().Contains(searchText) ||empleado.apellido1.ToLower().Contains(searchText) || empleado.apellido2.ToLower().Contains(searchText))
                    {
                        searchResult.Add(empleado);
                    }
                }
            }
            else
            {
                listSearchRearch.ItemsSource = vm.ListaEmpleados;
            }
        }
    }
}

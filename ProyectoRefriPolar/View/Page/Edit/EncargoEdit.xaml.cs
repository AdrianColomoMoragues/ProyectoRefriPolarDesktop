using ProyectoRefriPolar.ViewModel.Page.Edit;
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

namespace ProyectoRefriPolar.View.Page.Edit
{
    /// <summary>
    /// Lógica de interacción para EncargoEdit.xaml
    /// </summary>
    public partial class EncargoEdit : UserControl
    {
        EncargoEditVM vm;
        public EncargoEdit()
        {
            vm = new EncargoEditVM();
            InitializeComponent();
            this.DataContext = vm;
        }

        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vm.EncargoSeleccionado.idEncargado != null)
            {
                if (vm.EncargoSeleccionado.idEncargado.codcategoriaProfesional.encargo != vm.EncargoSeleccionado.tipo)
                {
                    vm.EncargoSeleccionado.idEncargado = null;
                }
            }
            foreach (Model.Empleados empleado in vm.EncargoSeleccionado.empleadosCollection)
            {
                if (vm.EncargoSeleccionado.tipo.ToLower() != empleado.codcategoriaProfesional.encargo.ToLower())
                {
                    vm.EncargoSeleccionado.empleadosCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Empleados>();
                    break;
                }
            }
            vm.ListaEmpleados = vm.GetEncargados();
        }
    }
}

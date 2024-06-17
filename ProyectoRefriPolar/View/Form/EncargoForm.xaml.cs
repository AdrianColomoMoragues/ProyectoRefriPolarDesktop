using ProyectoRefriPolar.ViewModel.Form;
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

namespace ProyectoRefriPolar.View.Form
{
    /// <summary>
    /// Lógica de interacción para EncargoForm.xaml
    /// </summary>
    public partial class EncargoForm : UserControl
    {
        EncargoFormVM vm;
        public EncargoForm()
        {
            vm = new EncargoFormVM();
            InitializeComponent();
            this.DataContext = vm;
        }

        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vm.NuevoEncargo.idEncargado != null)
            {
                if (vm.NuevoEncargo.idEncargado.codcategoriaProfesional.encargo != vm.NuevoEncargo.tipo)
                {
                    vm.NuevoEncargo.idEncargado = null;
                }
            }
            foreach (Model.Empleados empleado in vm.NuevoEncargo.empleadosCollection)
            {
                if (vm.NuevoEncargo.tipo.ToLower() != empleado.codcategoriaProfesional.encargo.ToLower())
                {
                    vm.NuevoEncargo.empleadosCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Empleados>();
                    break;
                }
            }
            vm.ListaEmpleados = vm.GetEncargados();
        }
    }
}

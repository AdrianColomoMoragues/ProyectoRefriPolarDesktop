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
    /// Lógica de interacción para EmpleadoForm.xaml
    /// </summary>
    public partial class EmpleadoForm : UserControl
    {
        EmpleadoFormVM vm;
        public EmpleadoForm()
        {
            vm = new EmpleadoFormVM();
            InitializeComponent();
            this.DataContext = vm;
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string ruta = vm.AbrirDialogo();
            if (ruta == "")
            {
                if (vm.NuevoEmpleado.imagen == null)
                {
                    vm.NuevoEmpleado.imagen = null;
                }
            }
            else
            {
                vm.NuevoEmpleado.imagen = ruta;
            }

        }
    }
}

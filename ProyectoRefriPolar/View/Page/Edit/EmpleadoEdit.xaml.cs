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
    /// Lógica de interacción para EmpleadoEdit.xaml
    /// </summary>
    public partial class EmpleadoEdit : UserControl
    {
        EmpleadoEditVM vm;
        public EmpleadoEdit()
        {
            vm = new EmpleadoEditVM();
            InitializeComponent();
            this.DataContext = vm;
            vm.EmpleadoSeleccionado.apellido1 = vm.EmpleadoSeleccionado.apellido1 + " " + vm.EmpleadoSeleccionado.apellido2;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string ruta = vm.AbrirDialogo();
            if (ruta == "")
            {
                if (vm.EmpleadoSeleccionado.imagen == null)
                {
                    vm.EmpleadoSeleccionado.imagen = null;
                }
            }
            else
            {
                vm.EmpleadoSeleccionado.imagen = ruta;
            }
        }
    }
}

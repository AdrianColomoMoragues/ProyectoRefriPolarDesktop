using ProyectoRefriPolar.mensajeria;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRefriPolar.ViewModel
{
    internal class EmpleadosVM : ObservableObject
    {
        private Empleados empleadoSeleccionado;
        public Empleados EmpleadoSeleccionado
        {
            get { return empleadoSeleccionado; }
            set { SetProperty(ref empleadoSeleccionado, value); }
        }
        private ObservableCollection<Empleados> listaEmpleados;
        public ObservableCollection<Empleados> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { SetProperty(ref listaEmpleados, value); }
        }
        private AzureService azureService;

        private NavegacionService navegacionService;
        private EmpleadosService empleadoService;
        public RelayCommand EliminarCommand { get; }
        public RelayCommand CrearEmpleadoCommand { get; }
        public RelayCommand ConsultaEmpleadoCommand { get; }
        public EmpleadosVM()
        {
            azureService = new AzureService();
            navegacionService = new NavegacionService();
            empleadoService = new EmpleadosService();
            listaEmpleados = empleadoService.GetEmpleados();
            ObtenerImagenes();
            EliminarCommand = new RelayCommand(Eliminar);
            CrearEmpleadoCommand = new RelayCommand(CrearEmpleado);
            ConsultaEmpleadoCommand = new RelayCommand(Consulta);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EmpleadosVM, ConsultaEmpleadoMensaje>(this, (r, m) =>
            {
                m.Reply(EmpleadoSeleccionado.id);
            });
        }
        public void Consulta()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEmpleado());
        }
        public void CrearEmpleado()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearEmpleado());
        }
        private void Eliminar()
        {
            int id = EmpleadoSeleccionado.id;
            listaEmpleados.Remove(EmpleadoSeleccionado);
            empleadoService.DeleteEmpleado(id);
        }
        public void ObtenerImagenes()
        {
            foreach (Empleados empleado in listaEmpleados)
            {
                string imagen = empleado.imagen;
                if (imagen != "" || imagen != null)
                {
                    string urlImagen = azureService.url(imagen);
                    empleado.imagen = imagen;
                }
            }
        }
    }
}

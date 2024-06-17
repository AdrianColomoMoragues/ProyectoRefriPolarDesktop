using ProyectoRefriPolar.mensajeria;
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
using System.Windows.Controls;

namespace ProyectoRefriPolar.ViewModel
{
    class MainWindowVM : ObservableObject
    {
        private UserControl contenidoVista;
        public UserControl ContenidoVista
        {
            get { return contenidoVista; }
            set { SetProperty(ref contenidoVista, value); }
        }
        private string _ventanaNombre;
        public string VentanaNombre
        {
            get { return _ventanaNombre; }
            set { SetProperty(ref _ventanaNombre, value); }
        }
        public RelayCommand AbrirInicioCommand { get; }
        public RelayCommand AbrirClientesCommand { get; }
        public RelayCommand AbrirEmpleadosCommand { get; }
        public RelayCommand AbrirEncargosCommand { get; }
        private NavegacionService servicioNavegacion;
        public MainWindowVM()
        {
            VentanaNombre = "INICIO";
            servicioNavegacion = new NavegacionService();
            AbrirInicioCommand = new RelayCommand(AbrirIncio);
            AbrirClientesCommand = new RelayCommand(AbrirClientes);
            AbrirEmpleadosCommand = new RelayCommand(AbrirEmpleados);
            AbrirEncargosCommand = new RelayCommand(AbrirEncargos);
            AbrirIncio();
            EventAggregator.Instance.ChangeUserControlRequested += OnChangeUserControlRequested;
            EventAggregator.Change.ChangeWindowNameRequested += OnChangeWindowNameResquested;
        }
        public void OnChangeUserControlRequested(object sender, ChangeUserControlEvent e)
        {
            ContenidoVista = e.NewUserControl;
        }
        public void OnChangeWindowNameResquested(object sender, ChangeWindowNameEvent e)
        {
            VentanaNombre = e.WindowName;
        }
        public void AbrirIncio()
        {
            VentanaNombre = "INICIO";
            ContenidoVista = servicioNavegacion.CargarInicio();
        }
        public void AbrirClientes()
        {
            VentanaNombre = "CLIENTES";
            ContenidoVista = servicioNavegacion.CargarClientes();
        }
        public void AbrirEmpleados()
        {
            VentanaNombre = "EMPLEADOS";
            ContenidoVista = servicioNavegacion.CargarEmpleados();
        }
        public void AbrirEncargos()
        {
            VentanaNombre = "ENCARGOS";
            ContenidoVista = servicioNavegacion.CargarEncargos();
        }
    }
}

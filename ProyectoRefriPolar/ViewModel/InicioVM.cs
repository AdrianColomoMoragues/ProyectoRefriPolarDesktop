using ProyectoRefriPolar.Services;
using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.ViewModel
{
    class InicioVM : ObservableObject
    {
        private NavegacionService navegacionService;
        public RelayCommand Encargos { get; }
        public RelayCommand Clientes { get; } 
        public RelayCommand Empleados { get; }
        public RelayCommand NuevoCliente { get; }
        public RelayCommand NuevoEmpleado { get; }
        public RelayCommand NuevoEncargo { get; }
        public InicioVM()
        {
            navegacionService = new NavegacionService();
            Encargos = new RelayCommand(AbrirEncargos);
            Clientes = new RelayCommand(AbrirClientes);
            Empleados = new RelayCommand(AbrirEmpleados);
            NuevoCliente = new RelayCommand(AbrirNuevoCliente);
            NuevoEmpleado = new RelayCommand(AbrirNuevoEmpleados);
            NuevoEncargo = new RelayCommand(AbrirNuevoEncargo);
        }
        private void AbrirEncargos()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEncargos());
            EventAggregator.Change.PublishChangeWindowNameEvent("ENCARGOS");
        }
        private void AbrirClientes()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarClientes());
            EventAggregator.Change.PublishChangeWindowNameEvent("CLIENTES");
        }
        private void AbrirEmpleados()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEmpleados());
            EventAggregator.Change.PublishChangeWindowNameEvent("EMPLEADOS");
        }
        private void AbrirNuevoEmpleados()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearEmpleado());
            EventAggregator.Change.PublishChangeWindowNameEvent("EMPLEADOS");
        }
        private void AbrirNuevoCliente()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearCliente());
            EventAggregator.Change.PublishChangeWindowNameEvent("CLIENTES");
        }
        private void AbrirNuevoEncargo()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearEncargo());
            EventAggregator.Change.PublishChangeWindowNameEvent("ENCARGOS");
        }
    }
}

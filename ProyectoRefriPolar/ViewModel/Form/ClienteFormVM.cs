using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ProyectoRefriPolar.ViewModel.Form
{
    internal class ClienteFormVM : ObservableObject
    {
        private Clientes nuevoCliente;
        public Clientes NuevoCliente
        {
            get { return nuevoCliente; }
            set { SetProperty(ref nuevoCliente, value); }
        }
        private ClientesService servicioCliente;
        private NavegacionService navegacionService;
        public RelayCommand CrearClienteCommand { get; }
        public RelayCommand BackCommand { get; }
        public ClienteFormVM()
        {
            navegacionService = new NavegacionService();
            nuevoCliente = new Clientes();
            servicioCliente = new ClientesService();
            CrearClienteCommand = new RelayCommand(PostCliente);
            BackCommand = new RelayCommand(Back);
        }
        private void PostCliente()
        {
            NuevoCliente.id = servicioCliente.GetMaxId()+1;
            MessageBox.Show("Cliente creado");
            servicioCliente.PostCliente(nuevoCliente);
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarClientes());
        }
        private void Back()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarClientes());
        }
    }
}

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
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProyectoRefriPolar.ViewModel
{
    internal class ClientesVM : ObservableObject
    {
        private Clientes clienteSeleccionado;
        public Clientes ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }
        private ObservableCollection<Clientes> listaClientes;
        public ObservableCollection<Clientes> ListaClientes
        {
            get { return listaClientes; }
            set { SetProperty(ref listaClientes, value); }
        }
        private ClientesService clientesService;
        private NavegacionService navegacionService;
        public RelayCommand EliminarCommand { get; }
        public RelayCommand CrearClienteCommand { get;  }
        public RelayCommand ConsultaClienteCommand { get; }
        public ClientesVM()
        {
            navegacionService = new NavegacionService();
            clientesService = new ClientesService();
            listaClientes = clientesService.GetClientes();
            EliminarCommand = new RelayCommand(Eliminar);
            CrearClienteCommand = new RelayCommand(Crear);
            ConsultaClienteCommand = new RelayCommand(Consulta);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<ClientesVM, ConsultaClienteMensaje>(this, (r, m) =>
            {
                m.Reply(ClienteSeleccionado.id);
            });
        }
        public void Consulta()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaCliente());
        }
        private void Crear()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearCliente());
        }
        private void Eliminar()
        {
            int id = ClienteSeleccionado.id;
            listaClientes.Remove(ClienteSeleccionado);
            clientesService.DeleteCliente(id);
        }
    }
}

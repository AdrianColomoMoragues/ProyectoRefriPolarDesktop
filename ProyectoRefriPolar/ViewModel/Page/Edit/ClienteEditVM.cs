using ProyectoRefriPolar.mensajeria;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace ProyectoRefriPolar.ViewModel.Page.Edit
{
    class ClienteEditVM : ObservableObject
    {
        private Clientes clienteSeleccionado;
        public Clientes ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }
        private ClientesService clienteService;
        private NavegacionService navegacionService;
        public RelayCommand EditCommand { get; }
        public RelayCommand BackCommand { get; }
        public ClienteEditVM()
        {
            navegacionService = new NavegacionService();
            clienteService = new ClientesService();
            clienteSeleccionado = clienteService.GetCliente(WeakReferenceMessenger.Default.Send<ConsultaClienteMensaje>());
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
        }
        public void Edit()
        {
            MessageBox.Show("ClienteActualizado");
            clienteService.PutCliente(ClienteSeleccionado);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<ClienteEditVM, ConsultaClienteMensaje>(this, (r, m) =>
            {
                m.Reply(ClienteSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaCliente());
        }
        private void Back()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<ClienteEditVM, ConsultaClienteMensaje>(this, (r, m) =>
            {
                m.Reply(ClienteSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaCliente());
        }
    }
}

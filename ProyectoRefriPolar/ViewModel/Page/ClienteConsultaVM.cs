using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ProyectoRefriPolar.mensajeria;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.ViewModel.Page
{
    class ClienteConsultaVM : ObservableObject
    {
        private Clientes clienteSeleccionado;
        public Clientes ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }
        private ObservableCollection<Encargos> listaEncargos;
        public ObservableCollection<Encargos> ListaEncargos
        {
            get { return listaEncargos; }
            set { SetProperty(ref listaEncargos, value); }
        }
        private NavegacionService navegacionService;
        private EncargosService encargosService;
        private ClientesService clientesService;
        public RelayCommand EditCommand { get; }
        public RelayCommand BackCommand { get; }
        public ClienteConsultaVM()
        {
            encargosService = new EncargosService();
            navegacionService = new NavegacionService();
            clientesService = new ClientesService();
            clienteSeleccionado = clientesService.GetCliente(WeakReferenceMessenger.Default.Send<ConsultaClienteMensaje>());
            listaEncargos = GetEncargos();
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
        }
        private void Edit()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<ClienteConsultaVM, ConsultaClienteMensaje>(this, (r, m) =>
            {
                m.Reply(ClienteSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.EditarCliente());
        }
        private ObservableCollection<Encargos> GetEncargos()
        {
            ObservableCollection<Encargos> listaEncargos = new ObservableCollection<Encargos>();
            foreach (Encargos encargo in encargosService.GetEncargos())
            {
                if(encargo.idCliente.id == clienteSeleccionado.id)
                {
                    listaEncargos.Add(encargo);
                }
            }
            return listaEncargos;
        }
        private void Back()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarClientes());
        }
    }
}

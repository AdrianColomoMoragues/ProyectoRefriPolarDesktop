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
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProyectoRefriPolar.ViewModel
{
    internal class EncargosVM : ObservableObject
    {
        private Encargos encargoSeleccionado;
        public Encargos EncargoSeleccionado
        {
            get { return encargoSeleccionado; }
            set { SetProperty(ref encargoSeleccionado, value); }
        }
        private ObservableCollection<Encargos> listaEncargos;
        public ObservableCollection<Encargos> ListaEncargos
        {
            get { return listaEncargos; }
            set { SetProperty(ref listaEncargos, value); }
        }
        private EncargosService encargosService;
        private NavegacionService navegacionService;
        public RelayCommand EliminarCommand { get; }
        public RelayCommand CrearEncargoCommand { get; }
        public RelayCommand ConsultaEncargoCommand { get; }
        public EncargosVM()
        {
            navegacionService = new NavegacionService();
            encargosService = new EncargosService();
            listaEncargos = encargosService.GetEncargos();
            EliminarCommand = new RelayCommand(Eliminar);
            CrearEncargoCommand = new RelayCommand(Crear);
            ConsultaEncargoCommand = new RelayCommand(Consulta);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargosVM, ConsultaEncargoMensaje>(this, (r, m) =>
            {
                m.Reply(EncargoSeleccionado.id);
            });
        }
        public void Consulta()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEncargo());
        }
        private void Crear()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CrearEncargo());
        }
        private void Eliminar()
        {
            int id = EncargoSeleccionado.id;
            listaEncargos.Remove(EncargoSeleccionado);
            encargosService.DeleteEncargo(id);
        }
    }
}

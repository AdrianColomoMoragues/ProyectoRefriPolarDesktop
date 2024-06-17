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
namespace ProyectoRefriPolar.ViewModel.Page
{
    class EncargoConsultaVM : ObservableObject
    {
        private Encargos encargoSeleccionado;
        public Encargos EncargoSeleccionado
        {
            get { return encargoSeleccionado; }
            set { SetProperty(ref encargoSeleccionado, value); }
        }
        private NavegacionService navegacionService;
        private EncargosService encargosService;
        public RelayCommand EditCommand { get; }
        public RelayCommand BackCommand { get; }
        public EncargoConsultaVM()
        {
            navegacionService = new NavegacionService();
            encargosService = new EncargosService();
            encargoSeleccionado = encargosService.GetEncargo(WeakReferenceMessenger.Default.Send<ConsultaEncargoMensaje>());
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
        }
        private void Edit()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargoConsultaVM, ConsultaEncargoMensaje>(this, (r, m) =>
            {
                m.Reply(EncargoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.EditarEncargo());
        }
        private void Back()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEncargos());
        }
    }
}

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
    class EmpleadoConsultaVM : ObservableObject
    {
        private Empleados empleadoSeleccionado;
        public Empleados EmpleadoSeleccionado
        {
            get { return empleadoSeleccionado; }
            set { SetProperty(ref empleadoSeleccionado, value); }
        }
        private Dictionary<Encargos, string> encargosEmpleado;
        public Dictionary<Encargos, string> EncargosEmpleado
        {
            get { return encargosEmpleado; }
            set { SetProperty(ref encargosEmpleado, value); }
        }
        private NavegacionService navegacionService;
        private EncargosService encargosService;
        private EmpleadosService empleadosService;
        public RelayCommand EditCommand { get; }
        public RelayCommand BackCommand { get; }
        public EmpleadoConsultaVM()
        {
            encargosEmpleado = new Dictionary<Encargos, string>();
            encargosService = new EncargosService();
            empleadosService = new EmpleadosService();
            navegacionService = new NavegacionService();
            empleadoSeleccionado = empleadosService.GetEmpleado(WeakReferenceMessenger.Default.Send<ConsultaEmpleadoMensaje>());
            SetEncargos();
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
        }
        private void Edit()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EmpleadoConsultaVM, ConsultaEmpleadoMensaje>(this, (r, m) =>
            {
                m.Reply(EmpleadoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.EditarEmpleado());
        }
        private void SetEncargos()
        {
            ObservableCollection<Encargos> listaEncargos = encargosService.GetEncargos();
            foreach (Encargos encargo in listaEncargos)
            {
                if (encargo.idEncargado.id == EmpleadoSeleccionado.id)
                {
                    EncargosEmpleado.Add(encargo, "Encargado");
                }
                foreach (Empleados empleado in encargo.empleadosCollection)
                {
                    if(empleado.id == empleadoSeleccionado.id)
                    {
                        EncargosEmpleado.Add(encargo, "Empleado");
                    }
                }
            }
        }
        private void Back()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEmpleados());
        }
    }
}

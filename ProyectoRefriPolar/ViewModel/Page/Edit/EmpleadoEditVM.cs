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

namespace ProyectoRefriPolar.ViewModel.Page.Edit
{
    class EmpleadoEditVM : ObservableObject
    {
        private Empleados empleadoSeleccionado;
        public Empleados EmpleadoSeleccionado
        {
            get { return empleadoSeleccionado; }
            set { SetProperty(ref empleadoSeleccionado, value); }
        }
        private ObservableCollection<CategoriaProfesional> listaCategoriasProfesionales;
        public ObservableCollection<CategoriaProfesional> ListaCategoriasProfesionales
        {
            get { return listaCategoriasProfesionales; }
            set { SetProperty(ref listaCategoriasProfesionales, value); }
        }
        private ObservableCollection<int> listaAntiguedad;
        public ObservableCollection<int> ListaAntiguedad
        {
            get { return listaAntiguedad; }
            set { SetProperty(ref listaAntiguedad, value); }
        }
        private AzureService azureService;
        private EmpleadosService empleadosService;
        private EncargosService encargosService;
        private CategoriaProfesionalService servicioCategoria;
        private NavegacionService navegacionService;
        public RelayCommand EditCommand { get; }
        public RelayCommand BackCommand { get; }
        public EmpleadoEditVM()
        {
            azureService = new AzureService();
            navegacionService = new NavegacionService();
            empleadosService = new EmpleadosService();
            encargosService = new EncargosService();
            servicioCategoria = new CategoriaProfesionalService();
            empleadoSeleccionado = empleadosService.GetEmpleado(WeakReferenceMessenger.Default.Send<ConsultaEmpleadoMensaje>());
            listaCategoriasProfesionales = servicioCategoria.GetCategoriasProfesionales();
            listaAntiguedad = GetAntiguedad();
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
        }
        private void Edit()
        {
            Encargos encargoEmpleado = null;
            ObservableCollection<Encargos> encargos = encargosService.GetEncargos();
            foreach (Encargos encargo in encargos)
            {
                foreach (Empleados empleado in encargo.empleadosCollection)
                {
                    if(empleado.id == empleadoSeleccionado.id)
                    {
                        encargoEmpleado = encargo;
                    }
                }
            }
            MessageBox.Show("Empleado editado");
            if(EmpleadoSeleccionado.imagen != null)
            {
                EmpleadoSeleccionado.imagen = azureService.guarda(EmpleadoSeleccionado.imagen);
            }
            EmpleadoSeleccionado.apellido2 = EmpleadoSeleccionado.apellido1.Split(" ")[1];
            EmpleadoSeleccionado.apellido1 = EmpleadoSeleccionado.apellido1.Split(" ")[0];
            empleadosService.PutEmpleado(EmpleadoSeleccionado);
            if (encargoEmpleado != null)
            {
                encargosService.PutEncargo(encargoEmpleado);
            }
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EmpleadoEditVM, ConsultaEmpleadoMensaje>(this, (r, m) =>
            {
                m.Reply(EmpleadoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEmpleado());
        }
        private ObservableCollection<int> GetAntiguedad()
        {
            ObservableCollection<int> list = new ObservableCollection<int>();
            for (int i = 0; i <= 20; i++)
            {
                list.Add(i);
            }
            return list;
        }
        public string AbrirDialogo()
        {
            return navegacionService.btnOpenFiles_Click();
        }
        private void Back()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EmpleadoEditVM, ConsultaEmpleadoMensaje>(this, (r, m) =>
            {
                m.Reply(EmpleadoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEmpleado());
        }
    }
}

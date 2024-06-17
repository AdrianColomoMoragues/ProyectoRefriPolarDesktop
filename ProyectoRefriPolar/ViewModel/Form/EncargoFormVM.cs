using ProyectoRefriPolar.mensajeria;
using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ProyectoRefriPolar.ViewModel.Form
{
    internal class EncargoFormVM : ObservableObject
    {
        private Encargos nuevoEncargo;
        public Encargos NuevoEncargo
        {
            get { return nuevoEncargo; }
            set { SetProperty(ref nuevoEncargo, value); }
        }
        private ObservableCollection<Clientes> listaClientes;
        public ObservableCollection<Clientes> ListaClientes
        {
            get { return listaClientes; }
            set { SetProperty(ref listaClientes, value); }
        }
        private ObservableCollection<Empleados> listaEmpleados;
        public ObservableCollection<Empleados> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { SetProperty(ref listaEmpleados, value); }
        }
        private ObservableCollection<Empleados> listaEquipo;
        public ObservableCollection<Empleados> ListaEquipo
        {
            get { return listaEmpleados; }
            set { SetProperty(ref listaEquipo, value); }
        }
        private ObservableCollection<int> listaPrioridad;
        public ObservableCollection<int> ListaPrioridad
        {
            get { return listaPrioridad; }
            set { SetProperty(ref listaPrioridad, value); }
        }
        private ObservableCollection<string> listaTipos;
        public ObservableCollection<string> ListaTipos
        {
            get { return listaTipos; }
            set { SetProperty(ref listaTipos, value); }
        }
        private Empleados empleadoEncargoSeleccionado;
        public Empleados EmpleadoEncargoSeleccionado
        {
            get { return empleadoEncargoSeleccionado; }
            set { SetProperty(ref empleadoEncargoSeleccionado, value); }
        }
        private EncargosService serviceEncargo;
        private EmpleadosService serviceEmpleado;
        private ClientesService serviceClientes;
        private NavegacionService navegacionService;
        public RelayCommand CrearEncargoCommand { get; }
        public RelayCommand AbrirDialgoCommand { get; }
        public RelayCommand DeleteEmpleadoCommand { get; }
        public RelayCommand BackCommand { get; }
        public EncargoFormVM()
        {
            navegacionService = new NavegacionService();
            nuevoEncargo = new Encargos();
            nuevoEncargo.empleadosCollection = new ObservableCollection<Empleados>();
            empleadoEncargoSeleccionado = new Empleados();
            serviceEncargo = new EncargosService();
            serviceEmpleado = new EmpleadosService();
            serviceClientes = new ClientesService();
            listaClientes = serviceClientes.GetClientes();
            listaEmpleados = GetEncargados();
            listaPrioridad = GetPrioridad();
            listaTipos = GetTipos();
            CrearEncargoCommand = new RelayCommand(CrearEncargo);
            AbrirDialgoCommand = new RelayCommand(AbrirDialogo);
            DeleteEmpleadoCommand = new RelayCommand(EliminarEmpleado);
            BackCommand = new RelayCommand(Back);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargoFormVM, DialogoEncargoMensage>(this, (r, m) =>
            {
                m.Reply(NuevoEncargo);
            });
            WeakReferenceMessenger.Default.Register<EmpleadoEncargoMensaje>(this, (r, m) =>
            {
                NuevoEncargo.empleadosCollection.Add(m.Value);
            });
        }
        private void CrearEncargo()
        {
            NuevoEncargo.id = serviceEncargo.GetMaxId() + 1;
            serviceEncargo.PostEncargo(NuevoEncargo);
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEncargos());
        }
        private ObservableCollection<string> GetTipos()
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();
            lista.Add("Obra");
            lista.Add("Reparacion");
            return lista;
        }
        public ObservableCollection<Empleados> GetEncargados()
        {
            ObservableCollection<Empleados> listaEncargados = new ObservableCollection<Empleados>();
            foreach (Empleados empleado in serviceEmpleado.GetEmpleados())
            {
                listaEncargados.Add(empleado);
                if (empleado.codcategoriaProfesional.descripcion.ToLower() == "peon")
                {
                    listaEncargados.Remove(empleado);
                }
                else if (NuevoEncargo.tipo != null)
                {
                    string tipoEncargo = NuevoEncargo.tipo.ToLower();
                    if (tipoEncargo == empleado.codcategoriaProfesional.encargo.ToLower())
                    {
                        listaEncargados.Remove(empleado);
                    }
                }
            }

            return listaEncargados;
        }
        private ObservableCollection<int> GetPrioridad()
        {
            ObservableCollection<int> list = new ObservableCollection<int>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            return list;
        }
        private void EliminarEmpleado()
        {
            NuevoEncargo.empleadosCollection.Remove(EmpleadoEncargoSeleccionado);
        }
        private void AbrirDialogo()
        {
            navegacionService.AbrirDialogo();
        }
        private void Back()
        {
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEncargos());
        }
    }
}

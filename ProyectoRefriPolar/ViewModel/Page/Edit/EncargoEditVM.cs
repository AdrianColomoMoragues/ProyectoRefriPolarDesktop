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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRefriPolar.ViewModel.Page.Edit
{
    class EncargoEditVM : ObservableObject
    {
        private Encargos encargoSeleccionado;
        public Encargos EncargoSeleccionado
        {
            get { return encargoSeleccionado; }
            set { SetProperty(ref encargoSeleccionado, value); }
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
        private NavegacionService navegacionService;
        private EmpleadosService serviceEmpleado;
        private ClientesService serviceClientes;
        private EncargosService encargosService;
        public RelayCommand EditCommand { get; }
        public RelayCommand AbrirDialogoCommand { get; }
        public RelayCommand DeleteEmpleadoCommand { get; }
        public RelayCommand BackCommand { get; }
        public EncargoEditVM()
        {
            navegacionService = new NavegacionService();
            encargosService = new EncargosService();
            serviceEmpleado = new EmpleadosService();
            serviceClientes = new ClientesService();
            empleadoEncargoSeleccionado = new Empleados();
            listaClientes = serviceClientes.GetClientes();
            encargoSeleccionado = encargosService.GetEncargo(WeakReferenceMessenger.Default.Send<ConsultaEncargoMensaje>());
            listaEmpleados = GetEncargados();
            listaPrioridad = GetPrioridad();
            listaTipos = GetTipos();
            DeleteEmpleadoCommand = new RelayCommand(EliminarEmpleado);
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
            AbrirDialogoCommand = new RelayCommand(AbrirDialogo);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargoEditVM, DialogoEncargoMensage>(this, (r, m) =>
            {
                m.Reply(EncargoSeleccionado);
            });
            WeakReferenceMessenger.Default.Register<EmpleadoEncargoMensaje>(this, (r, m) =>
            {
                EncargoSeleccionado.empleadosCollection.Add(m.Value);
            });
        }
        private ObservableCollection<string> GetTipos()
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();
            lista.Add("Obra");
            lista.Add("Reparacion");
            return lista;
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
            EncargoSeleccionado.empleadosCollection.Remove(EmpleadoEncargoSeleccionado);
        }
        private void AbrirDialogo()
        {
            navegacionService.AbrirDialogo();
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
                else if (EncargoSeleccionado.tipo != null)
                {
                    string tipoEncargo = EncargoSeleccionado.tipo.ToLower();
                    if (tipoEncargo == empleado.codcategoriaProfesional.encargo.ToLower())
                    {
                        listaEncargados.Remove(empleado);
                    }
                }
            }
            return listaEncargados;
        }
        private void Edit()
        {
            MessageBox.Show("Encargo editado");
            encargosService.PutEncargo(EncargoSeleccionado);
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargoEditVM, ConsultaEncargoMensaje>(this, (r, m) =>
            {
                m.Reply(EncargoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEncargo());
        }
        private void Back()
        {
            WeakReferenceMessenger.Default.Reset();
            WeakReferenceMessenger.Default.Register<EncargoEditVM, ConsultaEncargoMensaje>(this, (r, m) =>
            {
                m.Reply(EncargoSeleccionado.id);
            });
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.ConsultaEncargo());
        }
    }
}

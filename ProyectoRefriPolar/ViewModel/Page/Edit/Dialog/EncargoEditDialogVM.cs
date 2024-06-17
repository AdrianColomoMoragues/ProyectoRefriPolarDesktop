using CommunityToolkit.Mvvm.ComponentModel;
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

namespace ProyectoRefriPolar.ViewModel.Page.Edit.Dialog
{
    class EncargoEditDialogVM : ObservableObject
    {
        private Empleados empleadoSeleccionado;
        public Empleados EmpleadoSeleccionado
        {
            get { return empleadoSeleccionado; }
            set { SetProperty(ref empleadoSeleccionado, value); }
        }
        private Encargos encargoActual;
        public Encargos EncargoActual
        {
            get { return encargoActual; }
            set { SetProperty(ref encargoActual, value); }
        }

        private ObservableCollection<Empleados> listaEquipoEncargo;
        public ObservableCollection<Empleados> ListaEquipoEncargo
        {
            get { return listaEquipoEncargo; }
            set { SetProperty(ref listaEmpleados, value); }
        }
        private ObservableCollection<Empleados> listaEmpleados;
        public ObservableCollection<Empleados> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { SetProperty(ref listaEmpleados, value); }
        }
        private EmpleadosService empleadosService;
        private EncargosService encargosService;
        public EncargoEditDialogVM()
        {
            empleadosService = new EmpleadosService();
            encargosService = new EncargosService();
            encargoActual = WeakReferenceMessenger.Default.Send<DialogoEncargoMensage>();
            listaEquipoEncargo = encargoActual.empleadosCollection;
            listaEmpleados = GetEquipo();
        }
        private ObservableCollection<Empleados> GetEquipo()
        {
            int encargadoId = -1;
            if (encargoActual.idEncargado == null)
            {
                if(encargosService.GetEncargo(EncargoActual.id).idEncargado.id != null)
                {
                    encargadoId = encargosService.GetEncargo(EncargoActual.id).idEncargado.id;
                }
            }
            else
            {
                encargadoId = encargoActual.idEncargado.id;
            }
            ObservableCollection<Empleados> lista = new ObservableCollection<Empleados>();
            foreach (Empleados empleado in empleadosService.GetEmpleados())
            {

                if (empleado.id != encargadoId)
                {
                    if (empleado.codcategoriaProfesional.encargo.ToLower() == encargoActual.tipo.ToLower() || encargoActual.tipo == null)
                    {
                        lista.Add(empleado);
                        foreach (Empleados empleadoEquipos in listaEquipoEncargo)
                        {
                            if (empleado.id == empleadoEquipos.id)
                            {
                                lista.Remove(empleado);
                            }
                        }
                    }
                }
            }
            return lista;
        }
        public void Aceptar()
        {
            WeakReferenceMessenger.Default.Send(new EmpleadoEncargoMensaje(EmpleadoSeleccionado));
        }
    }
}

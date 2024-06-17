using ProyectoRefriPolar.ViewModel.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoRefriPolar.Model;
using ProyectoRefriPolar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ProyectoRefriPolar.ViewModel.Form
{
    internal class EmpleadoFormVM : ObservableObject
    {
        private Empleados nuevoEmpleado;
        public Empleados NuevoEmpleado
        {
            get { return nuevoEmpleado; }
            set { SetProperty(ref nuevoEmpleado, value); }
        }
        private ObservableCollection<CategoriaProfesional> listaCategoriasProfesionales;
        public ObservableCollection<CategoriaProfesional> ListaCategoriasProfesionales
        {
            get { return listaCategoriasProfesionales; }
            set { SetProperty(ref listaCategoriasProfesionales, value);  }
        }
        private ObservableCollection<int> listaAntiguedad;
        public ObservableCollection<int> ListaAntiguedad
        {
            get { return listaAntiguedad; }
            set { SetProperty(ref listaAntiguedad, value); }
        }
        private EmpleadosService serviceEmpleado;
        private CategoriaProfesionalService servicioCategoria;
        private NavegacionService navegacionService;
        public RelayCommand CrearEmpleadoCommand { get; }
        public RelayCommand BackCommand { get; }
        public EmpleadoFormVM()
        {
            navegacionService = new NavegacionService();
            nuevoEmpleado = new Empleados();
            servicioCategoria = new CategoriaProfesionalService();
            serviceEmpleado = new EmpleadosService();
            listaCategoriasProfesionales = servicioCategoria.GetCategoriasProfesionales();
            listaAntiguedad = GetAntiguedad();
            CrearEmpleadoCommand = new RelayCommand(CrearEmpleado);
            BackCommand = new RelayCommand(Back);
        }
        private void CrearEmpleado()
        {
            NuevoEmpleado.id = serviceEmpleado.GetMaxId() + 1;
            NuevoEmpleado.apellido2 = NuevoEmpleado.apellido1.Split(" ")[1];
            NuevoEmpleado.apellido1 = NuevoEmpleado.apellido1.Split(" ")[0];
            serviceEmpleado.PostEmpleado(nuevoEmpleado);
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEmpleados());
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
            EventAggregator.Instance.PublishChangeUserControl(navegacionService.CargarEmpleados());
        }
    }
}

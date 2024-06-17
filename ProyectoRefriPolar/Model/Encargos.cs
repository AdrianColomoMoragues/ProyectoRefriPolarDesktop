using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.Model
{
    class Encargos : ObservableObject
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }
        private bool _terminada;
        public bool terminada
        {
            get { return _terminada; }
            set { SetProperty(ref _terminada, value); }
        }
        private Empleados _idEncargado;
        public Empleados idEncargado
        {
            get { return _idEncargado; }
            set { SetProperty(ref _idEncargado, value); }
        }
        private Clientes _idCliente;
        public Clientes idCliente
        {
            get { return _idCliente; }
            set { SetProperty(ref _idCliente, value); }
        }
        private ObservableCollection<Empleados> _empleadosCollection;
        public ObservableCollection<Empleados> empleadosCollection
        {
            get { return _empleadosCollection; }
            set { SetProperty(ref _empleadosCollection, value); }
        }
        private string _tipo;
        public string tipo
        {
            get { return _tipo; }
            set { SetProperty(ref _tipo, value); }
        }
        private int _prioridad;
        public int prioridad
        {
            get { return _prioridad;  }
            set { SetProperty(ref _prioridad, value); }
        }
        private int? _porcentaje;
        public int? porcentaje
        {
            get { return _porcentaje; }
            set { SetProperty(ref _porcentaje, value); }
        }
        public Encargos()
        {

        }
        public Encargos(int id, string nombre, bool terminada, Empleados idEncargado, Clientes idCliente, ObservableCollection<Empleados> empleadosCollection, string tipo, int prioridad, int porcentaje)
        {
            _id = id;
            _nombre = nombre;
            _terminada = terminada;
            _idEncargado = idEncargado;
            _idCliente = idCliente;
            _empleadosCollection = empleadosCollection;
            _tipo = tipo;
            _prioridad = prioridad;
            _porcentaje = porcentaje;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

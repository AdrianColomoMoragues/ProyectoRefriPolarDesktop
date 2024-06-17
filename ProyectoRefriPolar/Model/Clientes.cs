using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRefriPolar.Model
{
    class Clientes : ObservableObject
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
        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { SetProperty(ref _telefono, value); }
        }
        private string _correo;
        public string correo
        {
            get { return _correo; }
            set { SetProperty(ref _correo, value); }
        }
        private string _localidad;
        public string localidad
        {
            get { return _localidad; }
            set { SetProperty(ref _localidad, value); }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { SetProperty(ref _direccion, value); }
        }
        private string _caracteristicas;
        public string caracteristicas
        {
            get { return _caracteristicas; }
            set { SetProperty(ref _caracteristicas, value); }
        }
        public Clientes()
        {

        }
        public Clientes(int id, string nombre, string telefono, string correo, string localidad, string direccion, string caracteristicas)
        {
            _id = id;
            _nombre = nombre;
            _telefono = telefono;
            _correo = correo;
            _localidad = localidad;
            _direccion = direccion;
            _caracteristicas = caracteristicas;
        }
    }
}

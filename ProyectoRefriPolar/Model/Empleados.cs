using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.Model
{
    class Empleados : ObservableObject
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
        private string _apellido1;
        public string apellido1
        {
            get { return _apellido1; }
            set { SetProperty(ref _apellido1, value); }
        }
        private string _apellido2;
        public string apellido2
        {
            get { return _apellido2; }
            set { SetProperty(ref _apellido2, value); }
        }
        private CategoriaProfesional _codcategoriaProfesional;
        public CategoriaProfesional codcategoriaProfesional
        {
            get { return _codcategoriaProfesional; }
            set { SetProperty(ref _codcategoriaProfesional, value); }
        }
        private int _antiguedad;
        public int antiguedad
        {
            get { return _antiguedad; }
            set { SetProperty(ref _antiguedad, value); }
        }
        private bool _reconocimientoMedico;
        public bool reconocimientoMedico
        {
            get { return _reconocimientoMedico; }
            set { SetProperty(ref _reconocimientoMedico, value); }
        }
        private string _imagen;
        public string imagen
        {
            get { return _imagen; }
            set { SetProperty(ref _imagen, value); }
        }
        private string _mail;
        public string mail
        {
            get { return _mail; }
            set { SetProperty(ref _mail, value);  }
        }
        private string _ciudad;
        public string ciudad
        {
            get { return _ciudad; }
            set { SetProperty(ref _ciudad, value); }
        }
        private string _provincia;
        public string provincia
        {
            get { return _provincia; }
            set { SetProperty(ref _provincia, value); }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { SetProperty(ref _direccion, value); }
        }
        private int? _cp;
        public int? cp
        {
            get { return _cp; }
            set { SetProperty(ref _cp, value); }
        }
        private float? _salario;
        public float? salario
        {
            get { return _salario; }
            set { SetProperty(ref _salario, value); }
        }
        private int? _telefono;
        public int? telefono
        {
            get { return _telefono; }
            set { SetProperty(ref _telefono, value); }
        }
        public Empleados()
        {

        }
        public Empleados(int id, string nombre, string apellido1, string apellido2, CategoriaProfesional codcategoriaProfesional, int antiguedad, bool reconocimientoMedico, string imagen, float salario, string ciudad, string provincia, int cp, string direccion, string mail, int telefono)
        {
            _id = id;
            _nombre = nombre;
            _apellido1 = apellido1;
            _apellido2 = apellido2;
            _codcategoriaProfesional = codcategoriaProfesional;
            _antiguedad = antiguedad;
            _reconocimientoMedico = reconocimientoMedico;
            _imagen = imagen;
            _salario = salario;
            _ciudad = ciudad;
            _cp = cp;
            _telefono = telefono;
            _direccion = direccion;
            _mail = mail;
        }
    }
}

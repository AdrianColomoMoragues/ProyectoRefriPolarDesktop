using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.Model
{
    class CategoriaProfesional : ObservableObject
    {
        private string _codigo;
        public string codigo
        {
            get { return _codigo; }
            set { SetProperty(ref _codigo, value);  }
        }
        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }
        private string _encargo;
        public string encargo
        {
            get { return _encargo; }
            set { SetProperty(ref _encargo, value); }
        }
        public CategoriaProfesional()
        {

        }
        public CategoriaProfesional(string codigo, string descripcion, string encargo)
        {
            _codigo = codigo;
            _descripcion = descripcion;
            _encargo = encargo;
        }
    }
}

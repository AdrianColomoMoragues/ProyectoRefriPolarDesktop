using ProyectoRefriPolar.View;
using ProyectoRefriPolar.View.Form;
using ProyectoRefriPolar.View.Page;
using ProyectoRefriPolar.View.Page.Edit;
using ProyectoRefriPolar.View.Page.Edit.Dialog;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.Services
{
    class NavegacionService
    {
        internal UserControl CargarEmpleados()
        {
            return new Empleados();
        }
        internal UserControl CargarEncargos()
        {
            return new Encargos();
        }
        internal UserControl CargarClientes()
        {
            return new Clientes();
        }
        internal UserControl CargarInicio()
        {
            return new Inicio();
        }
        internal UserControl CrearCliente()
        {
            return new ClienteForm();
        }
        internal UserControl CrearEncargo()
        {
            return new EncargoForm();
        }
        internal UserControl CrearEmpleado()
        {
            return new EmpleadoForm();
        }
        internal UserControl ConsultaEmpleado()
        {
            return new EmpleadoConsulta();
        }
        internal UserControl ConsultaEncargo()
        {
            return new EncargoConsulta();
        }
        internal UserControl ConsultaCliente()
        {
            return new ClienteConsulta();
        }
        internal UserControl EditarEmpleado()
        {
            return new EmpleadoEdit();
        }
        internal UserControl EditarCliente()
        {
            return new ClienteEdit();
        }
        internal UserControl EditarEncargo()
        {
            return new EncargoEdit();
        }

        internal void AbrirDialogo()
        {
            EncargoEditDialog encargoEditDialog = new EncargoEditDialog();
            encargoEditDialog.ShowDialog();
        }
        public string btnOpenFiles_Click()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
    }
}

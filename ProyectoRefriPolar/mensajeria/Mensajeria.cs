using CommunityToolkit.Mvvm.Messaging.Messages;
using ProyectoRefriPolar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.mensajeria
{
    class ConsultaClienteMensaje : RequestMessage<int> { }
    class ConsultaEmpleadoMensaje : RequestMessage<int> { }
    class ConsultaEncargoMensaje : RequestMessage<int> { }
    class EmpleadoEncargoMensaje : ValueChangedMessage<Empleados>
    {
        public EmpleadoEncargoMensaje(Empleados nuevoEmpleado) : base(nuevoEmpleado) { }
    }
    class DialogoEncargoMensage: RequestMessage<Encargos> { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.ViewModel.Event
{
    public class ChangeWindowNameEvent
    {
        public String WindowName { get; set; }

        public ChangeWindowNameEvent(String name)
        {
            WindowName = name;
        }
    }
}

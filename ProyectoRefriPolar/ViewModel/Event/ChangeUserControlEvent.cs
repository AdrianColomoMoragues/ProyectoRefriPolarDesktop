using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.ViewModel.Event
{
    public class ChangeUserControlEvent
    {
        public UserControl NewUserControl { get; set; }

        public ChangeUserControlEvent(UserControl newUserControl)
        {
            NewUserControl = newUserControl;
        }
    }
}

using ProyectoRefriPolar.ViewModel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRefriPolar.ViewModel.Event
{
    public class EventAggregator
    {
        private static readonly EventAggregator _instance = new EventAggregator();
        private static readonly EventAggregator _change = new EventAggregator();

        public static EventAggregator Instance => _instance;
        public static EventAggregator Change => _change;

        public event EventHandler<ChangeUserControlEvent> ChangeUserControlRequested;
        public event EventHandler<ChangeWindowNameEvent> ChangeWindowNameRequested;

        public void PublishChangeUserControl(UserControl newUserControl)
        {
            ChangeUserControlRequested?.Invoke(this, new ChangeUserControlEvent(newUserControl));
        }
        public void PublishChangeWindowNameEvent(string name)
        {
            ChangeWindowNameRequested?.Invoke(this, new ChangeWindowNameEvent(name));
        }
    }

}

using ProyectoRefriPolar.ViewModel.Page.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoRefriPolar.View.Page.Edit
{
    /// <summary>
    /// Lógica de interacción para ClienteEdit.xaml
    /// </summary>
    public partial class ClienteEdit : UserControl
    {
        ClienteEditVM vm;
        public ClienteEdit()
        {
            vm = new ClienteEditVM();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}

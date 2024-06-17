using ProyectoRefriPolar.ViewModel.Page;
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

namespace ProyectoRefriPolar.View.Page
{
    /// <summary>
    /// Lógica de interacción para EncargoConsulta.xaml
    /// </summary>
    public partial class EncargoConsulta : UserControl
    {
        EncargoConsultaVM vm;
        public EncargoConsulta()
        {
            vm = new EncargoConsultaVM();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}

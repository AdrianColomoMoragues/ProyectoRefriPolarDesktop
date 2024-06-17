using ProyectoRefriPolar.ViewModel.Page.Edit.Dialog;
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
using System.Windows.Shapes;

namespace ProyectoRefriPolar.View.Page.Edit.Dialog
{
    /// <summary>
    /// Lógica de interacción para EncargoEditDialog.xaml
    /// </summary>
    public partial class EncargoEditDialog : Window
    {
        EncargoEditDialogVM vm;
        public EncargoEditDialog()
        {
            vm = new EncargoEditDialogVM();
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Aceptar();
            DialogResult = true;
        }
    }
}

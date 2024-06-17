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
    /// Lógica de interacción para EmpleadoConsulta.xaml
    /// </summary>
    public partial class EmpleadoConsulta : UserControl
    {
        EmpleadoConsultaVM vm;
        public EmpleadoConsulta()
        {
            vm = new EmpleadoConsultaVM();
            InitializeComponent();
            this.DataContext = vm;
            SetTextUpper();
            SetTablaEncargos();
        }
        public void SetTextUpper()
        {
            string texto = vm.EmpleadoSeleccionado.codcategoriaProfesional.encargo;
            if (!string.IsNullOrEmpty(texto))
            {
                texto = char.ToUpper(texto[0]) + texto.Substring(1);
            }
            encargoText.Text = texto;
        }
        public void SetTablaEncargos()
        {
            if (vm.EncargosEmpleado.Count > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    tableEncargosGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (int i = 0; i < vm.EncargosEmpleado.Count + 1; i++)
                {
                    tableEncargosGrid.RowDefinitions.Add(new RowDefinition());
                    if (i == 0)
                    {
                        //Defincion de campos
                        //Campo Asignado
                        Border borderAsigned = new Border();
                        borderAsigned.BorderBrush = Brushes.White;
                        borderAsigned.BorderThickness = new Thickness(1, 1, 0, 1);
                        borderAsigned.CornerRadius = new CornerRadius(2,0,0,0);
                        borderAsigned.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#073346"));
                        TextBlock asigned = new TextBlock();
                        asigned.Text = "Asignado";
                        asigned.HorizontalAlignment = HorizontalAlignment.Center;
                        asigned.Margin = new Thickness(5);
                        borderAsigned.Child = asigned;
                        Grid.SetRow(borderAsigned, 0);
                        Grid.SetColumn(borderAsigned, 0);
                        tableEncargosGrid.Children.Add(borderAsigned);
                        //Campo Posicion
                        Border borderPosition = new Border();
                        borderPosition.BorderBrush = Brushes.White;
                        borderPosition.BorderThickness = new Thickness(1, 1, 0, 1);
                        borderPosition.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#073346"));
                        TextBlock position = new TextBlock();
                        position.Text = "Puesto";
                        position.HorizontalAlignment = HorizontalAlignment.Center;
                        position.Margin = new Thickness(5);
                        borderPosition.Child = position;
                        Grid.SetRow(borderPosition, 0);
                        Grid.SetColumn(borderPosition, 1);
                        tableEncargosGrid.Children.Add(borderPosition);
                        //Campo Prioridad
                        Border borderPriority = new Border();
                        borderPriority.BorderBrush = Brushes.White;
                        borderPriority.BorderThickness = new Thickness(1, 1, 0, 1);
                        borderPriority.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#073346"));
                        TextBlock priority = new TextBlock();
                        priority.Text = "Prioridad";
                        priority.HorizontalAlignment = HorizontalAlignment.Center;
                        priority.Margin = new Thickness(5);
                        borderPriority.Child = priority;
                        Grid.SetRow(borderPriority, 0);
                        Grid.SetColumn(borderPriority, 2);
                        tableEncargosGrid.Children.Add(borderPriority);
                        //Campo Status
                        Border borderStatus = new Border();
                        borderStatus.BorderBrush = Brushes.White;
                        borderStatus.BorderThickness = new Thickness(1, 1, 1, 1);
                        borderStatus.CornerRadius = new CornerRadius(0, 2, 0, 0);
                        borderStatus.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#073346"));
                        TextBlock status = new TextBlock();
                        status.Text = "Estado";
                        status.HorizontalAlignment = HorizontalAlignment.Center;
                        status.Margin = new Thickness(5);
                        borderStatus.Child = status;
                        Grid.SetRow(borderStatus, 0);
                        Grid.SetColumn(borderStatus, 3);
                        tableEncargosGrid.Children.Add(borderStatus);
                    }
                    else
                    {
                        Rectangle rectangulo = new Rectangle();
                        rectangulo.Fill = Brushes.LightBlue;
                        Grid.SetRow(rectangulo, i);
                        Grid.SetColumn(rectangulo, 0);
                        Grid.SetColumnSpan(rectangulo, 4);
                        tableEncargosGrid.Children.Add(rectangulo);
                        //Definicion de valores campos
                        Model.Encargos encargo = vm.EncargosEmpleado.ElementAt(i - 1).Key;
                        string position = vm.EncargosEmpleado.ElementAt(i - 1).Value;
                        //Nombre Encargo
                        Border borderEncargo = new Border();
                        borderEncargo.Height = 50;
                        borderEncargo.BorderBrush = Brushes.White;
                        borderEncargo.BorderThickness = new Thickness(1, 0, 0, 1);
                        TextBlock encargoNombreText = new TextBlock();
                        encargoNombreText.Text = encargo.nombre;
                        encargoNombreText.VerticalAlignment = VerticalAlignment.Center;
                        encargoNombreText.Margin = new Thickness(5);
                        borderEncargo.Child = encargoNombreText;
                        Grid.SetRow(borderEncargo, i);
                        Grid.SetColumn(borderEncargo, 0);
                        tableEncargosGrid.Children.Add(borderEncargo);
                        //Posicion
                        Border borderPosition = new Border();
                        borderPosition.BorderBrush = Brushes.White;
                        borderPosition.BorderThickness = new Thickness(1, 0, 0, 1);
                        TextBlock encargoPosicionText = new TextBlock();
                        encargoPosicionText.Text = position;
                        encargoPosicionText.VerticalAlignment = VerticalAlignment.Center;
                        encargoPosicionText.Margin = new Thickness(5);
                        borderPosition.Child = encargoPosicionText;
                        Grid.SetRow(borderPosition, i);
                        Grid.SetColumn(borderPosition, 1);
                        tableEncargosGrid.Children.Add(borderPosition);
                        //Prioridad
                        Border borderPrioridad = new Border();
                        borderPrioridad.BorderBrush = Brushes.White;
                        borderPrioridad.BorderThickness = new Thickness(1, 0, 0, 1);
                        Border encargoPrioridadBorder = new Border();
                        encargoPrioridadBorder.Margin = new Thickness(5);
                        encargoPrioridadBorder.CornerRadius = new CornerRadius(125);
                        encargoPrioridadBorder.Width = 15;
                        encargoPrioridadBorder.Height = 15;
                        switch (encargo.prioridad)
                        {
                            case 1:
                                encargoPrioridadBorder.Background = Brushes.Green;
                                break;
                            case 2:
                                encargoPrioridadBorder.Background = Brushes.Yellow;
                                break;
                            case 3:
                                encargoPrioridadBorder.Background = Brushes.DarkRed;
                                break;
                        }
                        borderPrioridad.Child = encargoPrioridadBorder;
                        Grid.SetRow(borderPrioridad, i);
                        Grid.SetColumn(borderPrioridad, 2);
                        tableEncargosGrid.Children.Add(borderPrioridad);
                        //Status
                        Border borderStatus = new Border();
                        borderStatus.BorderBrush = Brushes.White;
                        borderStatus.BorderThickness = new Thickness(1, 0, 1, 1);
                        ProgressBar encargoStatusProgressBar = new ProgressBar();
                        encargoStatusProgressBar.Minimum = 0;
                        encargoStatusProgressBar.Maximum = 100;
                        encargoStatusProgressBar.Height = 20;
                        encargoStatusProgressBar.Width = 150;
                        encargoStatusProgressBar.Value = (double)encargo.porcentaje;
                        encargoStatusProgressBar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#073346"));
                        encargoStatusProgressBar.Background = Brushes.AliceBlue;
                        encargoStatusProgressBar.HorizontalAlignment = HorizontalAlignment.Center;
                        borderStatus.Child = encargoStatusProgressBar;
                        Grid.SetRow(borderStatus, i);
                        Grid.SetColumn(borderStatus, 3);
                        tableEncargosGrid.Children.Add(borderStatus);
                    }
                }
            }
        }
    }
}

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
using System.Diagnostics;

namespace Quiosco
{
    /// <summary>
    /// Lógica de interacción para Detalle.xaml
    /// </summary>
    public partial class Detalle : Page
    {
        //private string contraseniaRecibida;
        private string receivedPassword;
        public Detalle(string contrasenia)
        {
            InitializeComponent();
            AgregarFilasDinamicamente();
            receivedPassword = contrasenia;

            //MessageBox.Show("Contraseña recibida: " + receivedPassword);

            // Asigna la lista de datos al DataGrid
            //MiDataGridBoletaje.ItemsSource = boletaje;
        }
        private void AgregarFilasDinamicamente()
        {
            // Paso 1: Agregar nuevas filas después de Row 1 (antes de Row 2)
            int filaInsertar = 2; // La posición en la que se insertarán las nuevas filas

            // Agregar dos nuevas filas para los datos dinámicos
            Test.RowDefinitions.Insert(filaInsertar, new RowDefinition { Height = GridLength.Auto });
            Test.RowDefinitions.Insert(filaInsertar + 1, new RowDefinition { Height = GridLength.Auto });

            // Paso 2: Ajustar los elementos que ya existen para que se desplacen hacia abajo
            foreach (UIElement child in Test.Children)
            {
                int currentRow = Grid.GetRow(child);
                if (currentRow >= filaInsertar)
                {
                    // Desplazar hacia abajo los elementos que están en filaInsertar o mayor
                    Grid.SetRow(child, currentRow + 2);
                }
            }

            // Paso 3: Agregar los TextBlock en las filas recién insertadas

            // Primera fila dinámica
            var textBlockTarifa1 = new TextBlock
            {
                Text = "$11.00",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003A70")),
                Foreground = Brushes.White,
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockTarifa1, filaInsertar);
            Grid.SetColumn(textBlockTarifa1, 0);
            Test.Children.Add(textBlockTarifa1);

            var textBlockCantidad1 = new TextBlock
            {
                Text = "37",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockCantidad1, filaInsertar);
            Grid.SetColumn(textBlockCantidad1, 1);
            Test.Children.Add(textBlockCantidad1);

            var textBlockImporte1 = new TextBlock
            {
                Text = "$407.00",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockImporte1, filaInsertar);
            Grid.SetColumn(textBlockImporte1, 2);
            Test.Children.Add(textBlockImporte1);

            // Segunda fila dinámica
            var textBlockTarifa2 = new TextBlock
            {
                Text = "$9.00",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003A70")),
                Foreground = Brushes.White,
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockTarifa2, filaInsertar + 1);
            Grid.SetColumn(textBlockTarifa2, 0);
            Test.Children.Add(textBlockTarifa2);

            var textBlockCantidad2 = new TextBlock
            {
                Text = "19",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockCantidad2, filaInsertar + 1);
            Grid.SetColumn(textBlockCantidad2, 1);
            Test.Children.Add(textBlockCantidad2);

            var textBlockImporte2 = new TextBlock
            {
                Text = "$171.00",
                FontSize = 14,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                Padding = new Thickness(9, 10, 9, 10),
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(textBlockImporte2, filaInsertar + 1);
            Grid.SetColumn(textBlockImporte2, 2);
            Test.Children.Add(textBlockImporte2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Trace.WriteLine("Contraseña recibida: " + receivedPassword);
            //Debug.WriteLine("something----------------------------------------------------------------------------");
            MessageBox.Show("Contraseña: " + receivedPassword);
        }
    }

    public class Boletaje
    {
        public string? Tarifa { get; set; }
        public int Cantidad { get; set; }
        public string? Importe { get; set; }
    }
}

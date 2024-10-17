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
using System.Net.Http;
using Newtonsoft.Json;

namespace Quiosco
{
    /// <summary>
    /// Lógica de interacción para Detalle.xaml
    /// </summary>
    public partial class Detalle : Page
    {
        //private ApiClient apiClient;
        //private string contraseniaRecibida;
        private string receivedPassword;
        InformacionVuelta? informacionVuelta;
        public Detalle(string contrasenia)
        {
            InitializeComponent();
            //private static HttpClient baseUrl = new HttpClient();
            receivedPassword = contrasenia;
            //apiClient = new ApiClient();
            _ = InicializarAsync();
        }
        private async Task InicializarAsync()
        {
            await HacerPeticionGetAsync();

            AgregarFilasDinamicamente();
        }
        private async Task HacerPeticionGetAsync()
        {
            try
            {
                // Instanciar el cliente API
                ApiClient apiClient = new ApiClient();

                // Realizar la petición GET
                //string endpoint = "api/operador/informacionvuelta/05987";
                string endpoint = $"api/operador/informacionvuelta/{receivedPassword}";
                HttpResponseMessage respuesta = await apiClient.GetAsync(endpoint);

                int codigoEstado = (int)respuesta.StatusCode;
                MessageBox.Show("Código de Estado: " + codigoEstado);
                string stringResponse = await respuesta.Content.ReadAsStringAsync();
                //MessageBox.Show("Respuesta: " + stringResponse);
                respuesta.Dispose();
                if (codigoEstado == 200) ProcesarRespuesta(stringResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la petición: " + ex.Message);
            }
        }
        private void ProcesarRespuesta(string jsonResponse)
        {
            try
            {
                // Deserializar la respuesta JSON en un objeto de tipo InformacionVuelta
                informacionVuelta = JsonConvert.DeserializeObject<InformacionVuelta>(jsonResponse);

                // Ahora puedes acceder a las propiedades del objeto
                //MessageBox.Show("Tarifa: " + informacionVuelta?.Vendidos[0].Tarifa);
                //MessageBox.Show("Cantidad: " + informacionVuelta?.Vendidos[0].Cantidad);


                //MessageBox.Show("Unidad: " + informacionVuelta?.Unidad);
                //MessageBox.Show("Total boletos: " + informacionVuelta?.Totalboletos);
                // Puedes seguir accediendo a otras propiedades del objeto como desees
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deserializar el JSON: " + ex.Message);
            }
        }
        private void AgregarFilasDinamicamente()
        {
            if (informacionVuelta?.Vendidos == null || informacionVuelta.Vendidos.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles en la lista de Vendidos.");
                return;
            }
            float totalBoletaje = 0;
            
            int filaInsertar = 2;

            
            for (int i = 0; i < informacionVuelta.Vendidos.Count; i++)
            {
                // Insertar una nueva RowDefinition con Height="Auto" en la posición filaInsertar + i
                Test.RowDefinitions.Insert(filaInsertar + i, new RowDefinition { Height = GridLength.Auto });
            }

            
            foreach (UIElement child in Test.Children)
            {
                int currentRow = Grid.GetRow(child);
                if (currentRow >= filaInsertar)
                {
                    // Desplazar hacia abajo los elementos que están en filaInsertar o mayor
                    Grid.SetRow(child, currentRow + informacionVuelta.Vendidos.Count);
                }
            }

            
            int filaActual = filaInsertar;

            foreach (var vendido in informacionVuelta.Vendidos)
            {
                
                var textBlockTarifa = new TextBlock
                {
                    Text = $"${vendido.Tarifa}",
                    FontSize = 14,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003A70")),
                    Foreground = Brushes.White,
                    Padding = new Thickness(9, 10, 9, 10),
                    TextAlignment = TextAlignment.Center
                };
                Grid.SetRow(textBlockTarifa, filaActual);
                Grid.SetColumn(textBlockTarifa, 0);
                Test.Children.Add(textBlockTarifa);

                
                var textBlockCantidad = new TextBlock
                {
                    Text = vendido.Cantidad.ToString(),
                    FontSize = 14,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                    Padding = new Thickness(9, 10, 9, 10),
                    TextAlignment = TextAlignment.Center
                };
                Grid.SetRow(textBlockCantidad, filaActual);
                Grid.SetColumn(textBlockCantidad, 1);
                Test.Children.Add(textBlockCantidad);

                
                var textBlockImporte = new TextBlock
                {
                    Text = $"${vendido.Tarifa * vendido.Cantidad}",
                    FontSize = 14,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
                    Padding = new Thickness(9, 10, 9, 10),
                    TextAlignment = TextAlignment.Center
                };
                Grid.SetRow(textBlockImporte, filaActual);
                Grid.SetColumn(textBlockImporte, 2);
                Test.Children.Add(textBlockImporte);

                totalBoletaje += vendido.Tarifa * vendido.Cantidad;
                
                filaActual++;
            }
            //TotalBoletaje.Text = $"{totalBoletaje}";
            TotalBoletaje.Text = $"${totalBoletaje:0.00}";
        }

        //private void AgregarFilasDinamicamente()
        //{
        //    //foreach (var vendido in informacionVuelta.Vendidos)
        //    //{
        //    //    MessageBox.Show($"Tarifa: ${vendido.Tarifa}");
        //    //}
        //    MessageBox.Show("Longitud de vendidos: " + informacionVuelta?.Vendidos.ToArray().Length);
        //    // MessageBox.Show("Tarifa: " + informacionVuelta?.Vendidos[0].Tarifa);
        //    // Paso 1: Agregar nuevas filas después de Row 1 (antes de Row 2)
        //    int filaInsertar = 2; // La posición en la que se insertarán las nuevas filas

        //    // Agregar dos nuevas filas para los datos dinámicos
        //    foreach (var vendido in informacionVuelta.Vendidos)
        //    {
        //        MessageBox.Show($"Inicio filaInsertar: {filaInsertar}");
        //        Test.RowDefinitions.Insert(filaInsertar, new RowDefinition { Height = GridLength.Auto });
        //        filaInsertar++;
        //        MessageBox.Show($"Fin filaInsertar: {filaInsertar}");
        //    }
        //    //Test.RowDefinitions.Insert(filaInsertar, new RowDefinition { Height = GridLength.Auto });
        //    //Test.RowDefinitions.Insert(filaInsertar + 1, new RowDefinition { Height = GridLength.Auto });

        //    // Paso 2: Ajustar los elementos que ya existen para que se desplacen hacia abajo
        //    foreach (UIElement child in Test.Children)
        //    {
        //        int currentRow = Grid.GetRow(child);
        //        if (currentRow >= filaInsertar)
        //        {
        //            // Desplazar hacia abajo los elementos que están en filaInsertar o mayor
        //            Grid.SetRow(child, currentRow + informacionVuelta!.Vendidos.ToArray().Length);
        //        }
        //    }

        //    // Paso 3: Agregar los TextBlock en las filas recién insertadas

        //    // Primera fila dinámica
        //    var textBlockTarifa1 = new TextBlock
        //    {
        //        Text = "$11.00",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003A70")),
        //        Foreground = Brushes.White,
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockTarifa1, filaInsertar);
        //    Grid.SetColumn(textBlockTarifa1, 0);
        //    Test.Children.Add(textBlockTarifa1);

        //    var textBlockCantidad1 = new TextBlock
        //    {
        //        Text = "37",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockCantidad1, filaInsertar);
        //    Grid.SetColumn(textBlockCantidad1, 1);
        //    Test.Children.Add(textBlockCantidad1);

        //    var textBlockImporte1 = new TextBlock
        //    {
        //        Text = "$407.00",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockImporte1, filaInsertar);
        //    Grid.SetColumn(textBlockImporte1, 2);
        //    Test.Children.Add(textBlockImporte1);

        //    // Segunda fila dinámica
        //    var textBlockTarifa2 = new TextBlock
        //    {
        //        Text = "$9.00",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003A70")),
        //        Foreground = Brushes.White,
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockTarifa2, filaInsertar + 1);
        //    Grid.SetColumn(textBlockTarifa2, 0);
        //    Test.Children.Add(textBlockTarifa2);

        //    var textBlockCantidad2 = new TextBlock
        //    {
        //        Text = "19",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockCantidad2, filaInsertar + 1);
        //    Grid.SetColumn(textBlockCantidad2, 1);
        //    Test.Children.Add(textBlockCantidad2);

        //    var textBlockImporte2 = new TextBlock
        //    {
        //        Text = "$171.00",
        //        FontSize = 14,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0DCF2")),
        //        Padding = new Thickness(9, 10, 9, 10),
        //        TextAlignment = TextAlignment.Center
        //    };
        //    Grid.SetRow(textBlockImporte2, filaInsertar + 1);
        //    Grid.SetColumn(textBlockImporte2, 2);
        //    Test.Children.Add(textBlockImporte2);
        //}
    }
}
public class Vendido
{
    public int Tarifa { get; set; }
    public int Cantidad { get; set; }
}

public class DiferenciaBarras
{
    public string? _id { get; set; }
    public int Nvuelta { get; set; }
    public int Difbarras { get; set; }
    public bool BarrasCobradas { get; set; }
}

public class DiferenciaMinutos
{
    public int Nvuelta { get; set; }
    public int Difminutos { get; set; }
    public bool MinutosCobrados { get; set; }
}

public class InformacionVuelta
{
    public string? _id { get; set; }
    public string? Unidad { get; set; }
    public int Totalboletos { get; set; }
    public int Totalimporte { get; set; }
    public int Tarifabarras { get; set; }
    public int Tarifaminutos { get; set; }
    public List<Vendido>? Vendidos { get; set; }
    public int Vueltaactual { get; set; }
    public List<DiferenciaBarras>? DiferenciaBarras { get; set; }
    public List<DiferenciaMinutos>? DiferenciaMinutos { get; set; }
}
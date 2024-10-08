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
            receivedPassword = contrasenia;

            MessageBox.Show("Contraseña recibida: " + receivedPassword);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Trace.WriteLine("Contraseña recibida: " + receivedPassword);
            //Debug.WriteLine("something----------------------------------------------------------------------------");
            MessageBox.Show("Contraseña: " + receivedPassword);
        }
    }
}

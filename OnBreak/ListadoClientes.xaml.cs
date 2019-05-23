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
using OnBreakLibrary;

namespace OnBreak
{
    /// <summary>
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : Window
    {
        private ClienteCollection _clienteCollection
            = new ClienteCollection();

        public static ListadoClientes ventanaListado;

        public static ListadoClientes getInstance()
        {
            if (ventanaListado == null)
            {
                ventanaListado = new ListadoClientes();
            }
            return ventanaListado;
        }

        public ListadoClientes()
        {
            InitializeComponent();
            cboTipoEmpresa.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cboTipoEmpresa.SelectedIndex = 0;

            cboActividad.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cboActividad.SelectedIndex = 0;

            //DB

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ReadAll();

        }


        public ClienteCollection ClienteCollection
        {
            get
            {
                return _clienteCollection;
            }

            set
            {
                _clienteCollection = value;
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.Clientes;
        }

        private void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            String rut = txtRut.Text;
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.clientePorRut(rut);
        }

        private void btnFiltrarTipoE_Click(object sender, RoutedEventArgs e)
        {
            TipoEmpresa tipoE = (TipoEmpresa)cboTipoEmpresa.SelectedIndex;
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.clientesPorTipoE(tipoE);
        }

        private void btnFiltrarActividad_Click(object sender, RoutedEventArgs e)
        {
            ActividadEmpresa actividad = (ActividadEmpresa)cboActividad.SelectedIndex;
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.clientesPorActividadE(actividad);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente cliente = (Cliente)dgClientes.SelectedItem;

            if(cliente != null)
            {
                String rut = "1111111-1";
                MainWindow.getInstance().RecibirCliente(cliente);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaListado = null;
        }
    }
}

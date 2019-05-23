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
    public partial class ListadoContrato : Window
    {
        private ClienteCollection _clienteCollection
              = new ClienteCollection();
        private ContratoCollection _contratoCollection
            = new ContratoCollection();

        public static ListadoContrato ventanaListado;

        public ContratoCollection ContratoCollection
        {
            get
            {
                return _contratoCollection;
            }

            set
            {
                _contratoCollection = value;
            }
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

        public static ListadoContrato getInstance()
        {
            if (ventanaListado == null)
            {
                ventanaListado = new ListadoContrato();
            }

            return ventanaListado;
        }

        public ListadoContrato()
        {
            InitializeComponent();
            InitializeComponent();
            cboTipoContrato.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cboTipoContrato.SelectedIndex = 0;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            dgContrato.ItemsSource = null;
            dgContrato.ItemsSource = this.ContratoCollection.Contrato;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaListado = null;
        }

        private void btnFiltrarNContrato_Click(object sender, RoutedEventArgs e)
        {
            int numeroContrato = int.Parse(txtNumeroContrato.Text);
            dgContrato.ItemsSource = null;
            dgContrato.ItemsSource = this.ContratoCollection.contratoPorNumero(numeroContrato);
        }

        private void btnFiltrarRutCliente_Click(object sender, RoutedEventArgs e)
        {
            String rut = txtRutCliente.Text;
            dgContrato.ItemsSource = null;
            dgContrato.ItemsSource = this.ClienteCollection.clientePorRut(rut);
        }

        private void btnFiltrarTipoContrato_Click(object sender, RoutedEventArgs e)
        {
            TipoEvento tipoEvento = (TipoEvento)cboTipoContrato.SelectedIndex;
            dgContrato.ItemsSource = null;
            dgContrato.ItemsSource = this.ContratoCollection.TipoContrato(tipoEvento);
        }
    }
}

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
    /// Lógica de interacción para AdminContrato.xaml
    /// </summary>
    public partial class AdminContrato : Window
    {
        private static AdminContrato ventanaPrincipal2;

        public static AdminContrato getInstance()
        {
            if (ventanaPrincipal2 == null)
            {
                ventanaPrincipal2 = new AdminContrato();
            }

            return ventanaPrincipal2;
        }

        private ClienteCollection _clienteCollection
            = new ClienteCollection();

        private ContratoCollection _contratoCollection
            = new ContratoCollection();

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

        public AdminContrato()
        {
            InitializeComponent();
            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cboTipo.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaPrincipal2 = null;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            txtNombre.Text = "";
            txtNumeroContrato.Text = "";
            cboTipo.SelectedIndex = 0;
            txtDireccion.Text = "";
            txtAsistentes.Text = "";
            txtPersonalBase.Text = "";
            txtPersonalAdicional.Text = "";
            dpFechaInicio.SelectedDate = DateTime.Today;
            dpFechaTermino.SelectedDate = DateTime.Today;
        }

        private void btnBuscarRut_Click(object sender, RoutedEventArgs e)
        {
            //revisar
            string rut = txtRut.Text;

            Cliente cliente = _clienteCollection.BuscarClientePorRut(rut);

            if (cliente == null)
            {
                MessageBox.Show("El rut no existe");
                return;
            }

            txtRut.Text = cliente.Rut;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();

            contrato.NumeroContrato = int.Parse(txtNumeroContrato.Text);
            contrato.Tipo = (TipoEvento)cboTipo.SelectedIndex;
            contrato.Direccion = txtDireccion.Text;
            contrato.FechaHoraInicio = dpFechaInicio.SelectedDate.Value;
            contrato.FechaHoraTermino = dpFechaTermino.SelectedDate.Value;
            contrato.Observaciones = txtObservaciones.Text;

            if (this.ContratoCollection.AgregarContrato(contrato))
            {
                MessageBox.Show("Agregado correctamente");
            }
            else
            {
                MessageBox.Show("Este cliente ya existe");
            }
            
        }
    }
        }
    


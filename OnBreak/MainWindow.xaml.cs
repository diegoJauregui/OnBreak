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
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using OnBreakLibrary;

namespace OnBreak
{
   
    public partial class MainWindow
    {
        private ClienteCollection _clienteCollection
            = new ClienteCollection();
       

        public static MainWindow ventaPrincipal;

        public static MainWindow getInstance()
        {
            if(ventaPrincipal ==null)
            {
            ventaPrincipal = new MainWindow();
    }
        return ventaPrincipal;
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



        public MainWindow()
        {
            InitializeComponent();

            cboActividad.ItemsSource = ClienteCollection.ListarActividadEmpresa();
            cboActividad.SelectedIndex = 0;

            cboTipo.ItemsSource = ClienteCollection.ListarTipoEmpresa();
            cboTipo.SelectedIndex = 0;
        }

        public void CargarGrilla()
        {

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.Clientes;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;

            Cliente cliente = _clienteCollection.BuscarClientePorRut(rut);

            if (cliente == null)
            {
                MessageBox.Show("El rut no existe");
                return;
            }

            txtRut.Text = cliente.Rut;
            txtNombreContacto.Text = cliente.Nombre;
            txtCorreo.Text = cliente.Correo;
            txtRazon.Text = cliente.RazonSocial;
            txtDireccion.Text = cliente.Direccion;
            txtTelefono.Text = cliente.Telefono;
            cboActividad.SelectedIndex = (int)cliente.ActividadEmpresa;
            cboTipo.SelectedIndex = (int)cliente.TipoEmpresa;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            if (_clienteCollection.EliminarClientes(rut))
            {
                MessageBox.Show("Eliminado correctamente");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No existe el cliente");
            }
        }

        private void btnActualizar_Click_1(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            Cliente cliente = _clienteCollection.BuscarClientePorRut(rut);

            cliente.RazonSocial = txtRazon.Text;
            cliente.Nombre = txtNombreContacto.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.ActividadEmpresaId = int.Parse(cboActividad.SelectedValue.ToString());
            cliente.TipoEmpresaId = int.Parse(cboTipo.SelectedValue.ToString());

            if (ClienteCollection.ModificarClientes(cliente))
            {
                MessageBox.Show("Actualizacion Correctamente");
            }
            else
            {
                MessageBox.Show("No se a podido actualizar Correctamente");
            }

            CargarGrilla();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = " ";
            txtRazon.Text = " ";
            txtNombreContacto.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = " ";
            txtTelefono.Text = " ";
            cboActividad.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
        }

        private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            Estadistica ventanaEstadisticas = new Estadistica();
            ventanaEstadisticas.ClienteCollection = this._clienteCollection;
            ventanaEstadisticas.Show();
        }

        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Rut = txtRut.Text;
            cliente.RazonSocial = txtRazon.Text;
            cliente.Nombre = txtNombreContacto.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = txtTelefono.Text;

            cliente.ActividadEmpresaId = int.Parse(cboActividad.SelectedValue.ToString());
            cliente.TipoEmpresaId = int.Parse(cboTipo.SelectedValue.ToString());

            if (this._clienteCollection.InsertarCliente(cliente))
            {
                MessageBox.Show("Agregado correctamente");
            }
            else
            {
                MessageBox.Show("Este cliente ya existe");
            }
            CargarGrilla();
        }

            public void RecibirCliente(Cliente cliente)
        {
            txtRut.Text = cliente.Rut;
            txtNombreContacto.Text = cliente.Nombre;
            txtCorreo.Text = cliente.Correo;
            txtDireccion.Text = cliente.Direccion;
            txtTelefono.Text = cliente.Telefono;
            txtRazon.Text = cliente.RazonSocial;
            cboActividad.SelectedIndex = (int)cliente.ActividadEmpresa;
            cboTipo.SelectedIndex = (int)cliente.TipoEmpresa;
        }

        private void btnlistado_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventaPrincipal = null;
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }
    } 
}

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
    /// Lógica de interacción para Estadistica.xaml
    /// </summary>
    public partial class Estadistica : Window
    {

        private ClienteCollection _clienteCollection;

        public Estadistica()
        {
            InitializeComponent();

            cboTipoEmpresa.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cboTipoEmpresa.SelectedIndex = 0;

            cboActividadEmpresa.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cboActividadEmpresa.SelectedIndex = 0;
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

        private void btnmostrar_Click(object sender, RoutedEventArgs e)
        {

            txtCantidad.Text = this.ClienteCollection.CantidadRegistro().ToString();

            TipoEmpresa tipoEmpresa = (TipoEmpresa)cboTipoEmpresa.SelectedIndex;
            txtCantidadTipoEmpresa.Text = this.ClienteCollection.cantidadTipoEmpresa(tipoEmpresa).ToString();

            ActividadEmpresa actividadEmpresa = (ActividadEmpresa)cboActividadEmpresa.SelectedIndex;
            txtCantidadActividad.Text = this.ClienteCollection.cantidadActividadEmpresa(actividadEmpresa).ToString();
        }
    }
}

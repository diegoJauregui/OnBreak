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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu
    {
        private ClienteCollection _clienteCollection
            = new ClienteCollection();
        private ContratoCollection _contratoCollection
            = new ContratoCollection();

        public static Menu ventanaMenu;

        public static Menu getInstance()
        {
            if(ventanaMenu == null)
            {
                ventanaMenu = new Menu();
            }
            return ventanaMenu;
        }


        public Menu()
        {
            InitializeComponent();
            ventanaMenu = this;
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().Show();
            MainWindow.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }

        private void Tile_Click_4(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            ListadoContrato.getInstance().Show();
            ListadoContrato.getInstance().ContratoCollection = this._contratoCollection;
        }

        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            AdminContrato.getInstance().Show();
            AdminContrato.getInstance().ContratoCollection = this._contratoCollection;
        }
    }
}

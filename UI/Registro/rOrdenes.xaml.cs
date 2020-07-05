using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tarea6RegistroDetalle2.BLL;
using Tarea6RegistroDetalle2.Entidades;

namespace Tarea6RegistroDetalle2.UI.Registro
{
    /// <summary>
    /// Interaction logic for rOrdenes.xaml
    /// </summary>
    public partial class rOrdenes : Window
    {
        private Ordenes ordenes = new Ordenes();
        Productos producto;
        public rOrdenes()
        {
            InitializeComponent();
            this.DataContext = ordenes;

            //Llenamos el SuplidorComboBox
            SuplidorIdComboBox.ItemsSource = SuplidorBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "Suplidores";
            SuplidorIdComboBox.DisplayMemberPath = "Nombres";

            //Llenamos el ProductosComboBox
            ProductosComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductosComboBox.SelectedValuePath = "Productos";
            ProductosComboBox.DisplayMemberPath = "ProductoId";
        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarOrdenId())
            {
                return;
            }

            ordenes = OrdenesBLL.Buscar(int.Parse(OrdenIdTextBox.Text));
            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;

            var detalle = new OrdenesDetalles(int.Parse(OrdenIdTextBox.Text), producto.ProductoId,
                  int.Parse(CantidadTextBox.Text), double.Parse(CostoTextBox.Text), double.Parse(TotalTexbox.Text), producto.Descripcion);

            ordenes.OrdenesDetalles.Add(detalle);
            ordenes.Monto += double.Parse(TotalTexbox.Text);
            producto.Inventario -= int.Parse(CantidadTextBox.Text);

            //ModificarProducto(); Descomente para guardar los cambios de la propiedad Inventario

            Cargar();

            LimpiarDetalle();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
                return;

            ordenes.OrdenesDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);

            Cargar();

            CantidadTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarGuardar())
                return;

            if (OrdenesBLL.Guardar(ordenes))
            {
                Limpiar();
                MessageBox.Show("Se a Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidarOrdenId())
                return;
            if (OrdenesBLL.Eliminar(int.Parse(OrdenIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ordenes;
        }

        public bool ValidarOrdenId()
        {
            if (!OrdenesBLL.Existe(int.Parse(OrdenIdTextBox.Text)))
            {
                MessageBox.Show("Ese registro no existe.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se admiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        public void LimpiarDetalle()
        {
            ProductosComboBox.SelectedItem = null;
            CantidadTextBox.Clear();
            CostoTextBox.Clear();
            DescripcionTextBox.Clear();
            TotalTexbox.Clear();
            InventarioTextBox.Clear();
            CantidadTextBox.Focus();
        }

        public void ModificarProducto()
        {
            ProductosBLL.Guardar(producto);
        }

        public void Limpiar()
        {
            this.ordenes = new Ordenes();
            this.DataContext = ordenes;
            SuplidorIdComboBox.SelectedItem = null;
        }

        public bool ValidarAgregar()
        {
            if (CantidadTextBox.Text.Length == 0 || CostoTextBox.Text.Length == 0)
            {
                MessageBox.Show("No pueden haber campos vacios.", "Campo vacio.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!Regex.IsMatch(CantidadTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Cantidad.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool ValidarGuardar()
        {
            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[1-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ProductosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductosComboBox.SelectedItem == null)
                return;
            producto = ((Productos)ProductosComboBox.SelectedItem);

            CostoTextBox.Text = producto.Costo.ToString();
            DescripcionTextBox.Text = producto.Descripcion;
            InventarioTextBox.Text = producto.Inventario.ToString();
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!Regex.IsMatch(CantidadTextBox.Text, "^[1-9]+$"))
            {

                TotalTexbox.Text = (0 * double.Parse(CostoTextBox.Text)).ToString();
            }
            else
            {
                TotalTexbox.Text = (int.Parse(CantidadTextBox.Text) * double.Parse(CostoTextBox.Text)).ToString();
            }
        }

    }
}

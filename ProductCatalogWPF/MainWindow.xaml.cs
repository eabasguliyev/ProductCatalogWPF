using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProductCatalogWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; }

        private Product _selectedProduct;
        public MainWindow()
        {
            this.DataContext = this;

            Products = new List<Product>()
            {
                new Product()
                {
                    Name = "Cola",
                    Price = 2,
                    Quantity = 120,
                },
                new Product()
                {
                    Name = "Pepsi",
                    Price = 5,
                    Quantity = 200,
                },
                new Product()
                {
                    Name = "Cips",
                    Price = 1,
                    Quantity = 50,
                },
                new Product()
                {
                    Name = "Bizon",
                    Price = 1.2,
                    Quantity = 400,
                },
                new Product()
                {
                    Name = "Hell",
                    Price = 2,
                    Quantity = 600,
                },
                new Product()
                {
                    Name = "Beer",
                    Price = 5,
                    Quantity = 350,
                },
            };
            InitializeComponent();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(ListBoxProducts.SelectedItem is Product item))
                return;

            _selectedProduct = item;

            ImageProduct.Source = String.IsNullOrWhiteSpace(item.ImagePath) ? null: new BitmapImage(new Uri(item.ImagePath));
            TextBoxProductName.Text = item.Name;
            TextBoxProductPrice.Text = item.Price.ToString("F");
            TextBoxProductQuantity.Text = item.Quantity.ToString();
        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
                return;

            _selectedProduct.Name = TextBoxProductName.Text;
            _selectedProduct.Price= Convert.ToDouble(TextBoxProductPrice.Text);
            _selectedProduct.Quantity = Convert.ToInt32(TextBoxProductQuantity.Text);

            RefreshListBox();
        }

        private void RefreshListBox()
        {
            ListBoxProducts.ItemsSource = null;
            ListBoxProducts.ItemsSource = Products;
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
                return;

            Products.Remove(_selectedProduct);
            RefreshListBox();
        }
    }
}

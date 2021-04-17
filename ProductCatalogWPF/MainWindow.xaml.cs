using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using ProductCatalogWPF.Extensions;

namespace ProductCatalogWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product> _mainProducts;
        public List<Product> Products { get; set; }
        

        private Product _selectedProduct;
        public MainWindow()
        {
            this.DataContext = this;

            _mainProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Cola",
                    Price = 2,
                    Quantity = 120,
                    ImagePath = "Images/Cola.png",
                },
                new Product()
                {
                    Name = "Pepsi",
                    Price = 5,
                    Quantity = 200,
                    ImagePath = "Images/Pepsi.png",
                },
                new Product()
                {
                    Name = "Lays",
                    Price = 1,
                    Quantity = 50,
                    ImagePath = "Images/Lays.png",
                },
                new Product()
                {
                    Name = "Bizon",
                    Price = 1.2,
                    Quantity = 400,
                    ImagePath = "Images/Bizon.jpg",
                },
                new Product()
                {
                    Name = "Hell",
                    Price = 2,
                    Quantity = 600,
                    ImagePath = "Images/Hell.png",
                },
                new Product()
                {
                    Name = "Baltika 9",
                    Price = 5,
                    Quantity = 350,
                    ImagePath = "Images/Baltika.png",
                },
            };

            Products = _mainProducts;
            InitializeComponent();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(ListBoxProducts.SelectedItem is Product item))
                return;

            _selectedProduct = item;

            ShowProductData(item);
        }

        private void ShowProductData(Product item)
        {
            if (!String.IsNullOrWhiteSpace(item.ImagePath))
            {
                ImageProduct.Source = new BitmapImage(new Uri(item.ImagePath, UriKind.RelativeOrAbsolute));
            }
            else
            {
                ImageProduct.Source = null;
            }

            TextBoxProductName.Text = item.Name;
            TextBoxProductPrice.Text = item.Price.ToString("F");
            TextBoxProductQuantity.Text = item.Quantity.ToString();
        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
                return;

            if (ImageProduct.Source != null)
                _selectedProduct.ImagePath = ImageProduct.Source.ToString();

            _selectedProduct.Name = TextBoxProductName.Text;
            _selectedProduct.Price= Convert.ToDouble(TextBoxProductPrice.Text);
            _selectedProduct.Quantity = Convert.ToInt32(TextBoxProductQuantity.Text);

            RefreshListBox(Products);
        }

        private void RefreshListBox(List<Product> products)
        {
            ListBoxProducts.ItemsSource = null;
            ListBoxProducts.ItemsSource = products;
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
                return;

            _mainProducts.Remove(_selectedProduct);
            Products.Remove(_selectedProduct);

            RefreshListBox(Products);
        }

        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                Products = _mainProducts;
            }
            else
            {
                Products = FilterByKeyword(TextBoxSearch.Text);
            }
            RefreshListBox(Products);
        }

        private List<Product> FilterByKeyword(string keyword)
        {
            keyword = keyword.ToLower();

            return _mainProducts.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var open = new OpenFileDialog();

            open.Multiselect = false;
            open.Filter = "Image file (*.png)|*.png";

            if (open.ShowDialog() != true)
                return;

            var image = new BitmapImage(new Uri(open.FileName));

            var fileName = $@"Images/{Guid.NewGuid()}.png";

            if (!Directory.Exists("Images"))
                Directory.CreateDirectory("Images");

            image.Save(fileName);

            var fullFileName = Directory.GetCurrentDirectory() + "\\" + fileName;
            
            ImageProduct.Source = new BitmapImage(new Uri(fullFileName));
        }
    }
}

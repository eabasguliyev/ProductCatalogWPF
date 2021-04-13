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

namespace ProductCatalogWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; }
        public MainWindow()
        {
            this.DataContext = this;

            Products = new List<Product>()
            {
                new Product()
                {
                    Name = "Cola",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Name = "Pepsi",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Name = "Cips",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Name = "Bizon",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Name = "Hell",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Name = "Beer",
                    Description = "Lab lab",
                    Price = 10,
                    Quantity = 100,
                },
            };
            InitializeComponent();
        }
    }
}

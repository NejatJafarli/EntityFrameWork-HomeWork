using EntityFrameWork_HomeWork.DataAccess.Concrete;
using EntityFrameWork_HomeWork.Models;
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

namespace EntityFrameWork_HomeWork.Views
{
    /// <summary>
    /// Interaction logic for ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {


        public double Price
        {
            get { return (double)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(double), typeof(ProductAddWindow));


        public Repository<Product> Repository { get; set; }
        public Product MyProduct { get; set; }
        public ProductAddWindow(Repository<Product> repository)
        {
            InitializeComponent();
            DataContext = this;
            Repository = repository;
        }
        public bool IsEdit { get; set; }
        public ProductAddWindow(Repository<Product> repository, Product Edit)
        {
            InitializeComponent();
            DataContext = this;
            Repository = repository;
            MyProduct = Edit;
            IsEdit = true;
            ProdNameTxt.Text = MyProduct.Name;
            Price = MyProduct.Price;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit == false)
                if (!string.IsNullOrWhiteSpace(ProdNameTxt.Text) && !string.IsNullOrWhiteSpace(ProdPriceTxt.Text))
                {
                    if (CategoryCB.SelectedItem is not null)
                        Repository.Insert(new Product { Name = ProdNameTxt.Text, Price = Price, CategoryId = (CategoryCB.SelectedItem as Category).Id });
                    else
                        Repository.Insert(new Product { Name = ProdNameTxt.Text, CategoryId = null, Price = Price });

                    Close();
                }
                else
                    MessageBox.Show("Product Name Or Product Price Text Is Empty");
            else
            {
                if (!string.IsNullOrWhiteSpace(ProdNameTxt.Text) && !string.IsNullOrWhiteSpace(ProdPriceTxt.Text))
                {
                    MyProduct.Name = ProdNameTxt.Text;
                    MyProduct.Price = Price;
                    if ((CategoryCB.SelectedItem as Category).Name != "Nothing")
                        MyProduct.CategoryId = (CategoryCB.SelectedItem as Category).Id;
                    else
                        MyProduct.CategoryId = null;
                    Repository.Update(MyProduct);
                    Close();
                }
                else
                    MessageBox.Show("Product Name Or Product Price Text Is Empty");

            }
        }
    }
}

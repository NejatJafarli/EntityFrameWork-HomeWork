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
using System.Windows.Navigation;
using System.Linq;
using System.Windows.Shapes;
using EntityFrameWork_HomeWork.Views;

namespace EntityFrameWork_HomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Repository<Product> Products { get; set; } = new Repository<Product>();
        public Repository<Category> Categories { get; set; } = new Repository<Category>();
        public MainWindow()
        {
            InitializeComponent();
            CategoryDG.ItemsSource = Categories.GetAll().ToList();
            ProductDG.ItemsSource = Products.GetAll().ToList();



            //Products.Insert(new Product { Name = "BMW E60", CategoryId=1, Price = 10000 });
            //Products.Insert(new Product { Name = "Mercedes MayBach", CategoryId=1, Price = 25000 });
            //Products.Insert(new Product { Name = "BMW F30", CategoryId=1, Price = 15000 });
            //Products.Insert(new Product { Name = "BMW F10", CategoryId=1, Price = 12000 });
            CatDelBtn.IsEnabled = false;
            CatEditBtn.IsEnabled = false;
            ProdDelBtn.IsEnabled = false;
            ProdEditBtn.IsEnabled = false;
        }

        private void CatAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = new CategoryAddWindow(Categories);
            temp.ShowDialog();

            CategoryDG.ItemsSource = Categories.GetAll().ToList();
            ProductDG.ItemsSource = Products.GetAll().ToList();
        }

        private void CatDelBtn_Click(object sender, RoutedEventArgs e)
        {
            Categories.Delete(CategoryDG.SelectedItem as Category);

            CategoryDG.ItemsSource = Categories.GetAll().ToList();
        }

        private void CategoryDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryDG.SelectedItem is not null)
            {
                CatEditBtn.IsEnabled = true;
                CatDelBtn.IsEnabled = true;
            }
            else
            {
                CatDelBtn.IsEnabled = false;
                CatEditBtn.IsEnabled = false;
            }
        }

        private void CatEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = new CategoryAddWindow(Categories, CategoryDG.SelectedItem as Category);
            temp.ShowDialog();
            CategoryDG.ItemsSource = Categories.GetAll().ToList();

        }

        private void ProductDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductDG.SelectedItem is not null)
            {
                ProdEditBtn.IsEnabled = true;
                ProdDelBtn.IsEnabled = true;
            }
            else
            {
                ProdDelBtn.IsEnabled = false;
                ProdEditBtn.IsEnabled = false;
            }
        }

        private void ProdAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = new ProductAddWindow(Products);
            var LinkedList = Categories.GetAll().ToList();
            LinkedList.Insert(0, new Category { Name = "Nothing" });
            temp.CategoryCB.ItemsSource = LinkedList;
            temp.CategoryCB.DisplayMemberPath = "Name";
            temp.ShowDialog();

            ProductDG.ItemsSource = Products.GetAll().ToList();
        }

        private void ProdDelBtn_Click(object sender, RoutedEventArgs e)
        {
            Products.Delete(ProductDG.SelectedItem as Product);

            ProductDG.ItemsSource = Products.GetAll().ToList();
        }

        private void ProdEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = new ProductAddWindow(Products, ProductDG.SelectedItem as Product);
            var LinkedList= Categories.GetAll().ToList();
            LinkedList.Insert(0, new Category { Name="Nothing"});
            temp.CategoryCB.ItemsSource = LinkedList;
            temp.CategoryCB.DisplayMemberPath = "Name";
            var temp2=Categories.Get(x => x.Id == (ProductDG.SelectedItem as Product).CategoryId).FirstOrDefault();
            temp.CategoryCB.SelectedItem=temp2;
            temp.ShowDialog();
            ProductDG.ItemsSource = Products.GetAll().ToList();
        }
    }
}

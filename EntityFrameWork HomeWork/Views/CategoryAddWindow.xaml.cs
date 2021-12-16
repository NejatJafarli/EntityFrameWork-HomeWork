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
    /// Interaction logic for CategoryAddWindow.xaml
    /// </summary>
    public partial class CategoryAddWindow : Window
    {
        public Repository<Category> Repository { get; set; }
        public CategoryAddWindow(Repository<Category> repository)
        {
            InitializeComponent();
            Repository = repository;
            IsEdit = false;
        }
        public bool IsEdit { get; set; }
        public Category MyCategory { get; set; }
        public CategoryAddWindow(Repository<Category> repository, Category Edit)
        {
            InitializeComponent();
            Repository = repository;
            MyCategory = Edit;
            IsEdit = true;
            txt.Text = MyCategory.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit == false)
                if (!string.IsNullOrWhiteSpace(txt.Text))
                {
                    Repository.Insert(new Category { Name = $"{txt.Text}" });
                    Close();
                }
                else
                    MessageBox.Show("Text Is Empty");
            else
            {
                if (!string.IsNullOrWhiteSpace(txt.Text))
                {
                    MyCategory.Name = txt.Text;
                    Repository.Update(MyCategory);
                    Close();
                }
                else
                    MessageBox.Show("Text Is Empty");

            }


        }
    }
}

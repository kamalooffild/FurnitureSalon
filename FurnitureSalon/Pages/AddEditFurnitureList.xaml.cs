using FurnitureSalon.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FurnitureSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditFurnitureList.xaml
    /// </summary>
    public partial class AddEditFurnitureList : Page
    {
        private Furniture _furniture;
        public AddEditFurnitureList(Furniture furniture)
        {
            InitializeComponent();
            DeleteTb.Visibility = Visibility.Hidden;
            DeleteTb.Text = "False";
            _furniture = furniture;
            this.DataContext = _furniture;
            if (furniture.Id == 0) idSp.Visibility = Visibility.Collapsed;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Furniture.Add(_furniture);
            App.db.SaveChanges();
            MessageBox.Show("Успешно добавлено!");
            NavigationService.Navigate(new ProductListPage());
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            IdTb.Clear();
            TypeNameTB.Clear();
            NameTB.Clear();
            MaterialsTb.Clear();
            CostTb.Clear();
            DiscountTb.Clear();
            DeleteTb.Clear();
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|.jpeg|*.jpeg|*.jpg|*.jpg",

            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                //App.db.Furniture.Photo = File.ReadAllBytes(openFileDialog.FileName);
                ServiceImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}

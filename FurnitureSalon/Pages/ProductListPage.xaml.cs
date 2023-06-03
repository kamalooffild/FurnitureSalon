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
using FurnitureSalon.Model;



namespace FurnitureSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            LVProduct.ItemsSource = App.db.Furniture.Where(x => x.IsDelete != true).ToList();

        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selFurniture = (sender as Button).DataContext as Furniture;
            NavigationService.Navigate(new AddEditFurnitureList(selFurniture));

        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selFurniture = (sender as Button).DataContext as Furniture;
            if (MessageBox.Show("Данная запись будет удалена. Вы уверены?",
                "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                selFurniture.IsDelete = true;
                App.db.SaveChanges();
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Byte фото в двоичный
            //foreach (var item in App.db.Service.ToArray().Where(x => !string.IsNullOrWhiteSpace(x.MainImagePath)))
            //{
            //    var fullpath = item.MainImagePath;
            //    var byteimage = File.ReadAllBytes(fullpath);
            //    item.ImageByte = byteimage;
            //}
            NavigationService.Navigate(new AddEditServiceList(new Furniture()));
        }
        public void Refresh()
        {
            IEnumerable<Furniture> filterFurniture = App.db.Furniture;
            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                    filterFurniture = filterFurniture.OrderBy(x => x.CostDiscount);
                else if (SortCb.SelectedIndex == 2)
                    filterFurniture = filterFurniture.OrderByDescending(x => x.CostDiscount);
            }
            if (DiscountSortCb.SelectedIndex > 0)
            {
                if (DiscountSortCb.SelectedIndex == 1)
                    filterFurniture = filterFurniture.Where(x => x.Discount >= 0 && x.Discount < 0.05 || x.Discount == null).ToList();
                else if (DiscountSortCb.SelectedIndex == 2)
                    filterFurniture = filterFurniture.Where(x => x.Discount >= 0.05 && x.Discount < 0.15).ToList();
                else if (DiscountSortCb.SelectedIndex == 3)
                    filterFurniture = filterFurniture.Where(x => x.Discount >= 0.15 && x.Discount < 0.3).ToList();
                else if (DiscountSortCb.SelectedIndex == 4)
                    filterFurniture = filterFurniture.Where(x => x.Discount >= 0.3 && x.Discount < 0.7).ToList();
                else if (DiscountSortCb.SelectedIndex == 5)
                    filterFurniture = filterFurniture.Where(x => x.Discount >= 0.7 && x.Discount < 1).ToList();
            }
            if (TitleDiscriptionTb.Text.Length > 0)
            {
                filterFurniture = filterFurniture.Where(x => x.Name.ToLower().StartsWith(TitleDiscriptionTb.Text.ToLower()) || x.Description.ToLower().StartsWith(TitleDiscriptionTb.Text.ToLower()));
            }
            LVProduct.ItemsSource = filterFurniture.ToList();
            FilterCount.Text = filterFurniture.Count() + " из";
            GeneralCount.Text = App.db.Service.Count().ToString();
        }
        private void TitleDiscriptionTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void DiscountSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void RecordBtn_Click(object sender, RoutedEventArgs e)
        {
            //var serService =  (sender as Button).DataContext as Service;
            ////NavigationService.Navigate(new RecordingPage(serService));
            //var addClientService = (sender as Button).DataContext as Service;
            //if (addClientService == null) return;
            //NavigationService.Navigate(new RecordingPage(addClientService));
        }
    }
    }
}

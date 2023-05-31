﻿using FurnitureSalon.Model;
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

namespace FurnitureSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServiceList.xaml
    /// </summary>
    public partial class AddEditServiceList : Page
    {
        private Service _service;

        public AddEditServiceList(Service service)
        {
            InitializeComponent();
            DeleteTb.Visibility = Visibility.Hidden;
            DeleteTb.Text = "False";
            _service = service;
            this.DataContext = _service;
            if (service.Id == 0) idSp.Visibility = Visibility.Collapsed;
            _service.Discount *= 10;
            service.Discount *= 10;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            //foreach (var item in App.db.Service)
            //{
            //    if (_service.Title == item.Title)
            //    {
            //        MessageBox.Show("Имеется");
            //        return;
            //    }
            //}

            App.db.Service.Add(_service);
            App.db.SaveChanges();
            MessageBox.Show("Успешно добавлено!");
            NavigationService.Navigate(new ServiceListPage());
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            idTb.Clear();
            TitleTB.Clear();
            CostTb.Clear();
            DurationInSecondsTb.Clear();
            DescriptionTb.Clear();
            DiscountTb.Clear();
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddIngBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteIngBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

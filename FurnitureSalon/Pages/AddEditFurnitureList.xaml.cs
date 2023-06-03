using FurnitureSalon.Model;
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
    }
}

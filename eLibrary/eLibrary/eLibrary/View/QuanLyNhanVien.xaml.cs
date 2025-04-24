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
using eLibrary.Controller;

namespace eLibrary.View
{
    /// <summary>
    /// Interaction logic for QuanLyNhanVien.xaml
    /// </summary>
    public partial class QuanLyNhanVien : Window
    {
        private ControllerNhanVien controllerNhanVien = new ControllerNhanVien();
        public QuanLyNhanVien()
        {
            InitializeComponent();
            getAllNhanVien();
        }

        public void getAllNhanVien()
        {
         var listNhanVien = controllerNhanVien.GetAllNhanVien();
         this.dgNhanVien.ItemsSource = listNhanVien;
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSortName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSortZA_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

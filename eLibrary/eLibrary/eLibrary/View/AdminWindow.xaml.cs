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

namespace eLibrary.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Login login = new Login();
        private QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();   
        public AdminWindow()
        {
            InitializeComponent();
        }

        // Log out
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void QuanLyNhanVien_Click(object sender, RoutedEventArgs e)
        {
            quanLyNhanVien.Show();
        }

        private void QuanLyDocGia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLySach_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLyTheThuVien_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLyMuonTraSach_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LichSuHoatDong_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

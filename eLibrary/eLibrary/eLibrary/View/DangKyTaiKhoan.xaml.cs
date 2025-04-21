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
using eLibrary.Models;

namespace eLibrary.View
{
    /// <summary>
    /// Interaction logic for DangKyTaiKhoan.xaml
    /// </summary>
    public partial class DangKyTaiKhoan : Window
    {
        public DangKyTaiKhoan()
        {
            InitializeComponent();
        }

        private void ChonAnh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DangKy_Click(object sender, RoutedEventArgs e)
        {
            String enterName = txtHoTen.Text;
            String enterGender = rdoNam.IsChecked == true ? "Nam" : rdoNu.IsChecked == true ? "Nữ" : null;
            DateTime? selectedDate = dpNgaySinh.SelectedDate;
            DateOnly? enterDate = selectedDate.HasValue ? DateOnly.FromDateTime(selectedDate.Value) : null;
            String enterAddress = txtDiaChi.Text;
            String enterEmail = txtEmail.Text;
            String enterPhone = txtSDT.Text;
            String enterPassword = txtMatKhau.Password;

            if (string.IsNullOrWhiteSpace(enterName) ||
             string.IsNullOrWhiteSpace(enterGender) ||
             enterDate == null ||
             string.IsNullOrWhiteSpace(enterAddress) ||
             string.IsNullOrWhiteSpace(enterEmail) ||
             string.IsNullOrWhiteSpace(enterPhone) ||
             string.IsNullOrWhiteSpace(enterPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            DocGium docGium = new DocGium {
                TenDocGia = enterName,
                GioiTinh = enterGender,
                NgaySinh = enterDate,
                DiaChi = enterAddress,
                Email = enterEmail,
                SoDienThoai = enterPhone,
                MatKhau = enterPassword,
               
            };
        }
    }
}

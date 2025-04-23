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
using Microsoft.Win32;
using System.IO;
using System.Printing;
using eLibrary.Controller;
using System.Text.RegularExpressions;


namespace eLibrary.View
{
    /// <summary>
    /// Interaction logic for DangKyTaiKhoan.xaml
    /// </summary>
    public partial class DangKyTaiKhoan : Window
    {
       private ControllerDocGia controllerDocGia = new ControllerDocGia();
        public DangKyTaiKhoan()
        {
            InitializeComponent();
        }
        private string selectedImagePath;
        // Lay anh
        private void ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
            Uri uri = new Uri(openFileDialog.FileName);
                imgAvatar.Source = new BitmapImage(uri);
                string sourceFile = openFileDialog.FileName;
                string avatarFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatar");
                if (!Directory.Exists(avatarFolder))
                {
                    Directory.CreateDirectory(avatarFolder); // Tạo thư mục nếu chưa có
                }
                string fileName = System.IO.Path.GetFileName(sourceFile);
                string destFile = System.IO.Path.Combine(avatarFolder, fileName);

                // Sao chép file vào thư mục "Avatar"
                File.Copy(sourceFile, destFile, true); 

                // Lưu đường dẫn vào biến nếu cần dùng sau
                selectedImagePath = destFile;

            }
        }

        private void DangKy_Click(object sender, RoutedEventArgs e)
        {
            String enterName = txtHoTen.Text.Trim();
            String enterGender = rdoNam.IsChecked == true ? "Nam" : rdoNu.IsChecked == true ? "Nữ" : null;
            DateTime? selectedDate = dpNgaySinh.SelectedDate;
            DateOnly? enterDate = selectedDate.HasValue ? DateOnly.FromDateTime(selectedDate.Value) : null;
            String enterAddress = txtDiaChi.Text.Trim();
            String enterEmail = txtEmail.Text.Trim();
            String enterPhone = txtSDT.Text.Trim();
            String enterPassword = txtMatKhau.Password.Trim();
        
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
            // Check thong tin nhan vein toan tai hay chua
            DocGium docGia = controllerDocGia.GetDocGiaByEmailPhone(enterEmail, enterPhone);
            if(docGia != null)
            {
                MessageBox.Show("Thông tin độc giả này đã tồn tại!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check ngay sinh trong qua khu
            if(enterDate >= DateOnly.FromDateTime(DateTime.Today))
            {
                MessageBox.Show("Ngày sinh không được chọn ở tương lai!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check email theo dung dinh dang
            if(!Regex.IsMatch(enterEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check SĐT dung dinh dang, 10 chu so
            if(enterPhone.Length != 10 || !enterPhone.All(char.IsDigit)) 
            {
                MessageBox.Show("Số điện thoại phai có đủ 10 ký tự", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check mat khau phai co du 8 den 16 ky tu
            if(enterPassword.Length < 8 || enterPassword.Length > 16) 
            {
                MessageBox.Show("Mật khẩu phải từ 8 đến 16 ký tự!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                Avartar = selectedImagePath,
            };
            controllerDocGia.addDocGia(docGium);
            MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

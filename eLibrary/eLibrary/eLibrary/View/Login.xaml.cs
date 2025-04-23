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
using eLibrary.Models;

namespace eLibrary.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ControllerAccount controllerAccount = new ControllerAccount();
        DocGiaWindow docgiaWindow = new DocGiaWindow();
        NhanVienWindow nhanvienWindow = new NhanVienWindow();
        DangKyTaiKhoan dangKyTaiKhoan = new DangKyTaiKhoan();
        ForgotPassword forgotPassword = new ForgotPassword();   

        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String enterEmail = txtEmail.Text;
            String enterPassword = txtPassword.Password;
            if (string.IsNullOrEmpty(enterEmail) || string.IsNullOrEmpty(enterPassword))
            {
                MessageBox.Show("Vui lòng nhập không để trống các trường.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check thong tin dang nhap cua dong gia
            DocGium docgia = controllerAccount.getDocGiaByEmailAndPassword(enterEmail, enterPassword);
            if (docgia != null) { 
                docgiaWindow.Show();
                this.Close();
                return;
            }
            // Check thong tin dang nhap cua nhan vien
            NhanVien nhanvien = controllerAccount.GetNhanVienByEmailAndPassword(enterEmail,enterPassword);
            if (nhanvien != null) { 
                nhanvienWindow.Show();
                this.Close();
                return;
            }

            MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            dangKyTaiKhoan.Show();

        }

        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            forgotPassword.Show();
            this.Close();
        }
    }
}

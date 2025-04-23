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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        private ControllerDocGia controllerDocGia = new ControllerDocGia();
        private ControllerNhanVien controllerNhanVien = new ControllerNhanVien();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void BtnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DocGium docgia = controllerDocGia.GetDocGiaByEmail(email);
            NhanVien nhanVien = controllerNhanVien.GetNhanVienByEmail(email);
            if (nhanVien == null || docgia == null) {
                MessageBox.Show("Email  không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        
    }
}

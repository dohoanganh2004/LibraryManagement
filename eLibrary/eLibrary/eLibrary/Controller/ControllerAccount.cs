using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.Models;

namespace eLibrary.Controller
{
    public class ControllerAccount
    {
       // Load thong tin doc gia de dang nhap
       public DocGium? getDocGiaByEmailAndPassword(string email, string matkhau)
        {
            ELibraryContext context = new ELibraryContext();
            return context.DocGia.Where(dg => dg.Email.Equals(email) && dg.MatKhau.Equals(matkhau)).FirstOrDefault();
        }

        // Load thong tin nhan vien de dang nhap
        public NhanVien? GetNhanVienByEmailAndPassword(string email , string matkhau)
        {
            ELibraryContext context = new ELibraryContext();
            return context.NhanViens.Where(nv => nv.Email.Equals(email) && nv.MatKhau.Equals(matkhau)).FirstOrDefault();
        }

       
    }
}

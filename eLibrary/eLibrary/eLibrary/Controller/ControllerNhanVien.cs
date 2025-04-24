using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.Models;

namespace eLibrary.Controller
{
    public class ControllerNhanVien
    {   //Lay thong tin cua nhan vien theo email
        public NhanVien? GetNhanVienByEmail(string email)
        {
            ELibraryContext context = new ELibraryContext();
            return context.NhanViens.Where(nv => nv.Email.Equals(email)).FirstOrDefault();  
        }

        // Lay Nhan Vien
        public List<NhanVien> GetAllNhanVien()
        {
            ELibraryContext context = new ELibraryContext();
            return context.NhanViens.ToList();
        }
    }
}

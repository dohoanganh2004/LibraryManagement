using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.Models;

namespace eLibrary.Controller
{
    public class ControllerDocGia
    {
        // them doc gia 
       public void addDocGia(DocGium docGium)
        {
            ELibraryContext context = new ELibraryContext();
            context.Add(docGium);
            context.SaveChanges();

        } 

        // update doc gia 
        public void updateDocGia(DocGium docGium)
        {
            ELibraryContext context = new ELibraryContext(); 
            context.Update(docGium);    
            context.SaveChanges();

        }

        // delete doc gia
        public void deleteDocGia(DocGium docGium)
        {
            ELibraryContext context = new ELibraryContext();
            context.Remove(docGium);
            context.SaveChanges();
        }
        // lay thong tin doc gia theo Email va Phone
        public DocGium? GetDocGiaByEmailPhone(string email, string phone)
        {
            ELibraryContext context = new ELibraryContext();
            return context.DocGia.Where(dg => dg.Email.Equals(email) || dg.SoDienThoai.Equals(phone)).FirstOrDefault();
        }


        // lay thong tin dco gia theo email
        public DocGium? GetDocGiaByEmail(string email)
        {
            ELibraryContext context = new ELibraryContext();
            return context.DocGia.Where(dg => dg.Email.Equals(email)).FirstOrDefault();
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.Abstract
{
    public   interface IAdminService
    {
        List<Admin> GetList();
        void adminAdd(Admin admin);
        Admin GetByID(int id);
        void adminDelete(Admin admin);
        void adminUpdate(Admin admin);
    }
}

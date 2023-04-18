using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _IadminDal;

        public AdminManager(IAdminDal ıadminDal)
        {
            _IadminDal = ıadminDal;
        }

        public void adminDelete(Admin admin)
        {
            _IadminDal.Delete(admin);
        }

        public void adminUpdate(Admin admin)
        {
            _IadminDal.Update(admin);
        }

        public void adminAdd(Admin admin)
        {
            _IadminDal.Insert(admin);
        }

        public Admin GetByID(int id)
        {
            return _IadminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _IadminDal.List();
        }
    }
}

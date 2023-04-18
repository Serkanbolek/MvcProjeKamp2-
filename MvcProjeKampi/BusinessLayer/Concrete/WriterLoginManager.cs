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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _IWriterdal;

        public WriterLoginManager(IWriterDal ıWriterdal)
        {
            _IWriterdal = ıWriterdal;
        }

        public Writer GetWriter(string name, string password)
        {
            return _IWriterdal.Get(x => x.WriterMail== name && x.WriterPassword == password);
        }
    }
}

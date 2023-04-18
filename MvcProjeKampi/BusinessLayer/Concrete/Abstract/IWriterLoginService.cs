using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.Abstract
{
    public interface IWriterLoginService
    {
        Writer GetWriter(string name, string password);
    }
}

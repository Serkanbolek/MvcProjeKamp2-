using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(String Mail)
        {
            return _messageDal.List(x => x.ReceiverMail == Mail);
        }

        public List<Message> GetListSendbox(String Mail)
        {
            return _messageDal.List(x => x.SenderMail == Mail);
        }

        public List<Message> ListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "Admin@gmail.com");
        }

        public List<Message> ListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "Admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}

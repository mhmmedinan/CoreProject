using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IDataResult<List<Message>> TGetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Message> TGetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}

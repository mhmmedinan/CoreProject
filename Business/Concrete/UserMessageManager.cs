using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class UserMessageManager : IUserMessageService
    {
        private readonly IUserMessageDal _userMessageDal;
        

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
            
        }

        public IDataResult<List<UserMessage>> TGetAll()
        {
            return new SuccessDataResult<List<UserMessage>>(_userMessageDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<UserMessage> TGetById(int id)
        {
          
            return new SuccessDataResult<UserMessage>(_userMessageDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(UserMessage userMessage)
        {
            userMessage.Status = false;
            _userMessageDal.Add(userMessage);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(UserMessage userMessage)
        {
            _userMessageDal.Delete(userMessage);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(UserMessage userMessage)
        {
            _userMessageDal.Update(userMessage);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }

        public IDataResult<List<UserMessage>> GetListReceiverMessage(string receiver)
        {
            return new SuccessDataResult<List<UserMessage>>(_userMessageDal.GetAll(x => x.Receiver == receiver).OrderByDescending(x=>x.Date).ToList());
        }

        public IDataResult<List<UserMessage>> GetListSenderMessage(string sender)
        {
            return new SuccessDataResult<List<UserMessage>>(_userMessageDal.GetAll(x => x.Sender == sender).OrderByDescending(x => x.Date).ToList());
        }

        public IDataResult<UserMessage> TrueReadMessage(int id)
        {
            UserMessage userMessage = TGetById(id).Data;
            userMessage.Status = true;
            TUpdate(userMessage);
            return new SuccessDataResult<UserMessage>(userMessage);
        }

        public IDataResult<List<UserMessage>> GetCountMessageUnRead(string receiver)
        {
            return new SuccessDataResult<List<UserMessage>>(_userMessageDal.GetAll(x => x.Receiver == receiver && x.Status==false));

        }
    }
}

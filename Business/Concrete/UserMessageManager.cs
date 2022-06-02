﻿using System;
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
    public class UserMessageManager:IUserMessageService
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

       
    }
}

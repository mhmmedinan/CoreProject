﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IUserMessageService:IGenericService<UserMessage>
    {
        IDataResult<List<UserMessage>> GetListReceiverMessage(string receiver);
        IDataResult<List<UserMessage>> GetListSenderMessage(string sender);
       
    }
}

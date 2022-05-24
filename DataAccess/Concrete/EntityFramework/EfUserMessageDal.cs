﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserMessageDal:EfEntityRepositoryBase<UserMessage,Context>,IUserMessageDal
    {
        public List<UserMessage> GetUserMessagesWithUser()
        {
            using (var context = new Context())
            {
                return context.UserMessages.Include(x => x.User).ToList();
            }
            
        }
    }
}

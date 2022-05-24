﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class ToDoList:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}

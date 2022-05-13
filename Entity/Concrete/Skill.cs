﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Skill : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}

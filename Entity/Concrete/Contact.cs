using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public string Mail{ get; set; }
        public string Phone{ get; set; }
    }
}

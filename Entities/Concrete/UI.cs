using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UI:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? UIServerIP { get; set; }
        public string? UIServerUserName { get; set; }
        public string? UIServerPassword { get; set; }
        public int ProjectId { get; set; }
    }
}

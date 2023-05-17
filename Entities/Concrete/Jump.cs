using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Jump:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? JumpServerIP { get; set; }
        public string? JumpServerUserName { get; set; }
        public string? JumpServerPassword { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ProjectId { get; set; }
    }
}

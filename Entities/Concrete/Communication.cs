using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Communication:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? InternalNumber { get; set; }
        public string? InternalEmail { get; set; }
        public string? ExternalNumber { get; set; }
        public string? ExternalEmail { get; set; }
        public int ProjectId { get; set; }
    }
}

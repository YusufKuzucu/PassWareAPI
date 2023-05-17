using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sql:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? SqlServerIP { get; set; }
        public string? SqlServerUserName { get; set; }
        public string? SqlServerPassword { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ProjectId { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Project:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string? ProjectServerIP { get; set; }
        public string? ProjectServerUserName { get; set; }
        public string? ProjectServerPassword { get; set; }
        public int? CompanyId { get; set; }
        public ICollection<Jump>? Jumps { get; set; } = new List<Jump>();
        public ICollection<Sql>? Sqls { get; set; } = new List<Sql>();
        public ICollection<Communication>? Communications { get; set; } = new List<Communication>();
        public ICollection<UI>? UIs { get; set; } = new List<UI>();
        public ICollection<Vpn>? Vpns { get; set; } = new List<Vpn>();
        public ICollection<Files>? Files { get; set; } = new List<Files>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

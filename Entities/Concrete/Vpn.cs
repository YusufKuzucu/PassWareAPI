using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Vpn:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? VpnProgramName { get; set; }
        public string? VpnConnectionAddress { get; set; }
        public string? VpnPassword { get; set; }
        public int ProjectId { get; set; }
    }
}

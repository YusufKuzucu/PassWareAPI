using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Link:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? ConnectExplanation { get; set; }
        public byte[]? ConnectionInfo { get; set; }
        public int ProjectId { get; set; }
    }
}

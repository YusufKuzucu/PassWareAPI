using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Files:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? ConnectExplanation { get; set; }
        public byte[]? ConnectionInfo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ProjectId { get; set; }
    }
}

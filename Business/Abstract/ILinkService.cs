using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILinkService
    {
        Task AddLink(Link link);
        Task DeleteLink(int id);
        Task UpdateLink(Link link);
        Task<List<Link>> GetAllLink();
        Task<Link> GetLink(int id);
    }
}

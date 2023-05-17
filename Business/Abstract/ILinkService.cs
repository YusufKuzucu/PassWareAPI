using Core.Utilities.Results;
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
        Task<IResult> AddLink(Link link);
        Task<IResult> DeleteLink(int id);
        Task<IResult> UpdateLink(Link link);
        Task<IDataResult<List<Link>>> GetAllLink(); 
        Task<IDataResult<Link>> GetLink(int id);
    }
}

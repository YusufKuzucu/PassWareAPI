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
        Task<IResult> AddLink(Link link, string createdBy);
        Task<IResult> DeleteLink(int id); 
        Task<IResult> UpdateLink(Link link, string updatedBy);
        Task<IDataResult<List<Link>>> GetAllLink(); 
        Task<IDataResult<Link>> GetLink(int id);
    }
}

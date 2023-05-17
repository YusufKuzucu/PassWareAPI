using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LinkManager : ILinkService
    {
        ILinkDal _linkDal;
        public LinkManager(ILinkDal linkDal)
        {
            _linkDal = linkDal;
        }
        public async Task<IResult> AddLink(Link link)
        {
            await _linkDal.AddAsync(link);
            return new SuccessResult();

        }

        public async Task<IResult> DeleteLink(int id)
        {
           await _linkDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<Link>>> GetAllLink()
        {
            return new SuccessDataResult<List<Link>>( await _linkDal.GetAllAsync());
        }

        public async Task<IDataResult<Link>> GetLink(int id)
        {
            return new SuccessDataResult<Link>(await _linkDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateLink(Link link)
        {
            await _linkDal.UpdateAsync(link);
            return new SuccessResult();
        }
    }
}

using Business.Abstract;
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
        public async Task AddLink(Link link)
        {
            await _linkDal.AddAsync(link);
        }

        public async Task DeleteLink(int id)
        {
           await _linkDal.DeleteAsync(id);
        }

        public async Task<List<Link>> GetAllLink()
        {
            return await _linkDal.GetAllAsync();
        }

        public async Task<Link> GetLink(int id)
        {
            return await _linkDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateLink(Link link)
        {
            await _linkDal.UpdateAsync(link);
        }
    }
}

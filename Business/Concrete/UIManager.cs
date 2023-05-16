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
    public class UIManager : IUIService
    {
        IUIDal _uıDal;
        public UIManager(IUIDal uIDal)
        {
            _uıDal = uIDal;
        }
        public async Task AddUI(UI uI)
        {
            await _uıDal.AddAsync(uI);
        }

        public async Task DeleteUI(int id)
        {
            await _uıDal.DeleteAsync(id);
        }

        public async Task<List<UI>> GetAllUI()
        {
            return await _uıDal.GetAllAsync();
        }

        public async Task<UI> GetUI(int id)
        {
            return await _uıDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateUI(UI uI)
        {
            await _uıDal.UpdateAsync(uI);
        }
    }
}

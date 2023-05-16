using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUIService
    {
        Task AddUI(UI uI);
        Task DeleteUI(int id);
        Task UpdateUI(UI uI);
        Task<List<UI>> GetAllUI();
        Task<UI> GetUI(int id);

    }
}

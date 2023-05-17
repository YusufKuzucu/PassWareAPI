using Core.Utilities.Results;
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
        Task<IResult> AddUI(UI uI);
        Task<IResult> DeleteUI(int id);
        Task<IResult> UpdateUI(UI uI);
        Task<IDataResult<List<UI>>> GetAllUI();
        Task<IDataResult<UI>> GetUI(int id);

    }
}

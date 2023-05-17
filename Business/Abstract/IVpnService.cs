using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVpnService
    {
        Task<IResult> AddVpn(Vpn vpn,string createdBy); 
        Task<IResult> DeleteVpn(int id);
        Task<IResult> UpdateVpn(Vpn vpn, string updatedBy);
        Task<IDataResult<List<Vpn>>> GetAllVpn(); 
        Task<IDataResult<Vpn>> GetVpn(int id);
    }
}

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
    public class VpnManager : IVpnService
    {
        IVpnDal _vpnDal;
        public VpnManager(IVpnDal vpnDal)
        {
            _vpnDal = vpnDal;
        }
        public async Task<IResult> AddVpn(Vpn vpn,string createdBy)
        {
           await _vpnDal.AddAsync(vpn, createdBy);
            return new SuccessResult();

        }

        public async Task<IResult> DeleteVpn(int id)
        {
           await _vpnDal.DeleteAsync(id);
           return new SuccessResult();

        }

        public async Task<IDataResult<List<Vpn>>> GetAllVpn()
        {
            return new SuccessDataResult<List<Vpn>>( await _vpnDal.GetAllAsync());
        }

        public async Task<IDataResult<Vpn>> GetVpn(int id)
        {
            return new SuccessDataResult<Vpn>( await _vpnDal.GetAsync(p=>p.Id==id));
        }

        public async Task<IResult> UpdateVpn(Vpn vpn, string updatedBy)
        {
            await _vpnDal.UpdateAsync(vpn, updatedBy);
            return new SuccessResult();
        }
    }
}

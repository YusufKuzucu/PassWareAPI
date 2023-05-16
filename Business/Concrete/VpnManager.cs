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
    public class VpnManager : IVpnService
    {
        IVpnDal _vpnDal;
        public VpnManager(IVpnDal vpnDal)
        {
            _vpnDal = vpnDal;
        }
        public async Task AddVpn(Vpn vpn)
        {
           await _vpnDal.AddAsync(vpn);
        }

        public async Task DeleteVpn(int id)
        {
           await _vpnDal.DeleteAsync(id);
        }

        public async Task<List<Vpn>> GetAllVpn()
        {
            return await _vpnDal.GetAllAsync();
        }

        public async Task<Vpn> GetVpn(int id)
        {
            return await _vpnDal.GetAsync(p=>p.Id==id);
        }

        public async Task UpdateVpn(Vpn vpn)
        {
            await _vpnDal.UpdateAsync(vpn);
        }
    }
}

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
        Task AddVpn(Vpn vpn);
        Task DeleteVpn(int id);
        Task UpdateVpn(Vpn vpn);
        Task<List<Vpn>> GetAllVpn();
        Task<Vpn> GetVpn(int id);
    }
}

using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace validation4.services.services
{
    public interface IUpdateProvider
    {
        Provider ProviderToUpdate { get; set; }
        Task<Provider> UpdateSelectedProvider();
    }
}

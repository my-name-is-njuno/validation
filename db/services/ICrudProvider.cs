using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace db.services
{
    public interface ICrudProvider : ICrud<Provider>
    {
        Task<List<Provider>> GetHospitals();
        Task<Provider> GetByCode(string code);
        Task<Provider> GetByName(string name);
    }
}

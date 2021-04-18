using db.dbmodels;
using db.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using validation4.notifiers;
using validation4.services.services;

namespace validation4.services.serviceimplementation
{
    public class UpdateProvider : ChangeNotifier, IUpdateProvider
    {

        private readonly ICrudProvider _prcrud;
        public UpdateProvider(ICrudProvider prcrud)
        {
            _prcrud = prcrud;
        }




        private Provider provider_to_update;

        public Provider ProviderToUpdate
        {
            get { return provider_to_update; }
            set { provider_to_update = value; OnPropertyChanged(); }
        }

       

        public async Task<Provider> UpdateSelectedProvider()
        {
            if (ProviderToUpdate != null)
            {
                var updatedpr = await _prcrud.Update(ProviderToUpdate.Id, ProviderToUpdate);
                return updatedpr;
            }
            return null;
        }
    }
}

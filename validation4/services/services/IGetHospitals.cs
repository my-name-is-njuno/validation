using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace validation4.services.services
{
    public interface IGetHospitals
    {
        bool IsLoading { get; }
        ObservableCollection<Provider> AllProviders { get; set; }
        ObservableCollection<Provider> DisplayedProviders { get; set; }
        Provider QueryedProvider { get; set; }
        ObservableCollection<Provider> QueryedProviders { get; set; }
        ObservableCollection<Provider> SearchedProviders { get; set; }
        Provider SelectedProvider { get; set; }
        string SearchTerm { get; set; }
        int AllProviderCount { get; }
        int SearchedProviderCount { get; }
        bool IsSelectedProvider { get; }
        void GetAllProviders();
        Task<bool> GetProviderByName(string name);
        Task<bool> GetProviderByCode(string code);
       
    }
}

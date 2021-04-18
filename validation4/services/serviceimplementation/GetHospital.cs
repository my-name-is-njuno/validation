using db.dbmodels;
using db.services;
using pagination.pg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using validation4.notifiers;
using validation4.services.services;

namespace validation4.services.serviceimplementation
{
    public class GetHospital : ChangeNotifier, IGetHospitals
    {
        public PgVM Pagination { get; set; }
        public PgModel PaginationModel { get; set; }


        private string _search_term;

        public string SearchTerm
        {
            get { return _search_term; }
            set { _search_term = value; OnPropertyChanged(); GetAllProviders(); }
        }


        private readonly ICrudProvider ProviderCud;
        public GetHospital(ICrudProvider providerCud, PgVM pgVM)
        {
            ProviderCud = providerCud;
            Pagination = pgVM;
            AllProviders = new ObservableCollection<Provider>();
            DisplayedProviders = new ObservableCollection<Provider>();
            SearchedProviders = new ObservableCollection<Provider>();
            GetAllProviders();
        }


        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }



        private ObservableCollection<Provider> allproviders;

        public ObservableCollection<Provider> AllProviders
        {
            get { return allproviders; }
            set { allproviders = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllProviderCount)); }
        }





        private ObservableCollection<Provider> displayedProviders;

        public ObservableCollection<Provider> DisplayedProviders
        {
            get { return displayedProviders; }
            set { displayedProviders = value; OnPropertyChanged(); }
        }


        private Provider queryedProvider;

        public Provider QueryedProvider
        {
            get { return queryedProvider; }
            set { queryedProvider = value; OnPropertyChanged(); }
        }



        private ObservableCollection<Provider> searchedProviders;

        public ObservableCollection<Provider> SearchedProviders
        {
            get { return searchedProviders; }
            set { searchedProviders = value; OnPropertyChanged(); OnPropertyChanged(nameof(SearchedProviders));  }
        }




        private ObservableCollection<Provider> queryedProviders;

        public ObservableCollection<Provider> QueryedProviders
        {
            get { return queryedProviders; }
            set { queryedProviders = value; OnPropertyChanged(); }
        }

       
        private Provider selectedProvider;

        

        public Provider SelectedProvider
        {
            get { return selectedProvider; }
            set { selectedProvider = value; OnPropertyChanged(); }
        }


        public bool IsSelectedProvider => !(SelectedProvider == null);


        public int AllProviderCount => AllProviders.Count;
        public int SearchedProviderCount => SearchedProviders.Count;

        public void GetAllProviders()
        {
            IsLoading = true;
            ProviderCud.GetHospitals().ContinueWith(task => {
                if (task.Exception == null)
                {
                    AllProviders = new ObservableCollection<Provider>(task.Result);

                    if (!string.IsNullOrEmpty(SearchTerm))
                    {
                        int pgg;
                        SearchedProviders = new ObservableCollection<Provider>(AllProviders.Where(i => i.Name.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase)));
                        if (SearchedProviderCount > 0)
                        {
                            if (SearchedProviders.Count > 10)
                            {
                                pgg = 5;
                            }
                            else
                            {
                                pgg = SearchedProviders.Count;
                            }
                            PaginationModel = new PgModel(pgg, SearchedProviders.Count);
                        }
                    } 
                    else
                    {
                        int pg;
                        if (AllProviders.Count > 5)
                        {
                            pg = 5;
                        }
                        else
                        {
                            pg = AllProviders.Count;
                        }
                        PaginationModel = new PgModel(pg, AllProviders.Count);
                    }
                    
                    Pagination.seed(PaginationModel);
                    ProcessDisplayItems();
                    IsLoading = false;
                    PaginationModel.PropertyChanged += PaginationModel_PropertyChanged;
                }
            });
        }

        private void PaginationModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PaginationModel.CurrentPage) || e.PropertyName == nameof(PaginationModel.PerPage))
            {
                if (PaginationModel.CurrentPage > PaginationModel.TotalPages)
                {
                    PaginationModel.CurrentPage = PaginationModel.TotalPages;
                }

                if (PaginationModel.CurrentPage < 1)
                {
                    PaginationModel.CurrentPage = 1;
                }

                if (PaginationModel.PerPage > PaginationModel.TotalItems)
                {
                    PaginationModel.PerPage = PaginationModel.TotalItems;
                }
                if (PaginationModel.PerPage < 1)
                {
                    PaginationModel.PerPage = 1;
                }
                ProcessDisplayItems();
            }
        }

        private void ProcessDisplayItems()
        {
            DisplayedProviders = new ObservableCollection<Provider>();
            int start_count = (Pagination.PgModel.CurrentPage - 1) * Pagination.PgModel.PerPage;
            for (int i = start_count; i < start_count + Pagination.PgModel.PerPage; i++)
            {
                if (i < AllProviders.Count)
                {
                    if (string.IsNullOrEmpty(SearchTerm))
                    {
                        DisplayedProviders.Add(AllProviders[i]);
                    } else
                    {
                        DisplayedProviders.Add(searchedProviders[i]);
                    }
                    
                }
            }
        }

        public async Task<bool> GetProviderByCode(string code)
        {
            var results = await ProviderCud.GetByCode(code);
            if (results != null)
            {
                QueryedProvider = results;
                return true;
            }
            return false;
        }

        public async Task<bool> GetProviderByName(string name)
        {
            var results = await ProviderCud.GetByName(name);
            if (results != null)
            {
                QueryedProvider = results;
                return true;
            }
            return false;
        }
    }
}

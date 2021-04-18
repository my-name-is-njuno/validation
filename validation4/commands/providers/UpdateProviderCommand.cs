using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using validation4.services.services;
using validation4.viewmodels;

namespace validation4.commands.providers
{
    public class UpdateProviderCommand : BaseAsyncCommand
    {
        private  IUpdateProvider _updateProvider;
        private ShowProviderVM _showProviderVM;

        public UpdateProviderCommand(IUpdateProvider updateProvider, ShowProviderVM showProviderVM)
        {
            _updateProvider = updateProvider;
            _showProviderVM = showProviderVM;
        }

        public override bool CanExecute(object parameter)
        {
            return _showProviderVM.CanUpdate && base.CanExecute(parameter);
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (!(
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.Name.Trim()) ||
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.Email.Trim()) ||
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.Phone.Trim()) ||
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.Code.Trim()) ||
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.ContactPerson.Trim()) ||
                string.IsNullOrEmpty(_showProviderVM.ProviderServices.SelectedProvider.Adress.Trim())
            ))
            {
                _updateProvider.ProviderToUpdate = _showProviderVM.ProviderServices.SelectedProvider;

                var results = await _updateProvider.UpdateSelectedProvider();

                if (results == null)
                {
                    _showProviderVM.Messager.Error = "Provider not updated successfully, try again man";
                }
            }
            else
            {
                _showProviderVM.Messager.Error = "";
                _showProviderVM.Messager.Error = "Empty fields";
            }
            
            
        }
    }
}

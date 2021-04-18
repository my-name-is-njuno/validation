using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace validation.models
{
    public class Validator : INotifyDataErrorInfo
    {
        public readonly Dictionary<string, List<string>> _propertiesErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertiesErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertiesErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddErrors(string propertyName, string errorMessage)
        {
            if (!_propertiesErrors.ContainsKey(propertyName))
            {
                _propertiesErrors.Add(propertyName, new List<string>());
            }
            _propertiesErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }


        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
           
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace validation2.models
{
    public class ErrorsNotifier : INotifyDataErrorInfo
    {
        public readonly Dictionary<string, List<string>> _propertysErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertysErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertysErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddErrors(string propertyName, string errorMessage)
        {
            if (!_propertysErrors.ContainsKey(propertyName))
            {
                _propertysErrors.Add(propertyName,new List<string>());
            }
            _propertysErrors[propertyName].Add(errorMessage);
            OnErrorChanged(propertyName);
        }



        public void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}

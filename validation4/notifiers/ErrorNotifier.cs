using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace validation4.notifiers
{
    public class ErrorNotifier : INotifyDataErrorInfo
    {
        public Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public void AddError(string propertyName, string errorInfo)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }
            _propertyErrors[propertyName].Add(errorInfo);
        }

        
        public bool HasErrors => _propertyErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }


        public void ClearErrors(string propertName)
        {
            if (_propertyErrors.ContainsKey(propertName))
            {
                _propertyErrors.Remove(propertName);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace valid3.notifiers
{
    public class ErrorNotifier : INotifyDataErrorInfo
    {
        public Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        internal void ClearErrors(string v)
        {
            if (_propertyErrors.ContainsKey(v))
            {
                _propertyErrors.Remove(v);
                OnErrorChanged(v);
            }
        }

        public void AddErrors(string property, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(property))
            {
                _propertyErrors.Add(property, new List<string>());
            }

            _propertyErrors[property].Add(errorMessage);

            OnErrorChanged(property);
        }


        public void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}

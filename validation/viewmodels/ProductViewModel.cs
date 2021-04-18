using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using validation.models;

namespace validation.viewmodels
{
    public class ProductViewModel : ChangeNotifier, INotifyDataErrorInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value; OnPropertyChanged(); 
                if (string.IsNullOrEmpty(Name))
                {
                    _validator.AddErrors(nameof(Name),"Name cannot be empty");
                } 
            }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }


        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                price = value; OnPropertyChanged();
                ClearErrors(nameof(Price));
                if (value > 50)
                {
                    _validator.AddErrors(nameof(Price), "Amount should not exceed 50");
                }
            }
        }

        private void ClearErrors(string v)
        {
            if (_validator._propertiesErrors.Remove(v))
            {
                _validator.OnErrorsChanged(v);
            }
                       
        }

        public bool CanCreate => !_validator.HasErrors;

        public bool HasErrors => _validator.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _validator._propertiesErrors.GetValueOrDefault(propertyName, null);
        }


        private readonly Validator _validator;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ProductViewModel()
        {
            _validator = new Validator();
            _validator.ErrorsChanged += _validator_ErrorsChanged;
        }

        private void _validator_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using validation2.models;

namespace validation2.vms
{
    public class ProductsVM : ChangeNotifier, INotifyDataErrorInfo
    {

        private readonly ErrorsNotifier _en;

        public bool HasErrors => _en.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _en._propertysErrors.GetValueOrDefault(propertyName, null);
        }


        public ProductsVM()
        {
            _en = new ErrorsNotifier();
            _en.ErrorsChanged += _en_ErrorsChanged;
        }

        private void _en_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value; OnPropertyChanged();
                ClearErrors(nameof(Id));
                if (value > 10)
                {
                    _en.AddErrors(nameof(Id), "Id should not be more than 10");
                } 
            }
        }

        private void ClearErrors(string v)
        {
            if (_en._propertysErrors.Remove(v))
            {
                _en.OnErrorChanged(v);
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
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
            set { price = value; OnPropertyChanged(); }
        }



        public bool CanCreate => !HasErrors;
    }
}

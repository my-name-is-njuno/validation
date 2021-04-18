using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using valid3.notifiers;

namespace valid3.vms
{
    public class ProductVM : ChangeNotifier, INotifyDataErrorInfo
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                errorNotifier.ClearErrors(nameof(Name));
                name = value; OnPropertyChanged(); 
                if (value.StartsWith("a"))
                {
                    errorNotifier.AddErrors(nameof(Name), "Name should not start with a");
                } 
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                errorNotifier.ClearErrors(nameof(Id));
                id = value; OnPropertyChanged(); 
                if (id > 10)
                {
                    errorNotifier.AddErrors(nameof(Id), "Id should not be more than 10");
                } 
            }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                errorNotifier.ClearErrors(nameof(Description));
                description = value; OnPropertyChanged(); 
                if (value.Length <  5)
                {
                    errorNotifier.AddErrors(nameof(Description), "Description should be more than 5 characters");
                } 
            }
        }



        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                errorNotifier.ClearErrors(nameof(Price));
                price = value; OnPropertyChanged(); 
                if (value > 50)
                {
                    errorNotifier.AddErrors(nameof(Price), "This is not moi avenue");
                }
            }
        }


        public ProductVM()
        {
            errorNotifier = new ErrorNotifier();
            errorNotifier.ErrorsChanged += ErrorNotifier_ErrorsChanged;
        }




        public bool CanCreate => !HasErrors;


        public bool HasErrors => errorNotifier.HasErrors;

        private ErrorNotifier errorNotifier;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        

        public IEnumerable GetErrors(string propertyName)
        {
            return errorNotifier.GetErrors(propertyName);
        }

        private void ErrorNotifier_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}

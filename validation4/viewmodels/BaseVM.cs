using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using validation4.notifiers;

namespace validation4.viewmodels
{
    public delegate BaseVM CreateVM<BaseVM>();

    public class BaseVM : ChangeNotifier, INotifyDataErrorInfo
    {
        public ErrorNotifier ErrorNotifier = new ErrorNotifier();

        public bool HasErrors => ErrorNotifier.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorNotifier.GetErrors(propertyName);
        }
    }
}

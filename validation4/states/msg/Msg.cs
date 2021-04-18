using System;
using System.Collections.Generic;
using System.Text;
using validation4.notifiers;

namespace validation4.states.msg
{
    public class Msg : ChangeNotifier, IMsg
    {

        public bool HasMessage => !(string.IsNullOrEmpty(Error)) || !(string.IsNullOrEmpty(Success)) || !(string.IsNullOrEmpty(Info)) ;


        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasMessage)); }
        }

        private string _success;

        public string Success
        {
            get { return _success; }
            set { _success = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasMessage)); }
        }


        private string _info;

        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasMessage)); }
        }

       
    }
}

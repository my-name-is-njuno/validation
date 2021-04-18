using System;
using System.Collections.Generic;
using System.Text;

namespace validation4.states.msg
{
    public interface IMsg
    {
        bool HasMessage { get;  }
        string Error { get; set; }
        string Success { get; set; }
        string Info { get; set; }
    }
}

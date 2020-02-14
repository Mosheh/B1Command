using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Domain
{
    public interface ISAPCommand
    {
        void Send(string command);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Domain
{
    public interface IRepository
    {
        string ExistsItem(string name);
        string ExistsBusinessPartner(string name);
        
    }
}

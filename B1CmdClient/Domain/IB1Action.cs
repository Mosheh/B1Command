using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Domain
{
    public interface IB1Action
    {
        void OpenItem(string itemCodeOrName);
        void OpenBusinessParnter(string codeOrName);
        void OpenStock(string itemCodeOrName);
    }
}

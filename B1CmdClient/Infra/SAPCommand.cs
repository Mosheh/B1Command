using B1CmdClient.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Infra
{
    public class SAPCommand : ISAPCommand
    {
        public void Send(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;


        }
    }
}

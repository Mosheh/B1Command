using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Data
{
    public static class SAPConnection
    {
        public static void Init(SAPbobsCOM.Company company, Application application)
        {
            Company = company;
            Application = application;
        }
        public static SAPbobsCOM.Company Company{ get; set; }
        public static Application Application { get; set; }
    }
}

using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient
{
    public class Start
    {
        public static void Init()
        {
            SboGuiApi sboGuiApi = new SboGuiApi();

            sboGuiApi.Connect(Config.ConnectionStringSAP);
            var app = sboGuiApi.GetApplication();

            var company = app.Company.GetDICompany() as SAPbobsCOM.Company;

            Data.SAPConnection.Init(company, app);
        }
    }
}

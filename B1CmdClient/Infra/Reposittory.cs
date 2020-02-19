using B1CmdClient.Data;
using B1CmdClient.Domain;
using B1CmdClient.Extentions;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B1CmdClient.Infra
{
    public class Reposittory : IRepository
    {
        public string ExistsBusinessPartner(string name)
        {
            var recordset = SAPConnection.Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset) as Recordset;
            var sql= $"select \"CardCode\" from OCRD where \"CardName\" like '%{name}%'";            
            var result = recordset.ExecuteSQL(sql);

            if (result != null && result.Count > 0)
                return result[0].ToList().LastOrDefault().Value.ToString();
            else
                return string.Empty;
        }

        public string ExistsItem(string name)
        {
            var recordset = SAPConnection.Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset) as Recordset;

            var result = recordset.ExecuteSQL($"select \"ItemCode\" from OITM where \"ItemName\" like '%{name}%'");

            if (result !=null &&  result.Count > 0)
                return result[0].ToList().LastOrDefault().Value.ToString();
            else
                return string.Empty;
        }
    }
}

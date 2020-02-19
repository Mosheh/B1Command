using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace B1CmdClient.Extentions
{
    public static class Extention
    {
        public static List<Dictionary<string, object>> ExecuteSQL(this SAPbobsCOM.Recordset recordset, string sqlCommand) 
        {
            recordset.DoQuery(sqlCommand);

            var list = new List<Dictionary<string, object>>();

            recordset.MoveFirst();
            while (!recordset.EoF)
            {
                Dictionary<string, object> record = new Dictionary<string, object>();
                for (int i = 0; i < recordset.Fields.Count; i++)
                {
                    record.Add(recordset.Fields.Item(i).Name, recordset.Fields.Item(i).Value);
                }

                list.Add(record);

                recordset.MoveNext();
            }


            return list;
        }

        public static void ActiveMenu(this Application application, string menuId)
        {
            var menu  = application.Menus.Item(menuId) as MenuItem;
            menu.Activate();
        }
    }
}

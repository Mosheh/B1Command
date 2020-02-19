using B1CmdClient.Data;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Infra
{
    public class BusinessPartnerCommand
    {
        public void OpenFormBusinessPartnerDataByCardCode(string cardCode)
        {
            var menuItem = SAPConnection.Application.Menus.Item("2561");

            _IApplicationEvents_ItemEventEventHandler task = (string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent) =>
            {
                BubbleEvent = true;

                if (((pVal.FormType == 134 && pVal.EventType == BoEventTypes.et_FORM_LOAD) && (pVal.Before_Action == true)))
                {
                    var form = SAPConnection.Application.Forms.GetFormByTypeAndCount(134, pVal.FormTypeCount);

                    var editText = form.Items.Item("5").Specific as EditText;
                    editText.Value = cardCode;

                    var button = form.Items.Item("1").Specific as Button;
                    button.Item.Click(BoCellClickType.ct_Regular);
                };
            };

            SAPConnection.Application.ItemEvent += task;

            menuItem.Activate();

        }
    }
}

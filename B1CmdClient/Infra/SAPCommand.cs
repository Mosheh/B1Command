using B1CmdClient.Data;
using B1CmdClient.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Infra
{
    public class SAPCommand : ISAPCommand
    {
        public void Send(string textCommand)
        {
            if (string.IsNullOrEmpty(textCommand))
                return;

            var command = DictionaryCommands.Instance.Context(textCommand);

            if (command == AllCommands.None)
                return;

            switch (command)
            {
                case AllCommands.None:
                    break;
                case AllCommands.ShowBusinessPartnerData:
                    var parameters = DictionaryCommands.Instance.GetParameter(textCommand);
                    var cardCode = new Reposittory().ExistsBusinessPartner(parameters);
                    if (string.IsNullOrEmpty(cardCode))
                        return;
                    new BusinessPartnerCommand().OpenFormBusinessPartnerDataByCardCode(cardCode);

                    break;
                case AllCommands.ShowItemData:
                    var itemParameters = DictionaryCommands.Instance.GetParameter(textCommand);
                    var itemCode = new Reposittory().ExistsItem(itemParameters);
                    if (string.IsNullOrEmpty(itemCode))
                        return;

                    new ItemCommand().OpenFormItemByItemCode(itemCode);

                    break;
                case AllCommands.ShowStockItem:
                    break;
                case AllCommands.ShowSalesItemOpen:
                    break;
                case AllCommands.ShowPurchaseItemOpen:
                    break;
                case AllCommands.CloseAllWindows:
                    SAPConnection.Application.ActivateMenuItem("1026");
                    break;
                default:
                    break;
            }
        }
    }
}

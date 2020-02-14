using System;
using System.Collections.Generic;
using System.Text;

namespace B1CmdClient.Domain
{
    public enum AllCommands
    {
        ShowBusinessPartnerData,
        ShowItemData,
        ShowStockItem,

    }

    public class DictionaryCommands : Dictionary<AllCommands, string>
    {
        public DictionaryCommands()
        {
            this.Add(AllCommands.ShowStockItem, "item, produto, dados, estoque, informação");
            this.Add(AllCommands.ShowBusinessPartnerData, "cliente, fornecedor, parceiro, dados, informação");
            this.Add(AllCommands.ShowStockItem, "estoque, depósito");
        }
    }
}

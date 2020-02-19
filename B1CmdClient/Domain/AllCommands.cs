using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B1CmdClient.Domain
{
    public enum AllCommands
    {
        None,
        CloseAllWindows,
        ShowBusinessPartnerData,
        ShowItemData,
        ShowStockItem,
        ShowSalesItemOpen,
        ShowPurchaseItemOpen,
    }

    public class DictionaryCommands : Dictionary<AllCommands, string>
    {
        public DictionaryCommands()
        {
            this.Add(AllCommands.CloseAllWindows, "fechar tela, fechas todas as telas, fechar tudo");
            this.Add(AllCommands.ShowItemData, "item, produto, dados, estoque, informação");
            this.Add(AllCommands.ShowBusinessPartnerData, "cliente, fornecedor, parceiro, dados, informação");
            this.Add(AllCommands.ShowStockItem, "estoque, depósito");
            this.Add(AllCommands.ShowSalesItemOpen, "item venda, vendas abertas");
            this.Add(AllCommands.ShowPurchaseItemOpen, "item compra, compras abertas");
        }

        static DictionaryCommands _dictionary;
        public static DictionaryCommands Instance
        {
            get
            {
                if (_dictionary == null)
                    _dictionary = new DictionaryCommands();

                return _dictionary;
            }
        }

        public AllCommands Context(string command)
        {
            AllCommands allCommands = AllCommands.None;

            var result = new Dictionary<AllCommands, int>();
            foreach (AllCommands item in Enum.GetValues(typeof(AllCommands)))
            {
                result.Add(item, 0);
            }

            foreach (var item in command.Split(' '))
            {
                foreach (var current in DictionaryCommands.Instance)
                {
                    if (current.Value.Contains(item))
                    {
                        result[current.Key] += 1;

                    }
                }
            }

            var maxVotes = result.ToList().Max(c => c.Value);
            var winner = result.ToList().FirstOrDefault(c => c.Value == maxVotes);

            allCommands = winner.Key;

            return allCommands;
        }

        public string GetParameter(string command)
        {
            var result = new Dictionary<string, int>();
            command.Split(' ').ToList().ForEach(c => { result.Add(c, 0); });

            foreach (var item in command.Split(' '))
            {
                foreach (var current in DictionaryCommands.Instance)
                {
                    if (!current.Value.Contains(item))
                    {
                        result[item] += 1;
                    }
                }
            }

            var winner = result.ToList().LastOrDefault(c => c.Value == result.ToList().Max(c => c.Value));

            return winner.Key;

        }
    }
}

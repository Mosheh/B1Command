using B1CmdClient.Domain;
using B1CmdClient.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace B1CmdClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemCommand()
        {
            Start.Init();

            string commandText = "Abrir item energia";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }

        [TestMethod]
        public void ItemFormCommand()
        {
            Start.Init();

            string commandText = "item";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }

        [TestMethod]
        public void PartnerDataCommand()
        {
            Start.Init();

            string commandText = "dados do cliente advogados";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }

        [TestMethod]
        public void PartnerFormCommand()
        {
            Start.Init();

            string commandText = "cliente";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }

        [TestMethod]
        public void PartnerDataCommand2()
        {
            Start.Init();

            string commandText = "cliente moisés";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }

        [TestMethod]
        public void CloseAllScreen()
        {
            Start.Init();

            string commandText = "fechar telas";

            ISAPCommand sapCommand = new SAPCommand();

            sapCommand.Send(commandText);
        }
    }
}

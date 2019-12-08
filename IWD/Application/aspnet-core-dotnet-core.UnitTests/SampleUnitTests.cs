using aspnet_core_dotnet_core.Controllers;
using aspnet_core_dotnet_core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace aspnet_core_dotnet_core.UnitTests
{
    [TestClass]
    public class SampleUnitTests
    {
        [TestMethod]
        public void IndexPageTest()
        {
            var controller = new HomeController();
            Assert.AreEqual(null, controller.ViewData["Message"]);
        }

        [TestMethod]
        public void AlgorithmDefaultTest()
        {
            var controller = new GameController();

            var mapModel = new MapModel
            {
                FirstRow = new FirstRow { FirstColumn = "X", SecondColumn = "", ThirdColumn = "" },
                SecondRow = new SecondRow { FirstColumn = "", SecondColumn = "", ThirdColumn = "" },
                ThirdRow = new ThirdRow { FirstColumn = "", SecondColumn = "", ThirdColumn = "" }
            };
            var gameRequest = new GameRequest { ChosenAlgorithm = "Null", MapModel = mapModel, AiSign = "O" };
            var result = controller.Post(gameRequest).Result;
            mapModel.FirstRow.SecondColumn = "O";
            Assert.AreEqual(result, mapModel);
        }

        [TestMethod]
        public void AlgorithmDefaultNullTest()
        {
            var controller = new GameController();
            var gameRequest = new GameRequest { ChosenAlgorithm = "Null", MapModel = null, AiSign = "O" };
            Assert.ThrowsException<AggregateException>(() => controller.Post(gameRequest).Result);

        }

        [TestMethod]
        public void AlgorithmDefaultEmptyTest()
        {
            var controller = new GameController();
            var mapModel = new MapModel
            {
                FirstRow = new FirstRow { FirstColumn = null, SecondColumn = null, ThirdColumn = null },
                SecondRow = new SecondRow { FirstColumn = null, SecondColumn = null, ThirdColumn = null },
                ThirdRow = new ThirdRow { FirstColumn = null, SecondColumn = null, ThirdColumn = null }
            };
            var gameRequest = new GameRequest { ChosenAlgorithm = "Null", MapModel = mapModel, AiSign = "O" };
            Assert.ThrowsException<AggregateException>(() => controller.Post(gameRequest).Result);
        }

        [TestMethod]
        public void AlgorithmMinMaxTest()
        {
            var controller = new GameController();
            var mapModel = new MapModel
            {
                FirstRow = new FirstRow { FirstColumn = "", SecondColumn = "", ThirdColumn = "" },
                SecondRow = new SecondRow { FirstColumn = "", SecondColumn = "X", ThirdColumn = "" },
                ThirdRow = new ThirdRow { FirstColumn = "", SecondColumn = "", ThirdColumn = "" }
            };
            var gameRequest = new GameRequest { ChosenAlgorithm = "MinMax", MapModel = mapModel, AiSign = "O" };
            var result = controller.Post(gameRequest).Result;
            mapModel.FirstRow.SecondColumn = "O";
            Assert.AreEqual(result, mapModel);
        }

        [TestMethod]
        public void AlgorithmMinMaxNullTest()
        {
            var controller = new GameController();
            var mapModel = new MapModel
            {
                FirstRow = new FirstRow { FirstColumn = "", SecondColumn = "", ThirdColumn = "" },
                SecondRow = new SecondRow { FirstColumn = "", SecondColumn = "X", ThirdColumn = "" },
                ThirdRow = new ThirdRow { FirstColumn = "", SecondColumn = null, ThirdColumn = "" }
            };
            var gameRequest = new GameRequest { ChosenAlgorithm = "MinMax", MapModel = mapModel, AiSign = "O" };
            Assert.ThrowsException<AggregateException>(() => controller.Post(gameRequest).Result);
        }
    }
}
using System;
using TicTac;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTac.Tests {
    [TestClass]
    public class BoardTests {

        [TestMethod]
        public void testThatWidthAndHeightAreSame() {
            var board = new Board(3);
            Assert.AreEqual(board.Count, board[0].Count);
        }

        [TestMethod]
        public void testBoardIsEmpty()
        {
            string jsonData = System.IO.File.ReadAllText("Data/empty-board.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isEmpty());
            Assert.IsTrue(board.isValid());
        }
    }
}

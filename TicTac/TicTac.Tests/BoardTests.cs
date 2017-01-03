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
            Assert.AreEqual(board.getState().xWinCount, 0);
            Assert.AreEqual(board.getState().oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsRight()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-right-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsLeft()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-left-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsBottom()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-bottom-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsTop()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-top-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsLeftDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-left-diagonal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsRightDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-right-diagonal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsMiddleVertical()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-middle-vertical-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void testXWinsMiddleHorizontal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-middle-horizontal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }
    }
}

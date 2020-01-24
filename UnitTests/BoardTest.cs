using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongLibrary;

namespace UnitTests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // arrange
            Board board = new Board(820,400);

            // act
            int width = 400;
            int height = 820;

            // assert
            Assert.AreEqual(board.BoardWidth, width);
            Assert.AreEqual(board.BoardHeight, height);

        }
    }
}

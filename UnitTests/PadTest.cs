using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongLibrary;

namespace UnitTests
{
    [TestClass]
    public class PadTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // arrange
            Pad pad = new Pad(50,10,10);

            // act
            int padPosition = 50;
            int padWidth = 10;
            int padSpeed = 10;

            // assert
            Assert.AreEqual(pad.PadPosition, padPosition);
            Assert.AreEqual(pad.Width, padWidth);
            Assert.AreEqual(pad.PadSpeed, padSpeed);

        }

        [TestMethod]
        public void ComputerConstructorTest()
        {
            // arrange
            ComputerPad computerPad = new ComputerPad(50);

            // act
            int padPosition = 50;
            int padWidth = 10;
            int padSpeed = 10;
            int difficulty = 3;


            // assert
            Assert.AreEqual(computerPad.PadPosition, padPosition);
            Assert.AreEqual(computerPad.Width, padWidth);
            Assert.AreEqual(computerPad.PadSpeed, padSpeed);
            Assert.AreEqual(computerPad.Difficulty, difficulty);

        }

        [TestMethod]
        public void MoveUpTest()
        {
            // arrange
            Pad pad = new Pad(50, 10, 10);

            // act
            int padPosition = pad.PadPosition;
            int newPadPosition = pad.MoveUp();

            // assert
            Assert.AreEqual(newPadPosition, padPosition-pad.PadSpeed);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            // arrange
            Pad pad = new Pad(50, 10, 10);

            // act
            int padPosition = pad.PadPosition;
            int newPadPosition = pad.MoveDown();

            // assert
            Assert.AreEqual(newPadPosition, padPosition + pad.PadSpeed);
            
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongLibrary;

namespace UnitTests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // arrange
            Game game = new Game(400, 820);

            // act
            Pad playerPad = new Pad(180);
            ComputerPad computerPad = new ComputerPad(180);
            Ball ball = new Ball((820 / 2 - 15), (400 / 2 - 15));
            byte playerPoints = 0;
            byte computerPoints = 0;
            bool gameActive = false;

            // assert
            Assert.AreEqual(game.PlayerPadPosition, playerPad.PadPosition);
            Assert.AreEqual(game.PlayerPadWidth, playerPad.Width);
            Assert.AreEqual(game.ComputerPadPosition, computerPad.PadPosition);
            Assert.AreEqual(game.ComputerPadWidth, computerPad.Width);
            Assert.AreEqual(game.BallPositionX, ball.BallPositionX);
            Assert.AreEqual(game.BallPositionY, ball.BallPositionY);
            Assert.AreEqual(game.PlayerPoints, playerPoints);
            Assert.AreEqual(game.ComputerPoints, computerPoints);
            Assert.AreEqual(game.GameActive, gameActive);

        }

        [TestMethod]
        public void MovePlayerPadUpTest()
        {
            // arrange
            Game game = new Game(400, 820);

            // act
            int padPosition = game.PlayerPadPosition;
            game.MovePlayerPad(1);

            // assert
            Assert.AreEqual(game.PlayerPadPosition, padPosition - 10);
        }

        [TestMethod]
        public void MovePlayerPadDownTest()
        {
            // arrange
            Game game = new Game(400, 820);

            // act
            int padPosition = game.PlayerPadPosition;
            game.MovePlayerPad(0);

            // assert
            Assert.AreEqual(game.PlayerPadPosition, padPosition + 10);
        }

        [TestMethod]
        public void VerifyBoundsTest()
        {
            // arrange
            Game game = new Game(400, 820);

            // act
            int padPosition = game.PlayerPadPosition = 0;
            game.MovePlayerPad(1);

            // assert
            Assert.AreEqual(game.PlayerPadPosition, padPosition);
        }

        [TestMethod]
        public void AddPointsTest()
        {
            // arrange
            Game game = new Game(600, 820);

            // act
            game.GameActive = true;
            game.PlayerPadPosition = 0;
            game.ComputerPadPosition = 0;

            game.BallPositionY = 500;
            game.BallPositionX = 0;
            game.MoveBall();
            game.GameActive = true;
            game.BallPositionY = 500;
            game.BallPositionX = 0;
            game.MoveBall();
            game.BallPositionY = 500;
            game.BallPositionX = 790;
            game.GameActive = true;
            game.MoveBall();

            // assert
            Assert.AreEqual(1, game.PlayerPoints);
            Assert.AreEqual(2, game.ComputerPoints);
        }
    }
}

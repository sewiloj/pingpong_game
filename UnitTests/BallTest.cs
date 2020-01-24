using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongLibrary;

namespace UnitTests
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // arrange
            Ball ball = new Ball(385, 230, 3, 3);

            // act
            int ballPositionX = 385;
            int ballPositionY = 230;
            byte ballSpeedX = 3;
            byte ballSpeedY = 3;

            // assert
            Assert.AreEqual(ball.BallPositionX, ballPositionX);
            Assert.AreEqual(ball.BallPositionY, ballPositionY);
            Assert.AreEqual(ball.BallSpeedX, ballSpeedX);
            Assert.AreEqual(ball.BallSpeedY, ballSpeedY);

        }

        [TestMethod]
        public void ChangeDirectionXTest()
        {
            // arrange
            Ball ball = new Ball(385, 230, 3, 3);

            // act
            int ballDirectionX = ball.BallDirectionX;
            ball.ChangeDirectionX();

            // assert
            Assert.AreNotEqual(ball.BallDirectionX, ballDirectionX);
        }

        [TestMethod]
        public void ChangeDirectionYTest()
        {
            // arrange
            Ball ball = new Ball(385, 230, 3, 3);

            // act
            int ballDirectionY = ball.BallDirectionY;
            ball.ChangeDirectionY();

            // assert
            Assert.AreNotEqual(ball.BallDirectionY, ballDirectionY);
        }

        [TestMethod]
        public void ResetPositionTest()
        {
            // arrange
            Ball ball = new Ball(200, 400, 3, 3);

            // act
            int ballPositionX = ball.BallPositionX;
            int ballPositionY = ball.BallPositionY;
            ball.ResetPosition();

            // assert
            Assert.AreNotEqual(ball.BallDirectionY, ballPositionX);
            Assert.AreNotEqual(ball.BallDirectionY, ballPositionY);
        }

        [TestMethod]
        public void CheckCollistionLeftTrueTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            //!leftCollision && BallPositionX <= playerPadWidth && (BallPositionY + 30 >= playerPadPosition && BallPositionY <= playerPadPosition + 100)
            ball.BallPositionX = 5;
            ball.BallPositionY = 150;
            bool checkCollision = ball.CheckCollision(100,10,100,10,400,820);

            // assert
            Assert.IsTrue(checkCollision);
        }

        [TestMethod]
        public void CheckCollistionRightTrueTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            //!rightCollision && BallPositionX + 30 >= boardWidth - computerPadWidth && (BallPositionY + 30 >= computerPadPosition && BallPositionY <= computerPadPosition + 100)
            ball.BallPositionX = 800;
            ball.BallPositionY = 150;
            bool checkCollision = ball.CheckCollision(100, 10, 100, 10, 400, 820);

            // assert
            Assert.IsTrue(checkCollision);
        }

        [TestMethod]
        public void CheckCollistionFalseTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            //!rightCollision && BallPositionX + 30 >= boardWidth - computerPadWidth && (BallPositionY + 30 >= computerPadPosition && BallPositionY <= computerPadPosition + 100)
            ball.BallPositionX = 400;
            ball.BallPositionY = 150;
            bool checkCollision = ball.CheckCollision(100, 10, 100, 10, 400, 820);

            // assert
            Assert.IsFalse(checkCollision);
        }

        [TestMethod]
        public void CheckBallOutTrueTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            ball.BallPositionX = 0;
            ball.BallPositionY = 150;
            bool checkBallOut = ball.CheckBallOut(820, 10, 10 );

            // assert
            Assert.IsTrue(checkBallOut);
        }

        [TestMethod]
        public void CheckBallOutFalseTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            ball.BallPositionX = 11;
            ball.BallPositionY = 150;
            bool checkBallOut = ball.CheckBallOut(820, 10, 10);

            // assert
            Assert.IsFalse(checkBallOut);
        }

        [TestMethod]
        public void CheckWallCollisionTopTrueTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            ball.BallPositionX = 11;
            ball.BallPositionY = 0;
            bool checkWallCollision = ball.CheckWallCollision(400);

            // assert
            Assert.IsTrue(checkWallCollision);
        }

        [TestMethod]
        public void CheckWallCollisionBottomTrueTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            ball.BallPositionX = 11;
            ball.BallPositionY = 400;
            bool checkWallCollision = ball.CheckWallCollision(400);

            // assert
            Assert.IsTrue(checkWallCollision);
        }

        [TestMethod]
        public void CheckWallCollisionFalseTest()
        {
            // arrange
            Ball ball = new Ball();

            // act
            ball.BallPositionX = 11;
            ball.BallPositionY = 369;
            bool checkWallCollision = ball.CheckWallCollision(400);

            // assert
            Assert.IsFalse(checkWallCollision);
        }
    }
}

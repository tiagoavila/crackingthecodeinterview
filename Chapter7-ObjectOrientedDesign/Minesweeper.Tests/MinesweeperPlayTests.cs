using Minesweeper.Core.Entities;
using NUnit.Framework;

namespace Minesweeper.Tests
{
    public class MinesweeperPlayTests
    {
        private Board board = new(_boardSize, _numberOfBombs);
        private const int _boardSize = 8;
        private const int _numberOfBombs = 10;

        [SetUp]
        public void Setup()
        {
            //board = new Board(_boardSize, _numberOfBombs);
        }

        [Test]
        public void BrandNewBoardIsNotNull()
        {
            Assert.IsNotNull(board);
        }

        [Test]
        public void InitializedBoard()
        {
            board.InitializeBoard();
            Assert.IsNotNull(board);
        }
    }
}
using NUnit.Framework;
using Othello.Entities;
using Othello.Enums;

namespace Othello.Tests
{
    public class OthelloPlayTests
    {
        private const string expectedInitializedBoardString = "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B W - - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ";
        private Board _board = new();

        [SetUp]
        public void Setup()
        {            
            _board.InitializeBoard();
        }

        [Test]
        public void InitializedBoardShouldHave2BlackAnd2WhitePieces()
        {
            Assert.IsNotNull(_board.Pieces[0, 0]);

            string boardAsString = _board.GetBoardPiecesAsString();

            Assert.AreEqual(expectedInitializedBoardString, boardAsString);
        }

        [Test]
        public void CantInsertPieceInASpotOnlySurroundedByEmptySpots()
        {
            Assert.IsFalse(_board.PlaceColor(0, 0, PieceColorEnum.Black));
            Assert.IsFalse(_board.PlaceColor(1, 1, PieceColorEnum.Black));
            Assert.IsFalse(_board.PlaceColor(1, 1, PieceColorEnum.White));
        }

        [Test]
        public void CantInsertBlackPieceOnTheSideOfAnotherOne()
        {
            Assert.IsFalse(_board.PlaceColor(3, 2, PieceColorEnum.Black));
            Assert.IsFalse(_board.PlaceColor(2, 3, PieceColorEnum.Black));
            Assert.IsFalse(_board.PlaceColor(5, 4, PieceColorEnum.Black));
            Assert.IsFalse(_board.PlaceColor(4, 5, PieceColorEnum.Black));
        }

        [Test]
        public void CantInsertWhitePieceOnTheSideOfAnotherOne()
        {
            Assert.IsFalse(_board.PlaceColor(2, 4, PieceColorEnum.White));
            Assert.IsFalse(_board.PlaceColor(4, 2, PieceColorEnum.White));
            Assert.IsFalse(_board.PlaceColor(5, 3, PieceColorEnum.White));
            Assert.IsFalse(_board.PlaceColor(3, 5, PieceColorEnum.White));
        }

        [TestCase(5, 3, PieceColorEnum.Black, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B W - - - | - - - B B - - - | - - - B - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(2, 4, PieceColorEnum.Black, "- - - - - - - - | - - - - - - - - | - - - - B - - - | - - - B B - - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(4, 2, PieceColorEnum.Black, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B W - - - | - - B B B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(3, 5, PieceColorEnum.Black, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B B B - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(5, 4, PieceColorEnum.White, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B W - - - | - - - W W - - - | - - - - W - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(2, 3, PieceColorEnum.White, "- - - - - - - - | - - - - - - - - | - - - W - - - - | - - - W W - - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(3, 2, PieceColorEnum.White, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - W W W - - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        [TestCase(4, 5, PieceColorEnum.White, "- - - - - - - - | - - - - - - - - | - - - - - - - - | - - - B W - - - | - - - W W W - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ")]
        public void AllPossibleInitialMovementsSetTheBoardCorrectly(int row, int column, PieceColorEnum color, string expectedBoardString)
        {
            _board.PlaceColor(row, column, color);

            Assert.AreEqual(expectedBoardString, _board.GetBoardPiecesAsString());

            _board.InitializeBoard();
        }

        [Test]
        public void PossibleSetOfMovementsSetTheBoardCorrectly()
        {
            _board.PlaceColor(3, 5, PieceColorEnum.Black);
            _board.PlaceColor(2, 3, PieceColorEnum.White);
            _board.PlaceColor(3, 2, PieceColorEnum.Black);

            string expectedBoardString = "- - - - - - - - | - - - - - - - - | - - - W - - - - | - - B B B B - - | - - - W B - - - | - - - - - - - - | - - - - - - - - | - - - - - - - - ";
            Assert.AreEqual(expectedBoardString, _board.GetBoardPiecesAsString());
        }
    }
}
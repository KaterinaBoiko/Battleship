using System;
using System.Collections.Generic;
using Battleship.Classes;
using Battleship.Enums;
using Battleship.Interfaces;
using Battleship.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle.Enums;

namespace Battleship.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Throw_WhenBoardSizeIsLessThanZero()
        {
            // arrange
            var size = -1;

            // act
            var sut = new Board(size);
        }

        [TestMethod]
        public void Constructor_Created_WhenSizeIsValid()
        {
            // arrange
            int size = 7;

            // act
            var sut = new Board(size);

            //assert
            Assert.AreEqual(sut.Size, size);
        }

        [TestMethod]
        public void GenerateBoard_GeneratedBoard_SecondItemInCellsListIsNotNull()
        {
            //act
            var size = 9;

            //act
            var sut = new Board(size);

            //assert
            Assert.IsNotNull(sut._cells[1]);
        }

        [TestMethod]
        public void AddShip_AddedShip_ShipsCountIsOne()
        {
            //act
            var size = 8;
            var deckNumber = 2;
            var cells = new List<ICell>();
            var direction = Directions.Horizontally;

            // act
            var ship = new Ship(deckNumber, cells, direction);
            var sut = new Board(size);
            sut.AddShip(ship);

            //assert
            Assert.AreEqual(sut._ships.Count, 1);
        }

        [TestMethod]
        public void RemoveShip_RemovedShip_ShipsCountIsOne()
        {
            //act
            var size = 8;
            var deckNumber = 2;
            var cells = new List<ICell>();
            var direction = Directions.Horizontally;

            // act
            var ship1 = new Ship(deckNumber, cells, direction);
            var ship2 = new Ship(deckNumber, cells, direction);
            var sut = new Board(size);
            sut.AddShip(ship1);
            sut.AddShip(ship2);
            sut.RemoveShip(ship2);

            //assert
            Assert.AreEqual(sut._ships.Count, 1);
        }

        [TestMethod]
        public void HitTheCell_HittedCell00_NewStatusIsOnFire()
        {
            //act
            var size = 8;
            var deckNumber = 2;
            var direction = Directions.Horizontally;
            var cell = Cell.New(Position.New(0, 0));
            var cells = new List<ICell>() { cell };

            // act
            var ship = new Ship(deckNumber, cells, direction);
            var board = new Board(size);
            board.AddShip(ship);
            board.HitTheCell(cell);

            //assert
            Assert.AreEqual(board._cells[0].State, State.OnFire);
        }

    }
}

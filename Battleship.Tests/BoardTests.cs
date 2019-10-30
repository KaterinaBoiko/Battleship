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
            var fcell = Cell.New(Position.New(0, 0));
            var direction = Directions.Horizontally;

            // act
            var ship = new Ship(deckNumber, fcell, direction);
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
            var fcell = Cell.New(Position.New(0, 0));
            var direction = Directions.Horizontally;

            // act
            var ship1 = new Ship(deckNumber, fcell, direction);
            var ship2 = new Ship(deckNumber, fcell, direction);
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

            // act
            var ship = new Ship(deckNumber, cell, direction);
            var board = new Board(size);
            board.AddShip(ship);
            board.HitTheCell(cell);

            //assert
            Assert.AreEqual(board._cells[0].State, State.OnFire);
        }

        [TestMethod]
        public void FindCell_FindCell01_CellStatusBusy()
        {
            //act
            var size = 8;
            var deckNumber = 2;
            var direction = Directions.Horizontally;
            var cell = Cell.New(Position.New(0, 1));

            // act
            var ship = new Ship(deckNumber, cell, direction);
            var board = new Board(size);
            board.AddShip(ship);

            //assert
            Assert.AreEqual(board.FindCell(cell.Position).State, State.Busy);
        }

        [TestMethod]
        public void GetCellsOnFire_FindAllCellsOnFire_AllFoundCellStatesIsOnFire()
        {
            //act
            var size = 8;
            var cell1 = Cell.New(Position.New(0, 1));
            var cell2 = Cell.New(Position.New(1, 2));

            // act
            var board = new Board(size);
            board.FindCell(cell1.Position).SetState(State.OnFire);
            board.FindCell(cell2.Position).SetState(State.OnFire);

            //assert
            foreach (ICell cell in board.GetCellsOnFire())
            {
                Assert.AreEqual(cell.State, State.OnFire);
            }
        }

        [TestMethod]
        public void GetCellsInDirection_FindAllCellsInDirection_AllCellInDirectionIsCorrect()
        {
            //act
            var size = 8;
            var deckNumber = 3;
            var direction = Directions.Horizontally;
            var cell = Cell.New(Position.New(0, 0));
            int x = 0;

            // act
            var ship = new Ship(deckNumber, cell, direction);
            var board = new Board(size);
            board.AddShip(ship);

            //assert
            foreach (ICell c in board.GetCellsInDirection(cell, deckNumber, direction))
            {
                Assert.AreEqual(c.Position, Position.New(x, 0));
                x++;
            }
        }

    }
}

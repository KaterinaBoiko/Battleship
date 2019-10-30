using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Classes;
using Battleship.Enums;
using Battleship.Interfaces;
using Battleship.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class ShipTests
    {
        #region Throw

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Throw_WhenDeckNumberIsLessThanZero()
        {
            // arrange
            var deckNumber = -1;
            var fcell = Cell.New(Position.New(0, 0));
            var direction = Directions.Horizontally;

            // act
            var sut = new Ship(deckNumber, fcell, direction);
        }
        #endregion

        [TestMethod]
        public void Constructor_Created_WhenDeckNumberIsValid()
        {
            // arrange
            var deckNumber = 2;
            var fcell = Cell.New(Position.New(0, 0));
            var direction = Directions.Horizontally;

            // act
            var sut = new Ship(deckNumber, fcell, direction);

            //assert
            Assert.AreEqual(sut.DeckNumber, deckNumber);
            Assert.AreEqual(sut.FirstCell, fcell);
            Assert.AreEqual(sut.Direction, direction);
        }
        

        //[TestMethod]
        //public void UpdateStatus_UpdateCellStatusToOnFire_NewStatusIsOnFire()
        //{
        //    //arange
        //    var deckNumber = 1;
        //    var cell = new Cell(Values.Position.New(0, 0));
        //    cell.SetState(SeaBattle.Enums.State.Busy);
        //    var cells = new List<ICell>() { cell };
        //    var direction = Directions.Horizontally;
        //    var newState = SeaBattle.Enums.State.OnFire;

        //    //act
        //    var sut = new Ship(deckNumber, cells, direction);
        //    sut.UpdateStatus(cell);

        //    //assert
        //    Assert.AreEqual(sut.Cells.First().State, newState);
        //}

        [TestMethod]
        public void ShipFactory_Created_Ship()
        {
            // arrange
            var deckNumber = 2;
            var fcell = Cell.New(Position.New(0, 0));
            var direction = Directions.Horizontally;
            var expectedShip = new Ship(deckNumber, fcell, direction);

            // act
            var sut = Ship.New(2, fcell, direction);

            //assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(Ship));
            Assert.AreEqual(sut, expectedShip);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace SudokuTesting
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            SudokuGrid grid = new SudokuGrid();

            int?[] arr =
               {
            4,3,5,2,6,9,7,8,1,
            6,8,2,5,7,1,4,9,3,
            1,9,7,8,3,4,5,6,null,
            8,2,6,1,9,5,3,4,7,
            3,7,4,6,8,2,9,1,5,
            9,5,1,7,4,3,6,2,8,
            5,1,9,3,2,6,8,7,4,
            2,4,8,9,5,7,1,3,6,
            7,6,3,4,1,8,2,5,null
            };
            grid.PopulateGrid(arr);

            //Act
            grid.Solve();

            //Assert
            //    {
            //4,3,5,2,6,9,7,8,1,
            //6,8,2,5,7,1,4,9,3,
            //1,9,7,8,3,4,5,6,2,
            //8,2,6,1,9,5,3,4,7,
            //3,7,4,6,8,2,9,1,5,
            //9,5,1,7,4,3,6,2,8,
            //5,1,9,3,2,6,8,7,4,
            //2,4,8,9,5,7,1,3,6,
            //7,6,3,4,1,8,2,5,9
            //};

            //Assert
            Assert.AreEqual(grid[3, 9], 2);
            Assert.AreEqual(grid[9, 9], 9);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CarDistanceGenerator;
using CarDistanceGenerator.Logics;
using CarDistanceGenerator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarDistanceGeneratorTests
{
    [TestClass]
    public class CarGeneratorLogic_Tests
    {
        public CarGeneratorLogic CarGeneratorLogic { get; set; }

        public CarGeneratorLogic_Tests()
        {
            CarGeneratorLogic = new CarGeneratorLogic();
        }

        [TestMethod]
        public void GetWorkDays_ReturnsListOfWorkDays_WhenMonthDateIsValid()
        {
            // Arrange
            var monthDate_test_1 = new MonthDate(6, 2018);
            var correctWorkDays_test_1 = new List<int>()
            {
                1,4,5,6,7,8,11,12,13,14,15,18,19,20,21,22,25,26,27,28,29
            };

            var monthDate_test_2 = new MonthDate(2, 2016);
            var correctWorkDays_test_2 = new List<int>()
            {
               1,2,3,4,5,8,9,10,11,12,15,16,17,18,19,22,23,24,25,26,29
            };

            // Act
            var workDays_test_1 = CarGeneratorLogic.GetWorkDays(monthDate_test_1);
            var workDays_test_2 = CarGeneratorLogic.GetWorkDays(monthDate_test_2);

            // Assert
            CollectionAssert.AreEqual(workDays_test_1.OrderBy(x => x).ToList(), correctWorkDays_test_1.OrderBy(x => x).ToList());
            CollectionAssert.AreEqual(workDays_test_2.OrderBy(x => x).ToList(), correctWorkDays_test_2.OrderBy(x => x).ToList());
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitTheBillLibrary;

namespace SplitTheBillTests
{
    [TestClass]
    public class split_the_bill_test
    {
        private split_the_bill splitter;

        [TestInitialize]
        public void Setup()
        {
            splitter = new split_the_bill();
        }

        [TestMethod]
        public void SplitAmount_EqualSplit_ReturnsCorrectAmount()
        {
            // Arrange
            decimal totalAmount = 100;
            int numberOfPeople = 5;

            // Act
            decimal splitAmount = splitter.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.AreEqual(20, splitAmount);
        }

        [TestMethod]
        public void SplitAmount_ZeroAmount_ThrowsArgumentException()
        {
            // Arrange
            decimal totalAmount = 0;
            int numberOfPeople = 5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.SplitAmount(totalAmount, numberOfPeople));
        }

        [TestMethod]
        public void SplitAmount_NegativeNumberOfPeople_ThrowsArgumentException()
        {
            // Arrange
            decimal totalAmount = 100;
            int numberOfPeople = -5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.SplitAmount(totalAmount, numberOfPeople));
        }

        [TestMethod]
        public void CalculateTip_EqualMealCosts_ReturnsEqualTipAmounts()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Person 1", 25.00m },
                { "Person 2", 25.00m },
                { "Person 3", 25.00m }
            };
            float tipPercentage = 10;
            decimal tolerance = 0.01m; // float

            // Act
            var tipByPerson = splitter.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(2.50m, tipByPerson["Person 1"], tolerance); 
            Assert.AreEqual(2.50m, tipByPerson["Person 2"], tolerance);
            Assert.AreEqual(2.50m, tipByPerson["Person 3"], tolerance);
        }

        [TestMethod]
        public void CalculateTip_ZeroTotalCost_ThrowsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Person 1", 0.00m },
                { "Person 2", 0.00m },
                { "Person 3", 0.00m }
            };
            float tipPercentage = 15;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTip(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTip_InvalidTipPercentage_ThrowsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Person 1", 30.00m },
                { "Person 2", 40.00m },
                { "Person 3", 50.00m }
            };
            float tipPercentage = -5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTip(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_ValidInput_CalculatesCorrectly()
        {
            // Arrange
            decimal totalPrice = 100;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act
            decimal tipPerPerson = splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3.00m, tipPerPerson);
        }

        [TestMethod]
        public void CalculateTipPerPerson_ZeroTotalPrice_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPrice = 0;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_NegativeNumberOfPatrons_ThrowsArgumentException()
        {
            // Arrange
            decimal totalPrice = 100;
            int numberOfPatrons = -5;
            float tipPercentage = 15;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage));
        }
    }
}

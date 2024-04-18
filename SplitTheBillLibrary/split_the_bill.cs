using System;
using System.Collections.Generic;

namespace SplitTheBillLibrary
{
    public class split_the_bill
    {
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
                throw new ArgumentException("Number of people must be greater than zero.");

            if (totalAmount <= 0)
                throw new ArgumentException("Total amount must be greater than zero.");

            return totalAmount / numberOfPeople;
        }

        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
                throw new ArgumentException("Meal costs dictionary is empty.");

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip percentage must be between 0 and 100.");

            var totalCost = CalculateTotalCost(mealCosts);
            if (totalCost <= 0)
                throw new ArgumentException("Total cost must be greater than zero.");

            var totalTipAmount = totalCost * ((decimal)tipPercentage / 100);

            var tipByPerson = new Dictionary<string, decimal>();
            foreach (var entry in mealCosts)
            {
                var tipAmountForPerson = entry.Value / totalCost * totalTipAmount;
                tipByPerson[entry.Key] = tipAmountForPerson;
            }

            return tipByPerson;
        }

        private decimal CalculateTotalCost(Dictionary<string, decimal> mealCosts)
        {
            decimal totalCost = 0;
            foreach (var cost in mealCosts.Values)
            {
                totalCost += cost;
            }
            return totalCost;
        }

        public decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)
        {
            if (totalPrice <= 0)
                throw new ArgumentException("Total price must be greater than zero.");

            if (numberOfPatrons <= 0)
                throw new ArgumentException("Number of patrons must be greater than zero.");

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip percentage must be between 0 and 100.");

            // Calculate total tip amount
            decimal totalTipAmount = totalPrice * ((decimal)tipPercentage / 100);

            // Calculate tip per person
            decimal tipPerPerson = totalTipAmount / numberOfPatrons;

            return tipPerPerson;
        }
    }
}

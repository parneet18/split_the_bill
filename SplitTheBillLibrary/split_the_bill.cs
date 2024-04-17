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

            return totalAmount / numberOfPeople;
        }

        
        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
                throw new ArgumentException("Meal costs dictionary is empty.");

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip percentage must be between 0 and 100.");

            var totalCost = CalculateTotalCost(mealCosts);
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
    }
}

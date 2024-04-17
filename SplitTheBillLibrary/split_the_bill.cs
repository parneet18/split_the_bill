

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
    }

}
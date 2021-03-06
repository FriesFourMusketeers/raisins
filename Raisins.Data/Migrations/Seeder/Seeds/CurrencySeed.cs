﻿using Raisins.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raisins.Data.Migrations.Seeder.Seeds
{
    public class CurrencySeed : IDbSeeder
    {
        public void Seed(RaisinsContext context)
        {
            AddCurrency(context, "PHP", 1.0M, 50.0M); //1
            AddCurrency(context, "USD", 44.0M, 1.0M); //2
            AddCurrency(context, "AUD", 39.0M, 1.0M); //3
            AddCurrency(context, "GBP", 71.0M, 1.0M); //4
            AddCurrency(context, "HKD", 5.0M, 9.0M);  //5
            AddCurrency(context, "SGD", 34.0M, 2.0M); //6
            AddCurrency(context, "EUR", 56.0M, 1.0M); //7
        }

        private void AddCurrency(
            RaisinsContext context,
            string name,
            decimal exchangeRate,
            decimal ratio)
        {
            if (!context.Currencies.Any(c => c.CurrencyCode == name))
            {
                context.Currencies.Add(new Currency()
                {
                    CurrencyCode = name,
                    ExchangeRate = exchangeRate,
                    Ratio = ratio
                });
            }
        }
    }
}
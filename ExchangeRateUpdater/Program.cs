﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRateUpdater
{
    public static class Program
    {
        private static IEnumerable<Currency> currencies = new[]
        {
            new Currency("USD"),
            new Currency("EUR"),
            new Currency("CZK"),
            new Currency("JPY"),
            new Currency("KES"),
            new Currency("RUB"),
            new Currency("THB"),
            new Currency("TRY"),
            new Currency("XYZ")
        };

        public static void Main(string[] args)
        {
            try
            {
                var provider = new ExchangeRateProvider();
                foreach (DataSourceEnum dataSource in Enum.GetValues(typeof(DataSourceEnum)))
                {
                    var rates = provider.GetExchangeRates(currencies, dataSource);

                    Console.WriteLine($"Successfully retrieved {rates.Count()} exchange rates from {dataSource.ToString()}:");
                    foreach (var rate in rates)
                    {
                        Console.WriteLine(rate.ToString());
                    }
                    Console.WriteLine("//--==--\\");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"An error occurred while retrieving exchange rates: {exc.Message}");
            }

            Console.ReadLine();
        }
    }
}

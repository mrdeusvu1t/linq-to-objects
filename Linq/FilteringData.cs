﻿using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use of filter operations (method 'Where' and 'where' keywords) in LINQ queries.
    /// Filtering : <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{TSource}"/>
    /// Filtering refers to the operation of restricting the result set to contain only
    /// those elements that satisfy a specified condition. It is also known as selection.
    /// </summary>
    public static class FilteringData
    {
        /// <summary>
        /// Finds all elements of an array less than 5.
        /// </summary>
        /// <returns>All elements of an array less than 5.</returns>
        public static IEnumerable<int> LowNumbers()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var myNumbers = from i in numbers where i < 5 select i;

            foreach (var i in myNumbers)
			{
                yield return i;
			}
        }

        /// <summary>
        /// Finds all products that are out of stock.
        /// </summary>
        /// <returns>All products that are out of stock.</returns>
        public static IEnumerable<Product> ProductsOutOfStock()
        {
            List<Product> products = Products.ProductList;

            var myProducts = from p in products where p.UnitsInStock == 0 select p;

            foreach (var product in myProducts)
			{
                yield return product;
			}
        }

        /// <summary>
        /// Finds all products that are in stock and cost more than 50.0 per unit.
        /// </summary>
        /// <returns>All products that are in stock and cost more than 50 per unit.</returns>
        public static IEnumerable<Product> ExpensiveProductsInStock()
        {
            List<Product> products = Products.ProductList;

            var myProducts = from p in products
                             where p.UnitsInStock > 0 && p.UnitPrice > 50
                             select p;

            foreach (var product in myProducts)
			{
                yield return product;
			}
        }

        /// <summary>
        /// Finds digits whose name is shorter than their value.
        /// </summary>
        /// <returns>Digits whose name is shorter than their value.</returns>
        public static IEnumerable<string> IndexedWhere()
        {
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            int i = 0;

            var myDigits = from str in digits
                           where str.Length < i++
                           select str;

            foreach (var str in myDigits)
			{
                yield return str;
			}
        }
    }
}
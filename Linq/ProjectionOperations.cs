using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use of projection operations (methods 'Select', and 'SelectMany' or 'select' keyword) in LINQ queries.
    /// Projecting: <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{TResult}"/>
    /// Projection refers to the operation of transforming an object into a new form that
    /// often consists only of those properties that will be subsequently used.
    /// </summary>
    public static class ProjectionOperations
    {
        /// <summary>
        /// Produces a sequence of integers one higher than those in an existing array of integers.
        /// </summary>
        /// <returns>The sequence of integers one higher than those in an existing array of integers.</returns>
        public static IEnumerable<int> Select()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            foreach (var number in numbers.Select(n => n + 1))
			{
                yield return number;
			}
        }

        /// <summary>
        /// Produces a sequence of just the names of a list of products.
        /// </summary>
        /// <returns>The sequence of just the names of a list of products.</returns>
        public static IEnumerable<string> SelectProperty()
        {
            List<Product> products = Products.ProductList;
            
            foreach (var product in products.Select(p => p.ProductName))
			{
                yield return product;
			}
        }

        /// <summary>
        /// Produces a sequence of strings representing the text version of a sequence of integers.
        /// </summary>
        /// <returns>The sequence of strings representing the text version of a sequence of integers.</returns>
        public static IEnumerable<string> TransformWithSelect()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var myTransform = from n in numbers
                              select strings[n];

            foreach(var item in myTransform)
			{
                yield return item;
			}
        }

        /// <summary>
        /// Produces a sequence of the uppercase and lowercase versions of each word in the original array.
        /// </summary>
        /// <returns>The sequence of the uppercase and lowercase versions of each word in the original array.</returns>
        public static IEnumerable<(string upper, string lower)> SelectByCase()
        {
            string[] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};

            var myWords = words.Select(w => (w.ToUpper(), w.ToLower()));

            foreach(var w in myWords)
			{
                yield return (w.Item1, w.Item2);
			}
        }

        /// <summary>
        /// Produces a sequence containing text representations of digits and whether their length is even or odd.
        /// </summary>
        /// <returns>The sequence containing text representations of digits and whether their length is even or odd.</returns>
        public static IEnumerable<(string digit, bool even)> SelectEvenOrOddNumbers()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var myNumbers = from n in numbers
                            select (strings[n], n % 2 == 0);

            foreach (var n in myNumbers)
			{
                yield return (n.Item1, n.Item2);
			}
        }

        /// <summary>
        /// Produces a sequence containing some properties of Products, including ProductName, Category and UnitPrice.
        /// </summary>
        /// <returns>The sequence containing some properties of Products, including ProductName, Category and UnitPrice.</returns>
        public static IEnumerable<(string productName, string category, decimal price)> SelectPropertySubset()
        {
            List<Product> products = Products.ProductList;

            var myProducts = from p in products
                             select (p.ProductName, p.Category, p.UnitPrice);

            foreach(var p in myProducts)
			{
                yield return (p.ProductName, p.Category, p.UnitPrice);
			}
        }

        /// <summary>
        /// Determines if the value of integers in an array match their position in the array.
        /// </summary>
        /// <returns>The sequence in which for each integer it is determined whether its value in the array matches their position in the array. </returns>
        public static IEnumerable<(int number, bool inPlace)> SelectWithIndex()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var myNumbers = numbers.Select((n, i) => new { number = n, index = i })
                            .Select(n => (n.number, n.index == n.number));

            foreach (var n in myNumbers)
			{
                yield return (n.number, n.Item2);
			}
        }

        /// <summary>
        /// Produce a sequence of strings representing a text version of a sequence of integers less than 5.
        /// </summary>
        /// <returns> The sequence of strings representing a text version of a sequence of integers less than 5.</returns>
        public static IEnumerable<string> SelectWithWhere()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var myDigits = from n in numbers
                              where n < 5
                              select digits[n];

            foreach (var digit in myDigits)
            {
                yield return digit;
            }
        }

        /// <summary>
        /// Produces all pairs of numbers from both arrays such that the number from `numbersA` is less than the number from `numbersB`.
        /// </summary>
        /// <returns>All pairs of numbers from both arrays such that the number from `numbersA` is less than the number from `numbersB`.</returns>
        public static IEnumerable<(int a, int b)> SelectFromMultipleSequences()
        {
            int[] numbersA = {0, 2, 4, 5, 6, 8, 9};
            int[] numbersB = {1, 3, 5, 7, 8};

            var sequence = from a in numbersA
                           from b in numbersB
                           where a < b
                           select (a, b);

            foreach(var item in sequence)
			{
                yield return (item.a, item.b);
			}
        }

        /// <summary>
        /// Selects all orders where the order total is less than 500.00.
        /// </summary>
        /// <returns>All orders where the order total is less than 500.00.</returns>
        public static IEnumerable<(string customerId, int orderId, decimal total)> SelectFromChildSequence()
        {
            List<Customer> customers = Customers.CustomerList;

            var myCustomers = from c in customers
                              from o in c.Orders
                              where o.Total < 500
                              select (c.CustomerId, o.OrderId, o.Total);

            foreach(var c in myCustomers)
			{
                yield return (c.CustomerId, c.OrderId, c.Total);
			}
        }

        /// <summary>
        /// Selects all orders where the order was made in 1998 or later.
        /// </summary>
        /// <returns>All orders where the order was made in 1998 or later.</returns>
        public static IEnumerable<(string customerId, int orderId, string orderDate)> SelectManyWithWhere()
        {
            List<Customer> customers = Customers.CustomerList;
            var dateTime = new DateTime(1998, 1, 1);

            var myCustomers = from c in customers
                              from o in c.Orders
                              where o.OrderDate.Year >= dateTime.Year
                              select (c.CustomerId, o.OrderId, o.OrderDate);

            foreach (var c in myCustomers)
			{
                yield return (c.CustomerId, c.OrderId, c.OrderDate.ToString("dd-MMM-yy", new CultureInfo("en-US")));
			}
        }

        /// <summary>
        /// Selects all orders where the order total is greater than 2000.00.
        /// </summary>
        /// <returns>All orders where the order total is greater than 2000.00.</returns>
        public static IEnumerable<(string customerId, int orderId, decimal totalValue)> SelectManyWhereAssignment()
        {
            List<Customer> customers = Customers.CustomerList;

            var myCustomers = from c in customers
                              from o in c.Orders
                              where o.Total > 2000
                              select (c.CustomerId, o.OrderId, o.Total);

            foreach (var c in myCustomers)
			{
                yield return (c.CustomerId, c.OrderId, c.Total);
			}
        }

        /// <summary>
        /// Select all customers in Washington region ("WA") with an order date greater than or equal to the given.
        /// </summary>
        /// <returns>All customers in Washington region with an order date greater than or equal to the given.</returns>
        public static IEnumerable<(string customerId, int orderId)> SelectMultipleWhereClauses()
        {
            List<Customer> customers = Customers.CustomerList;
            DateTime cutoffDate = new DateTime(1997, 1, 1);
            string region = "WA";

            var myCustomers = from c in customers
                              from o in c.Orders
                              where c.Region == region && o.OrderDate >= cutoffDate
                              select (c.CustomerId, o.OrderId);

            foreach(var c in myCustomers)
			{
                yield return (c.CustomerId, c.OrderId);
			}
        }

        /// <summary>
        /// Selects all orders, while referring to customers by the order in which they are returned from the query.
        /// </summary>
        /// <returns>All orders info in some string format (see unit tests), while referring to customers by the order in which they are returned from the query.</returns>
        public static IEnumerable<string> IndexedSelectMany()
        {
            List<Customer> customers = Customers.CustomerList;

            var myCustomers =
                customers
                .SelectMany((customer, index) => customer.Orders.Select(str => $"Customer #{index + 1} has an order with OrderID {str.OrderId}"));

            foreach (var c in myCustomers)
			{
                yield return c;
			}
        }
    }
}
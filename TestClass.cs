// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using NUnit.Framework;
using HW1;


namespace NUnit.BSTTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            //Tests are all performed on follwing input "1 , 2, 3, 2, 1, 5, 3, 4"
            //Test 1. Get user input as string
            string userInput = "1 2 3 2 1 5 3 4";

            //Test 2. Convert string input to array of int
            int[] convertedInput = ConvertInput(userInput);
            Assert.That(convertedInput, Is.All.InstanceOf<int>());

            //Test 3. Insert numbers to BST
            BST testInsert = new BST();
            foreach (var number in convertedInput)
            {
                testInsert.Insert(number);
            }

            Assert.That(testInsert, Is.Not.Null);

            //Test 4.  Display numbers in sorted order
            Assert.That(testInsert.DisplayInSortedOrder(), Is.EqualTo(" 1  2  3  4  5 "));

            //Test 5.  Display statistics of Tree
            Assert.That(testInsert.GetItemCount(), Is.EqualTo(5));
            Assert.That(testInsert.GetLevels(), Is.EqualTo(4));
            Assert.That(testInsert.GetMinLevels(), Is.EqualTo(3));

            Assert.Pass();
        }
       
        /// <summary>
        /// Convertes user's original string <paramref name="userInput"/> to an array of integers.
        /// </summary>
        /// <param name="userInput">Users input.</param>
        /// <returns>int[].</returns>
        public static int[] ConvertInput(string userInput)
        {
            string[] parsedInput = userInput.Split(' ');
            int[] userValues = new int[parsedInput.Length];
            int counter = 0;
            foreach (var number in parsedInput)
            {
                userValues[counter] = Convert.ToInt32(parsedInput[counter]);
                counter++;
            }

            return userValues;
        }
    }
}


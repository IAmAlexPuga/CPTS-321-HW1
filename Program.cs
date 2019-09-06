// <copyright file="Program.cs" company="Alex Puga, CPTS 321">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// This program will work with Nodes and BST.
/// Our goal is to collect user input and make the
/// numbers entered into a BST where we will be able to
/// display certain statistics of the BST provided.
/// <list type="bullet">
/// <item>
/// <term>Insert</term>
/// <description>Adds an number to the BST</description>
/// </item>
/// <item>
/// <term>GetLevels</term>
/// <description>Calculates amount of levesl in current BST</description>
/// </item>
/// <item>
/// <term>GetItemCount</term>
/// <description>Calculates number of items in BST</description>
/// </item>
/// <item>
/// <term>GetMinLevels</term>
/// <description>Calculates minimum levels requried for current BST</description>
/// </item>
/// </list>
/// </summary>
/// <remarks>
/// <para>This class can insert and calculate certain statistics in a BST.</para>
/// </remarks>
namespace HW1
{
    using System;

    /// <summary>
    /// The main <class>Program.cs</class> that pecies everything together and used for running/testing the product.
    /// Prints out stats of the BST in the end.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entrance of program.
        /// This program will take in a user input and create a BST
        /// with that input.  NO DUPLICATES WOULD BE ACCEPTED.
        /// Will display stats of the BST after calculations are performed.
        /// </summary>
        /// <param name="args">Args.</param>
        public static void Main(string[] args)
        {
            // Gets users input of integers in a string.
            string userInput = GetInput();

            // Converts string input into an array if integers and inserts these number into a BST.
            int[] arr = ConvertInput(userInput);
            BST bst = new BST();
            foreach (var number in arr)
            {
                bst.Insert(number);
            }

            // Calculates stats of BST and displays the stats.
            int levels = bst.GetLevels();
            int itemCount = bst.GetItemCount();
            int minLevelsReq = bst.GetMinLevels();

            // Displays BST in order.
            Console.WriteLine("{0}", bst.DisplayInSortedOrder());

            Console.WriteLine("Levels: {0} \nItemCount: {1} \nMinLevelsRequired: {2}", levels, itemCount, minLevelsReq);
        }

        /// <summary>
        /// Gets user input of numbers seperated by spaces.
        /// </summary>
        /// <returns>String.</returns>
        public static string GetInput()
        {
            Console.WriteLine("Enter a collection of numbers in range [0, 100], seperated by spaces: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Convertes user's original string <paramref name="userInput"/> to an array of integers.
        /// </summary>
        /// <param name="userInput">Users input.</param>
        /// <returns>int[].</returns>
        public static int[] ConvertInput(string userInput)
        {
            // Splits the string, userInput, from ' ' and saves the value to parsedInput.
            string[] parsedInput = userInput.Split(' ');
            int[] userValues = new int[parsedInput.Length];
            int counter = 0;

            // From parsedInput, we convert each to an integer that is stored in the array userValues.
            foreach (var number in parsedInput)
            {
                userValues[counter] = Convert.ToInt32(parsedInput[counter]);
                counter++;
            }

            return userValues;
        }
    }
}

// <copyright file="BST.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW1
{
    using System;

    /// <summary>
    /// The BST class defines basic BST functions.
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
    public class BST
    {
        private Node root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BST"/> class.
        /// </summary>
        public BST()
        {
            this.root = null;
        }

        /// <summary>
        /// Gets or sets the root.
        /// <set>Node</set>
        /// <return>Node</return>
        /// </summary>
        public Node Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        /// <summary>
        /// Insertes an integer <paramref name="data"/> to a BST.
        /// </summary>
        /// <param name="data">An integer.</param>
        public void Insert(int data)
        {
            if (this.root == null)
            {
                this.root = new Node(data);
            }
            else
            {
                this.root = this.InsertHelper(this.root, data);
            }
        }

        /// <summary>
        /// Helper function for Insert.  Inserts a certain integer <paramref name="data"/> to
        /// the BST while traversting through the Node <paramref name="root"/>.
        /// </summary>
        /// <param name="root">An Node to traverse through.</param>
        /// <param name="data">An integer to insert.</param>
        /// <returns>An Node.</returns>
        public Node InsertHelper(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            // Skips duplicate data.
            if (root.Data == data)
            {
                return root;
            }

            // Checks wich subtree to insert the data.
            if (root.Data > data)
            {
                 if (root.Left == null)
                {
                    root.Left = this.InsertHelper(root.Left, data);
                }
                else
                {
                    this.InsertHelper(root.Left, data);
                }
            }

            if (root.Data < data)
            {
                if (root.Right == null)
                {
                    root.Right = this.InsertHelper(root.Right, data);
                }
                else
                {
                    this.InsertHelper(root.Right, data);
                }
            }

            return root;
        }

        /// <summary>
        /// Returns a string representing the integers in BST from smalles to greatest.
        /// </summary>
        /// <returns>A String.</returns>
        public string DisplayInSortedOrder()
        {
            return this.DisplaySortedOrderHelper(this.root);
        }

        /// <summary>
        /// Returns an integer representing the amount of levels in the current BST.
        /// </summary>
        /// <returns>An integer that represents the number of levels.</returns>
        public int GetLevels()
        {
            if (this.root == null)
            {
                return 0;
            }
            else
            {
                return this.GetLevelsHelper(this.root) - 1;
            }
        }

        /// <summary>
        /// Calculates the minimum number of levels required for current BST.
        /// </summary>
        /// <returns>An integer.</returns>
        public int GetMinLevels()
        {
            int count = this.GetItemCount();

            return (int)Math.Ceiling(Math.Log(count)) + 1;
        }

        /// <summary>
        /// Gets the total number of items in the current BST. Returns result as an integer.
        /// </summary>
        /// <returns>An integer representing the number of items in current BST.</returns>
        public int GetItemCount()
        {
            if (this.root == null)
            {
                return 0;
            }
            else
            {
                return this.GetItemCountHelper(this.root);
            }
        }

        /// <summary>
        /// Helper function to return a string representing the integers in order.
        /// </summary>
        /// <param name="traverse">A Node.</param>
        /// <returns>A String.</returns>
        private string DisplaySortedOrderHelper(Node traverse)
        {
            if (traverse == null)
            {
                return string.Empty;
            }

            // Grabs the left substring of numbers.
            string leftSubS = this.DisplaySortedOrderHelper(traverse.Left);

            // Grabs current Node's data.
            string output = traverse.Data.ToString();
            output += " ";

            // Appends left substring to current Node's data then grabs right sub strings data.
            leftSubS += " " + output;
            leftSubS += this.DisplaySortedOrderHelper(traverse.Right);

            return leftSubS;
        }

        /// <summary>
        /// Helper function to travers through the BST and return an integer representing the amount of levels.
        /// </summary>
        /// <param name="traverse">Node passed in to traverse the tree to help calculate the amount of levels.</param>
        /// <returns>An integer representing the amount of levels.</returns>
        private int GetLevelsHelper(Node traverse)
        {
            if (traverse == null)
            {
                return 0;
            }

            // Looks for the highest level from either the left subtree or right subtree.
            int maxLeftLevel = 1 + this.GetLevelsHelper(traverse.Left);
            int maxRightLevel = 1 + this.GetLevelsHelper(traverse.Right);

            // Returns the highest level found.
            if (maxLeftLevel > maxRightLevel)
            {
                return maxLeftLevel;
            }
            else
            {
                return maxRightLevel;
            }
        }

        /// <summary>
        /// Helper function for GetItemCount().  Helps calculate number of items in current BST recursivly.
        /// </summary>
        /// <param name="traverse">A Node represeting the current position in BST.</param>
        /// <returns>Integer representing the number of items in BST.</returns>
        private int GetItemCountHelper(Node traverse)
        {
            if (traverse == null)
            {
                return 0;
            }
            else
            {
                return 1 + this.GetItemCountHelper(traverse.Left) + this.GetItemCountHelper(traverse.Right);
            }
        }
    }
}

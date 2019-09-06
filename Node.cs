// <copyright file="Node.cs" company="Alex Puga, CPTS 321">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW1
{
    using System;

    /// <summary>
    /// Node class used to help store our data for BST.
    /// <list type="bullet">
    /// <item>
    /// <term>Node</term>
    /// <description>Default constructore</description>
    /// </item>
    /// <item>
    /// <term>Left</term>
    /// <description>Getter and Setter for Left Node</description>
    /// </item>
    /// <item>
    /// <term>Right</term>
    /// <description>Getter and Setter for Right Node</description>
    /// </item>
    /// <item>
    /// <term>Data</term>
    /// <description>Getter and Setter for Data</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>This class is a container class for a BST.</para>
    /// </remarks>
    public class Node
    {
        private Node left;
        private Node right;
        private int data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// Default constructor. Accepts an integer <paramref name="data"/> to create a Node.
        /// </summary>
        /// <param name="data">An integer.</param>
        public Node(int data)
        {
            this.data = data;
            this.right = null;
            this.left = null;
        }

        /// <summary>
        /// Gets or sets Left Node.
        /// </summary>
        public Node Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets Right Node.
        /// </summary>
        public Node Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}